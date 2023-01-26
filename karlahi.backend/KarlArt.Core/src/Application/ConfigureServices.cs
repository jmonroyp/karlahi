using System.Reflection;
using AutoMapper;
using KarlArt.Core.Application.Common.Behaviours;
using KarlArt.Core.Application.Common.Interfaces.Services;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Attachments;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
using KarlArt.Core.Application.UseCases.Attachments;
using KarlArt.Core.Application.UseCases.Common;
using KarlArt.Core.Application.UseCases.Patients.Add;
using KarlArt.Core.Application.UseCases.Patients.GetAll;
using FluentValidation;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AllowNullCollections = true;
            //add profiles inherited from Profile
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Profile));
            mc.AddProfiles(types.Select(t => Activator.CreateInstance(t) as Profile));
        });
        services.AddSingleton(mapperConfig.CreateMapper());      
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddUseCases();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        //common
        services.AddScoped<IPerformAuditToEntityUseCase, PerformAuditToEntity>();

        //patients
        services.AddScoped<IAddPatientUseCase, AddPatientUseCase>();
        services.AddScoped<IGetAllPatientsUseCase, GetAllPatientsUseCase>();

        //attachments
        services.AddScoped<IAddAttachmentUseCase, AddAttachmentUseCase>();

        //upload files to storage service use case
        services.AddScoped<IUploadFileToStorageUseCase, UploadFileToStorageUseCase>();
        return services;
    }
}
