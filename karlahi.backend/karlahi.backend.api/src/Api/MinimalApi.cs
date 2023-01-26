using KarlArt.Core.Api.Common;
using KarlArt.Core.Application.Features.Attachments.Commands.Add;
using KarlArt.Core.Application.Features.Patients.Commands.AddPatient;
using KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
using MediatR;

namespace KarlArt.Core.Api;
public static class MinimalApi
{
    public static void UseMinimalApi(this WebApplication app) =>
        app.MapPatientEndpoints()
            .MapAttachmentEndpoints();

    private static WebApplication MapPatientEndpoints(this WebApplication app)
    {
        app.MapGet("/patient", async (IMediator mediator, GetQueryString queryString)
            => (await mediator.Send(new GetAllPatientsRequest(queryString))).ToHttpResult())
                .WithDescription("Get all patients")
                .WithOpenApi(operation =>
                {
                    operation.Description = new GetAllPatientsRequest().Fake().ToString();
                    return operation;
                });

        app.MapPost("/patient", async (IMediator mediator, AddPatientRequest request)
            => (await mediator.Send(request)).ToHttpResult())
                .WithDescription("Add a new patient")
                .WithOpenApi(operation =>
                {
                    operation.Description = new AddPatientRequest().Fake().ToString();
                    return operation;
                });

        return app;
    }

    private static WebApplication MapAttachmentEndpoints(this WebApplication app)
    {
        app.MapPost("/attachment/{patientId}", async (IMediator mediator, Guid patientId, HttpRequest request)
            => (await mediator.Send(new AddAttachmentRequest(patientId, await request.GetFileAsync()))).ToHttpResult())
                .WithDescription("Add a new attachment to a patient")
                .WithOpenApi(operation =>
                {
                    //operation.Description = new AddAttachmentRequest().Fake().ToString();
                    return operation;
                })
                .Accepts<IFormFile>("multipart/form-data");

        return app;
    }
}