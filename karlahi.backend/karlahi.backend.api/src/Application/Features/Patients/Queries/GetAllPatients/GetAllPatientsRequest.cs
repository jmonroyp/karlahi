using Bogus;
using KarlArt.Core.Application.Common.Interfaces.Models;
using MediatR;

namespace KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
public class GetAllPatientsRequest : GetCriteria<Patient>, IRequest<Result<IList<GetAllPatientsResponse>>>, IFakeable<BaseGetQueryString>
{
    public GetAllPatientsRequest() : base()
    {
    }
    public GetAllPatientsRequest(IGetQueryString getQueryString) : base(getQueryString)
    {
    }

    public BaseGetQueryString Fake() => new Faker<BaseGetQueryString>()
        .RuleFor(x => x.Q, f => "Name:John AND LastName:Smith")
        .RuleFor(x => x.Page, f => f.Random.Int(1, 10))
        .RuleFor(x => x.PageSize, f => f.Random.Int(1, 10))    
        .Generate();
}

public class GetAllPatientsSearchCriteria
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}