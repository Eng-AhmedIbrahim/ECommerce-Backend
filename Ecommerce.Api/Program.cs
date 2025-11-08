SerilogSettings.AddSerilogSettings();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

var DefaultConnection = Guard.Against.
        NullOrWhiteSpace(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173",
            "https://e-commerce-frontend-rosy-zeta.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod()
               .AllowCredentials();
    });
});



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost5173",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:5173") // الfrontend origin
//                  .AllowAnyHeader()
//                  .AllowAnyMethod();
//        });
//});




builder.Services
    .AddSwaggerServiceCollection()
    .AddDataBaseConnections(DefaultConnection)
    .AddApplicationServices(builder)
    .AddIdentityExtensions(builder.Configuration)
    .AddECommerceInfrastructureServices()
    .AddEcommerceUseCasesServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
});

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(MediatorRequestPipelineBehaviour<,>)
);


var app = builder.Build();

await app.AddAutoMigrationService();

app.UseMiddleware<ExceptionMiddleware>();


app.UseSwagger();
app.UseSwaggerUI();

app.UseStatusCodePagesWithRedirects("/errors/{0}");

app.UseHttpsRedirection();
app.HandelException();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();