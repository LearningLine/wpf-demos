using BlogModel;
using Rhino.Mocks;
using TBlogService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TFSBlogRepository;
using System.Linq;
using Blog = TBlogService.Models.Blog;
using Audit;

namespace TBlogServiceTest
{


    /// <summary>
    ///This is a test class for BlogServiceTest and is intended
    ///to contain all BlogServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlogServiceTest
    {
        private IBlogRepository _repository;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _repository = MockRepository.GenerateStub<IBlogRepository>();
        }

        [TestMethod()]
        public void GetBlogs_ReturnsAllBlogs_WhenAskedForPageSizeAndFewerThanPageSizeBlogsExist()
        {
            BlogModel.User user = new BlogModel.User();

            List<BlogModel.Blog> blogs = new List<BlogModel.Blog> 
                        {
                            new BlogModel.Blog {User = user},
                            new BlogModel.Blog {User = user},
                        };

            _repository.Stub(r => r.GetBlogs()).Return(blogs.AsQueryable());
            BlogService target = new BlogService(_repository, null);
            IEnumerable<Blog> actual;
            actual = target.GetBlogs();
            Assert.AreEqual(2, actual.Count());
        }

        [TestMethod()]
        [ExpectedException(typeof(ServiceException))]
        public void GetBlogs_ShouldThrowAnException_WhenRepositoryIsNull()
        {
            _repository.Stub(r => r.GetBlogs()).Return(null);
            BlogService target = new BlogService(_repository, null);
            IEnumerable<Blog> actual;
            actual = target.GetBlogs();
        }

        [TestMethod()]
        [ExpectedException(typeof(ServiceException))]
        public void GetBlogs_ShouldThrowAnException_WhenGetBlogsThrowsAnException()
        {
            _repository.Stub(r => r.GetBlogs()).IgnoreArguments().Throw(new NullReferenceException());
            BlogService target = new BlogService(_repository, null);
            IEnumerable<Blog> actual;
            actual = target.GetBlogs();
        }

        [TestMethod]
        public void GetBlogs_ShouldProduceAnAuditMessage_WhenAnIAuditIsPassed()
        {
            MockRepository mocks = new MockRepository();
            _repository = mocks.DynamicMock<IBlogRepository>();
            IAudit audit = mocks.StrictMock<IAudit>();

            BlogModel.User user = new BlogModel.User();
            List<BlogModel.Blog> blogs = new List<BlogModel.Blog> 
                {
                    new BlogModel.Blog {User = user},
                    new BlogModel.Blog {User = user},
                };

            using (mocks.Record())
            {
                Expect.Call(() => audit.Message("Get Blogs"));
                Expect.Call(_repository.GetBlogs()).Return(blogs.AsQueryable());
            }

            using (mocks.Playback())
            {
                BlogService target = new BlogService(_repository, audit);
                target.GetBlogs();
            }
        }
    }
}
