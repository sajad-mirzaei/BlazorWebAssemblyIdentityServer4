using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Security;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
{
    return errors == SslPolicyErrors.None;
};

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder => builder.WithOrigins(
            "https://localhost:7000", //Idp
            "https://localhost:7011", //Api1
            "https://localhost:7012", //Api2
            "https://localhost:7013", //Api3
            "https://localhost:7021", //WebAssemblyClient1
            "https://localhost:7022", //WebAssemblyClient2
            "https://localhost:7023", //NetCoreJavaScriptClient
            "https://localhost:44360",//WebFormAppJavaScriptClient
            "https://localhost:44350" //WebForm CSharp Client
            )
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Add builder.Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

#region idp
// accepts any access token issued by identity server
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7000"; //idp
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        options.BackchannelHttpHandler = handler; //Must Remove In Production!!!!
    });


// adds an authorization policy to make sure the token is for scope 'api2'
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api2");
    });
});
#endregion

var app = builder.Build();

//cors
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
        .RequireAuthorization("ApiScope");//.RequireCors(MyAllowSpecificOrigins);
});

app.Run();
