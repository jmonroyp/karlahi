namespace KarlArt.Core.Application.Common.Models;
public class CloudFile
{
    public CloudFile(string url)
    {
        Url = url;
    }
    public string Name { get => Url.Split('/').Last(); }
    public string Url { get; set; } = string.Empty;
}