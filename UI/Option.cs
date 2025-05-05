namespace UI;

public class RequestMethods
{
    public static readonly string GET = "GET";
    public static readonly string PUT = "PUT";
}

public class Option
{
    public Option(string method, string url, string text)
    {
        Method = method;
        URl = url;
        Text = text;
    }
    public string Method { get; set; }
    public string URl { get; set; }
    
    public string Text { get; set; }
    
}