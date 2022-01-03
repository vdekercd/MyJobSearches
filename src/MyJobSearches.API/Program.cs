// Configure services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Configure app
var app = builder.Build();
app.ConfigureSwaggerIfDevelopment();
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.Run();

