namespace NamiMetal
{
    public class RemoteServiceOptions
    {
        public static string SectionName = "RemoteServices";
        public RemoteApi Default { get; set; }
    }

    public class RemoteApi
    {
        public string BaseUrl { get; set; }
    }
}
