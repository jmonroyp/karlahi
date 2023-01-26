using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KarlArt.Core.Application.Common.Models;
public abstract class CustomRequest
{
    public override string ToString()
    {
        //serialize object Indented and with CamelCase
        return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }
}
