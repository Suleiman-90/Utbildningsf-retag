using Microsoft.EntityFrameworkCore;
using Utbildningsföretag.Applikation.DTOs;
using Utbildningsföretag.Applikation.Interfaces;
using Utbildningsföretag.Applikation.Services;
using Utbildningsföretag.infrastructure.Persistance;
using Utbildningsföretag.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
// -------------------- DATABASE --------------------
builder.Services.AddDbContext<Utbildningdbcontext>(options =>
options.UseNpgsql(
builder.Configuration.GetConnectionString("EducationDb"))
.UseSnakeCaseNamingConvention());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// -------------------- REPOSITORIES --------------------
builder.Services.AddScoped<ICourseRepository, KursRepository>();
builder.Services.AddScoped<IDeltagareRepository, DeltagareRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistreraRepositori>();
// -------------------- APPLICATION SERVICES --------------------
builder.Services.AddScoped<KursService>();
builder.Services.AddScoped<DeltagareService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<RegistreraService>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Education API Running");
// ============================================================
// COURSES
// ============================================================
app.MapPost("/courses", async (
    KursService service,
    CreateKursDto dto) =>
{
    var id = await service.CreateCourseAsync(dto);
    return Results.Created($"/courses/{id}", id);
});
app.MapGet("/courses", async (KursService service) =>
{
    return Results.Ok(await service.GetCoursesAsync());
});
// ============================================================
// PARTICIPANTS
// ============================================================
app.MapPost("/participants", async (
    DeltagareService service,
    CreateDeltagareDto dto) =>
{
    var id = await service.CreateParticipantAsync(dto);
    return Results.Created($"/participants/{id}", id);
});
// ============================================================
// SESSIONS
// ============================================================
app.MapPost("/sessions", async (
    SessionService service,
    CreateSessionDto dto) =>
{
    var id = await service.CreateSessionAsync(dto);
    return Results.Created($"/sessions/{id}", id);
});
// ============================================================
// REGISTRATIONS
// ============================================================
app.MapPost("/registrations", async (
    RegistreraService service,
    RegistreraDeltagareDto dto) =>
{
    await service.RegisterAsync(dto);
    return Results.Ok("Participant registered successfully");
});
app.Run();