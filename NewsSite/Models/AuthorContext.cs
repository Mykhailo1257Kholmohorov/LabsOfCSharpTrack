using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewsSite.Models
{
    public class AuthorContext : DbContext
    {
        public AuthorContext() : base("AuthorContext")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
    }

    public class ArticleDbInitializer : DropCreateDatabaseAlways<AuthorContext>
    {
        protected override void Seed(AuthorContext db)
        {
            db.Authors.Add(new Author {Email = "author1@gmail.com", Name = "John", Password = "12345678fg"});
            db.Articles.Add(new Article
            {
                Title = "Thunderstorm in Texas ",
                Topic = "Nature",
                Content = "Destroyed 100 building ",
                Date = DateTime.Now
            });
            db.Articles.Add(new Article
            {
                Title = "Win 10 000 000$ ",
                Topic = "Lucky",
                Content = "Josh won 10 000 000 dollars in lottery ",
                Date = DateTime.Now
            });
            db.Articles.Add(new Article
            {
                Title = "Update Coin Master ",
                Topic = "Games",
                Content = "New updates for Coin Master will be come in Monday ",
                Date = DateTime.Now
            });

            base.Seed(db);
        }
    }
}