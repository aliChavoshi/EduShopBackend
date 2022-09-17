using Application;
using Infrastructure;
using Web;

var builder = WebApplication.CreateBuilder(args);
//configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebConfigureServices(builder.Configuration);
//build
var app = builder.Build();
await app.AddWebAppService().ConfigureAwait(false);