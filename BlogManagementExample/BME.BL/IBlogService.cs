using System.Collections.Generic;
using System.Linq;
using BME.DAL;
using Mongo.DAL;

namespace BME.BL
{
    public interface IBlogService
    {
        void EditBlog(Blog blog);
        Blog FindBlog(int? id);
        List<Blog> GetBlogs();
        void PostBlog(Blog blog);
        void PostMongo(List<BlogMongo> mongoBlogs);
        IQueryable<BlogMongo> GetMongo();
    }
}