using System.Security.Cryptography;
using bookapi_minimal.Endpoints;
using bookapi_minimal.Extensions;

var builder = WebApplication.CreateBuilder(args);



builder.AddApplicationServices();
builder.Services.AddOpenApi();


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


if (app.Environment.IsDevelopment())

{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}


    //app.UseHttpsRedirection();
app.UseExceptionHandler();

// app.UseHsts();

app.MapGroup("/api/v1/").WithTags("Book endpoints").MapBookEndpoint();

app.Run();

