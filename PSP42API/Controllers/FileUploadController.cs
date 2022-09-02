using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;
using BusinessEntities;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BusinessService.Interface;
using DATA.EF;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
//Microsoft.Extensions.Hosting
namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly string AppDirectory;// = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        //private static List<FileRecord> fileDB = new List<FileRecord>();
        //private IWebHostEnvironment WebHostEnvironment;
        private IConfiguration _Configuration;
        private IFileUploadInterface _FileUploadInterface;
        private readonly ApplicationDBContext ApplicationDBContext;

        public FileUploadController(ApplicationDBContext _ApplicationDBContext, IConfiguration Configuration, IFileUploadInterface FileUploadInterface)
        {
            this._FileUploadInterface = FileUploadInterface;
            this._Configuration = Configuration;
            AppDirectory = _Configuration.GetSection("FileServerPath").GetSection("SponsorFilePath").Value;
            this.ApplicationDBContext = _ApplicationDBContext;
        }

        [HttpPost("Upload")]
        //[Consumes("multipart/formdata")]
        public async Task<HttpResponseMessage> Upload([FromForm] FileModel[] model)
        {
            try
            {
                var form = Request.Form;
                var formkey = Request.Form.Keys;
                foreach (var file1 in form.Files)
                {
                    
                    FileRecords file = await SaveFileAsync(file1, form);
                    if (!string.IsNullOrEmpty(file.FilePath))
                    {
                        SaveToDB(file);
                    }
                    else
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);

                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }
        

        private async Task<FileRecords> SaveFileAsync(IFormFile myFile, IFormCollection form)
        {
            FileRecords file = new FileRecords();
            if (myFile != null)
            {
                //Check Exist folder if not found then create a folder SPONSOR_<SPONSORPKID>_<SPONSOREID>
                //Create two sub-folder MemberCard and photo and three file
                if (!Directory.Exists(AppDirectory + form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["eidNumber"][0]))
                {
                    Directory.CreateDirectory(AppDirectory + form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["eidNumber"][0]);
                }
                var filename = myFile.Name + "_" + form["sponsorTID"][0] + "_" + form["eidNumber"][0] + Path.GetExtension(myFile.FileName);
                var path = Path.Combine(AppDirectory + form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["eidNumber"][0], filename);
                file.FilePath = form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["eidNumber"][0];
                file.FileName = filename;
                file.FileExtension = Path.GetExtension(myFile.FileName);
                file.FileSize = myFile.Length;
                file.MimeType = myFile.ContentType;
                file.SponsorEID = form["eidNumber"][0];
                file.SponsorTID = Convert.ToDouble(form["sponsorTID"][0]);

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    //If file exist Overwite exist files else create new file
                    await myFile.CopyToAsync(stream);
                }
                return file;
            }
            return file;
        }
        private void SaveToDB(FileRecords record)
        {
            if (record == null)
                throw new ArgumentException($"{nameof(record)}");
            _FileUploadInterface.FileInfoSaveToDB(record);
     
        }
        [HttpGet("MemberAppDownload")]
        public async Task<IActionResult> MemberAppDownload(int MemberFileDetailsID)
        {
            try
            {
                var file = ApplicationDBContext.tbl_TRN_MemberFileDetails.Where(x => x.MemberFileDetailsID == MemberFileDetailsID && x.IsActive == true).FirstOrDefault();
                if (file != null)
                {
                    var path = Path.Combine(AppDirectory + "/" + file.FilePath + "/Members/" + file.FileName);
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(path, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    var contentType = file.MimeType;
                    var fileName = Path.GetFileName(path);
                    return File(memory, contentType, fileName);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("DeleteMemberAppFileDownloadDetails")]
        public async Task<IActionResult> DeleteMemberAppFileDownloadDetails(int MemberFileDetailsID)
        {
            try
            {
                var file = ApplicationDBContext.tbl_TRN_MemberFileDetails.Where(x => x.MemberFileDetailsID == MemberFileDetailsID && x.IsActive == true).FirstOrDefault();
                if (file != null)
                {
                    file.IsActive = false;
                    ApplicationDBContext.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("MemberAppFileDownloadDetails")]
        public async Task<IActionResult> MemberAppFileDownloadDetails(int Member_ID)
        {
            try
            {
                var file = ApplicationDBContext.tbl_TRN_MemberFileDetails.Where(x => x.Member_ID == Member_ID && x.IsActive == true).ToList();
                if (file != null)
                {
                    return Ok(file);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("Download")]
        public async Task<IActionResult> Download(int filedetailsID)
        {
            try
            {
                var file = ApplicationDBContext.tbl_TRN_FileDetails.Where(x => x.FileDetailsID == filedetailsID).FirstOrDefault();
                if (file != null)
                {
                    var path = Path.Combine(AppDirectory + "/" + file.FilePath + "/" + file.FileName);
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(path, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    var contentType = file.MimeType;
                    var fileName = Path.GetFileName(path);
                    return File(memory, contentType, fileName);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //MemberApplicatin page
        [HttpPost("MemberUpload")]
        public async Task<HttpResponseMessage> MemberUpload([FromForm] FileModel[] model)
        {
            try
            {
                var form = Request.Form;
                var formkey = Request.Form.Keys;
                foreach (var file1 in form.Files)
                {

                    FileRecords file = await memberSaveFileAsync(file1, form);
                    if (!string.IsNullOrEmpty(file.FilePath))
                    {
                        MemberFileSaveToDB(file);
                    }
                    else
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);

                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }


        private async Task<FileRecords> memberSaveFileAsync(IFormFile myFile, IFormCollection form)
        {
            FileRecords file = new FileRecords();
            if (myFile != null)
            {
                //Check Exist folder if not found then create a folder SPONSOR_<SPONSORPKID>_<SPONSOREID>
                //Create two sub-folder MemberCard and photo and three file
                if (!Directory.Exists(AppDirectory + form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["sponsorEIDNumber"][0]))
                {
                    Directory.CreateDirectory(AppDirectory + form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["sponsorEIDNumber"][0]);
                }
                var filename = "SP" + form["member_ID"][0] + "_" + form["memberUID"][0] + "_" + new Random().Next(1000, 9999) + "_" + myFile.Name + Path.GetExtension(myFile.FileName);
                var path = Path.Combine(AppDirectory + form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["sponsorEIDNumber"][0] + "\\Members", filename);
                file.FilePath = form["customerCode"][0] + "\\SPONSOR_" + form["sponsorTID"][0] + "_" + form["sponsorEIDNumber"][0];
                file.FileName = filename;
                file.FileExtension = Path.GetExtension(myFile.FileName);
                file.FileSize = myFile.Length;
                file.MimeType = myFile.ContentType;
                file.member_ID = Convert.ToInt32(form["member_ID"][0]);
                file.TypeOfFile = myFile.Name;
                file.action = form["action"][0];
                file.userid = Convert.ToInt32(form["userid"][0]);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    //If file exist Overwite exist files else create new file
                    await myFile.CopyToAsync(stream);
                }
                return file;
            }
            return file;
        }

        private void MemberFileSaveToDB(FileRecords record)
        {
            if (record == null)
                throw new ArgumentException($"{nameof(record)}");
            _FileUploadInterface.MemberFileSaveToDB(record);

        }
    }
    
}
