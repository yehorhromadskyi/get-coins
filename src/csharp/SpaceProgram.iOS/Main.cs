using System.Net;
using System.Net.Http;
using UIKit;

namespace SpaceProgram.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            System.Net.WebRequest.DefaultWebProxy = new WebProxy("http://127.0.0.1", 5865);

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}