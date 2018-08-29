using BME.DAL;
using Mongo.DAL;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BME.BL
{
    public class BlogService : IBlogService
    {
        BlogEngine ctx = new BlogEngine();
        BlogContext db = new BlogContext();
        public List<Blog> GetBlogs()
        {
            return ctx.Blogs.ToList();
        }

        public void PostBlog(Blog blog)
        {
            ctx.Blogs.Add(blog);
            ctx.SaveChanges();
            ctx.Database.ExecuteSqlCommand("update Blog set synced = 'true'");
        }

        public void EditBlog( Blog blog)
        {
            ctx.Entry(blog).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public Blog FindBlog(int? id)
        {
            Blog temp = ctx.Blogs.Where(p => p.BlogId == id).SingleOrDefault();
            return temp;
        }

        public IQueryable<BlogMongo> GetMongo()
        {
            return db.mongoCollection.AsQueryable();
        }

        public void PostMongo(List<BlogMongo> blogMongo)
        {
            db.mongoCollection.InsertMany(blogMongo);
        }
    }
}
