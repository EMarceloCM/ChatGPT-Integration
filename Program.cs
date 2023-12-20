using Chatgpt.ASP.NET.Integration.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog();
builder.AddChatGpt();

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwaggerDoc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
