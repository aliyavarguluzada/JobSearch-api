using Asp.Versioning;
using JobSearch.Application;
using JobSearch.Application.Repositories;
using JobSearch.Infrastructure;
using JobSearch.Infrastructure.Repositories;
using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true; //This ensures if client doesn't specify an API version. The default version should be considered. 
    option.DefaultApiVersion = new ApiVersion(1, 0); //This we set the default API version
    option.ReportApiVersions = true; //The allow the API Version information to be reported in the client  in the response header. This will be useful for the client to understand the version of the API they are interacting with.

    //------------------------------------------------//
    option.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"));
        //new HeaderApiVersionReader("X-Version"),
        //new MediaTypeApiVersionReader("ver")); //This says how the API version should be read from the client's request, 3 options are enabled 1.Querystring, 2.Header, 3.MediaType. 
                                               //"api-version", "X-Version" and "ver" are parameter name to be set with version number in client before request the endpoints.
}).AddApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV"; //The say our format of our version number “‘v’major[.minor][-status]”
    options.SubstituteApiVersionInUrl = true; //This will help us to resolve the ambiguity when there is a routing conflict due to routing template one or more end points are same.
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddAntiforgery(options =>
{
    // Set Cookie properties using CookieBuilder properties†.
    options.FormFieldName = "AntiforgeryFieldname";
    options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
    options.SuppressXFrameOptionsHeader = false;
}); // should add antiforgery attribute to controllers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseAuthorization();
var antiforgery = app.Services.GetRequiredService<IAntiforgery>();

app.Use((context, next) =>
{
    var requestPath = context.Request.Path.Value;

    if (string.Equals(requestPath, "/", StringComparison.OrdinalIgnoreCase)
        || string.Equals(requestPath, "/index.html", StringComparison.OrdinalIgnoreCase))
    {
        var tokenSet = antiforgery.GetAndStoreTokens(context);
        context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
            new CookieOptions { HttpOnly = false });
    }

    return next(context);
});

app.MapControllers();

app.Run();
