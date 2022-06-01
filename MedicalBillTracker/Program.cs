using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MedicalBillTracker.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MedicalBillTracker.Controllers;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                       policy =>
                       {
                           policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                       });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBillRepo, BillRepo>();
builder.Services.AddTransient<IPatientRepo, PatientRepo>();
//builder.Services.AddTransient<IArchiveRepo, ArchiveRepo>();
builder.Services.AddTransient<IArchiveItemRepo, ArchiveItemRepo>();
var FirebaseSDKPath = builder.Configuration["fbCredPath"];
//Firebase Authentication 
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(FirebaseSDKPath)
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.Authority = "https://securetoken.google.com/medicalbilltracker-bed2c"; //use your project name
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://securetoken.google.com/medicalbilltracker-bed2c", //use your project name
        ValidateAudience = true,
        ValidAudience = "medicalbilltracker-bed2c",  //use your project name
        ValidateLifetime = true,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();