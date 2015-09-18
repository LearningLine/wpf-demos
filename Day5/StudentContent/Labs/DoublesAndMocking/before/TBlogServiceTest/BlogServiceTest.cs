using BlogModel;
using TBlogService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TFSBlogRepository;
using System.Linq;
using Blog = TBlogService.Models.Blog;

namespace TBlogServiceTest
{


    /// <summary>
    ///This is a test class for BlogServiceTest and is intended
    ///to contain all BlogServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlogServiceTest
    {

        public TestContext TestContext { get; set; }

        [TestMethod()]
        public void GetBlogs_ReturnsAllBlogs_WhenAskedForPageSizeAndFewerThanPageSizeBlogsExist()
        {
            BlogService target = new BlogService(new DummyBlogRepository());
            IEnumerable<Blog> actual;
            actual = target.GetBlogs();
            Assert.AreEqual(2, actual.Count());
        }
    }

    public class DummyBlogRepository : IBlogRepository
    {

        #region IBlogRepository Members

        public System.Linq.IQueryable<BlogModel.Blog> GetBlogPosts(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BlogModel.Blog> GetBlogs()
        {
            BlogModel.User user = new User { Name = "name" };
            List<BlogModel.Blog> models = new List<BlogModel.Blog>
                                              {
                                                  new BlogModel.Blog{User = user}, 
                                                  new BlogModel.Blog{User = user}
                                              };
            return models.AsQueryable();
        }

        #endregion

        #region IRepository<Blog> Members

        public System.Linq.IQueryable<BlogModel.Blog> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public BlogModel.Blog New()
        {
            throw new NotImplementedException();
        }

        public void Add(BlogModel.Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Create(BlogModel.Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogModel.Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
