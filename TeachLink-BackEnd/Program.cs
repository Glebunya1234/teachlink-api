using Microsoft.OpenApi.Models;
using TeachLink_BackEnd.Core.Mappers.AnnouncementMappers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.Mappers.DegreeMappers;
using TeachLink_BackEnd.Core.Mappers.ExperienceMappers;
using TeachLink_BackEnd.Core.Mappers.NotificationMappers;
using TeachLink_BackEnd.Core.Mappers.StudentMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Core.Services.StudentService;
using TeachLink_BackEnd.Core.Services.TeacherService;
using TeachLink_BackEnd.Infrastructure;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;
using TeachLink_BackEnd.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Access token",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
        }
    );

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                new List<string>()
            },
        }
    );
});

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings)));

builder.Services.AddJwtAuthentication(builder.Configuration);


builder.Services.AddScoped<IBaseMapper<DegreeModelMDB, DegreeDTO>, GetDegreeMappers>();

builder.Services.AddScoped<IBaseMapper<ExperienceModelMDB, ExperienceDTO>, GetExperienceMappers>();

builder.Services.AddScoped<IBaseMapper<SubjectsModelMDB, SubjectDTO>, GetSubjectMappers>();

builder.Services.AddScoped<IBaseMapper<ReviewsModelMDB, CreateReviewDTO>, CreateReviewMappers>();
builder.Services.AddScoped<IBaseMapper<ReviewsModelMDB, ReviewDTO>, GetReviewMappers>();

builder.Services.AddScoped<IBaseMapper<StudentsModelMDB, CreateStudentDTO>, CreateStudentMappers>();
builder.Services.AddScoped<IBaseMapper<StudentsModelMDB, StudentDTO>, GetStudentMappers>();
builder.Services.AddScoped<IBaseMapper<StudentsModelMDB, UpdateStudentDTO>, UpdateStudentMappers>();

builder.Services.AddScoped<IBaseMapper<TeachersModelMDB, CreateTeacherDTO>, CreateTeacherMappers>();
builder.Services.AddScoped<
    IBaseMapper<TeachersModelMDB, FullTeacherTileDTO>,
    GetFullTeacherMappers
>();
builder.Services.AddScoped<IBaseMapper<TeachersModelMDB, TeacherTileDTO>, GetTeacherMappers>();

builder.Services.AddScoped<
    IBaseMapper<NotificationsModelMDB, CreateNotificationDTO>,
    CreateNotificationMappers
>();
builder.Services.AddScoped<
    IBaseMapper<NotificationsModelMDB, NotificationDTO>,
    GetNotificationMappers
>();
builder.Services.AddScoped<
    IBaseMapper<NotificationsModelMDB, UpdateNotificationDTO>,
    UpdatNotificationMappers
>();

builder.Services.AddScoped<
    IBaseMapper<AnnouncementsModelMDB, CreateAnnouncementDTO>,
    CreateAnnouncementMappers
>();
builder.Services.AddScoped<
    IBaseMapper<AnnouncementsModelMDB, AnnouncementDTO>,
    GetAnnouncementMappers
>();

builder.Services.AddScoped<AnnouncementService>();
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

builder.Services.AddScoped<DegreeService>();
builder.Services.AddScoped<IDegreeRepository, DegreeRepository>();

builder.Services.AddScoped<ExperienceService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();

builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<ReviewsService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<StudentsService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<TeachersService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddExceptionHandler<HandlerGlobalExeptions>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(_ => { });
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
