using KarlArt.Core.Application.Common.Interfaces.Models;
using KarlArt.Core.Application.Common.Models;

namespace KarlArt.Core.Api;
public static class GenerateExamples
{
    public static void GenerateRequestExamples(this WebApplication app) 
    {
        // get all the request types which inherit from CustomRequest
        var requestTypes = typeof(IFakeable<>).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(CustomRequest)) && !t.IsAbstract);

        // loop through each request type and generate a fake example
        foreach (var requestType in requestTypes)
        {
            // get type of IFakeable<>
            var fakeableType = typeof(IFakeable<>).MakeGenericType(requestType);
            // generate object of type IFakeable<requestType>
            var fakeable = Activator.CreateInstance(requestType);
            // get the Fake method
            var fakeMethod = fakeableType.GetMethod("Fake");
            // invoke the Fake method
            var fake = fakeMethod!.Invoke(fakeable, null);
            // save the fake example to file /Examples/Requests/{requestType.Name}.json
            app.SaveExample(fake!.ToString()!, $"{requestType.Name}.json");
        }
    }

    private static void SaveExample(this WebApplication app, string example, string path)
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Examples", "Requests");
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        var filePath = Path.Combine(directory, path);
        File.WriteAllText(filePath, example);
    }
}