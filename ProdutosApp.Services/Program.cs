using ProdutosApp.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwagger();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCorsConfig();
builder.Services.AddJwtBearer();

var app = builder.Build();

app.UseSwaggerDoc();

app.UseAuthentication();
app.UseAuthorization();

app.UseCorsConfig();
app.MapControllers();

app.Run();



