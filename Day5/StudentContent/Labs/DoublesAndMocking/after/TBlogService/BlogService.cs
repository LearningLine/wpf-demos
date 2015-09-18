using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using TFSBlogRepository;
using System.Configuration;
using TBlogService.Models;
using Audit;
using SimpleAudit;

namespace TBlogService
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _repository;
        private IAudit _audit;

        public BlogService()
            : this(IoC.Container.Instance.Resolve<IBlogRepository>(), IoC.Container.Instance.Resolve<IAudit>())
        { }

        public BlogService(IBlogRepository repository, IAudit audit)
        {
            _repository = repository;
            _audit = audit;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            Blogs blogFactory = new Blogs();
            IEnumerable<Blog> blogs;
            try
            {
                if (_audit != null)
                {
                    _audit.Message("Get Blogs");
                }
                blogs = blogFactory.GetBlogs(_repository, 10, 1);
            }
            catch (Exception)
            {
                throw new ServiceException();
            }

            return blogs;
        }
    }
}
