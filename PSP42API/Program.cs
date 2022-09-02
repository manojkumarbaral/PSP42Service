using BusinessService.Interface;
using BusinessService.Logic;
using DAL;
using DATA.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ILogin, LoginService>();
builder.Services.AddTransient<IMenuBusiness, MenuBusinessService>();
builder.Services.AddTransient<DataLayer>();
builder.Services.AddTransient<IMasterInterface, MasterBusiness>();
builder.Services.AddTransient<ISponsorInterface, SponsorBusinessService>();
builder.Services.AddTransient<IFileUploadInterface, FileUploadBusinessService>();
builder.Services.AddTransient<IMember, MemberList>();
builder.Services.AddTransient<IProductInfo, ProductService>();
builder.Services.AddTransient<IUserManagementInterface, UserMasterService>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
