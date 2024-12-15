using Api.Core;
using Api.Extentions;
using Application.Extentions;
using Application.Implement.Clientss;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.FileProviders;
//
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddSignalRCore();
builder.Services.ConfigureVersioning();

builder.Services.AddServicesLifeTime();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();

builder.Services.AddSignalR(option => {
    option.EnableDetailedErrors = true;
   
});
builder.Services.AddSignalR(
option =>
{
    option.EnableDetailedErrors = true;
    //option.ClientTimeoutInterval = 0;
}).AddJsonProtocol(option =>
{
    option.PayloadSerializerOptions = null;
});


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressInferBindingSourcesForParameters = true;
    options.SuppressConsumesConstraintForFormFileParameters = true;
});
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.WriteIndented = true;
});
builder.Services.AddTransient<ApplicationDBContext>();
//
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources/ar-EG.json");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});
app.UseMiddleware<GlobalExceptionHandler>();
//app.UseAuthentication();
//app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Allow", "GET,PUT,DELETE,CREATE");
    context.Response.Headers.Add("X-Developed-By", "Ahmed Adel");
    context.Response.Headers.Add("X-Developed-Phone", "01032882094");
    await next.Invoke();
});
app.UseEndpoints(endpoints =>
{
    app.MapHub<ClientsServices>("/Clients");

});
app.MapEndPoints();
app.Run();
