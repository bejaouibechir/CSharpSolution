using System;
using System.Diagnostics;
using System.Web;

namespace WebMVC.Helpers
{
    public class TraceModule : IHttpModule
    {
        public void Dispose()
        {
            ;
        }

        public void Init(HttpApplication context)
        {
            try
            {
   
                Debug.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}");
            }
            catch 
            {
                ;
            }
        }
    }
}