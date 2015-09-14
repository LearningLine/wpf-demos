using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Practices.Unity;
using TBlogService;
using System.Configuration;
using TFSBlogRepository;

namespace TBlogServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {            
            using (ServiceHost service = new ServiceHost(typeof(BlogService), new Uri("http://localhost:9000/TBlog")))
            {
                service.Open();
                Console.WriteLine("Service started");
                Console.ReadLine();
            }
        }
    }
}
