namespace KarlaHi.Api.Configuration
{
    public class ExampleParent
    {
        public string Title { get; set; }
        public ExampleChild ExampleChild { get; set; }
    }
    public class ExampleChild
    {
        public bool IsSearchBoxEnabled { get; set; }
        public string BannerTitle { get; set; }
        public bool IsBannerSliderEnabled { get; set; }
    }
}