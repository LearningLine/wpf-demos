using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using TFSBlogRepository;
using System.Configuration;
using TBlogService.Models;

namespace TBlogService
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _repository;
        
        
        public BlogService()
            : this(IoC.Container.Instance.Resolve<IBlogRepository>())
        {}

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["TFSBlogEntities"].ConnectionString;
            //IBlogRepository repository = new BlogRepository(connectionString);

            Blogs blogFactory = new Blogs();
            IEnumerable<Blog> blogs = blogFactory.GetBlogs(_repository, 10, 1);

            return blogs;
        }
    }
}
