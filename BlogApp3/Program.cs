using System;
using System.Collections.Generic;

namespace BlogApp3
{
    
    

    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Istifadeci: {Username}");
        }

        public virtual void EnsureAdminPermission()
        {
            throw new PermissionDeniedException("Bu əməliyyatı yerinə yetirmək üçün yetərli səlahiyyətiniz yoxdur.");
        }
    }

    public class AdminUser : User
    {
        private List<User> users = new List<User>();
        private List<BlogPost> blogPosts = new List<BlogPost>();

        public void AddUser(User user)
        {
            users.Add(user);
            Console.WriteLine($"{user.Username} adli istifadeci elave olundu.");
        }

        public void RemoveUser(User user)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
                Console.WriteLine($"{user.Username} adli istifadeci silindi.");
            }
            else
            {
                Console.WriteLine("Istifadeci tapilmadi.");
            }
        }

        public void AddBlogPost(BlogPost post)
        {
            blogPosts.Add(post);
            Console.WriteLine($"'{post.Title}' blog elave olundu.");
        }

        public void RemoveBlogPost(BlogPost post)
        {
            if (blogPosts.Contains(post))
            {
                blogPosts.Remove(post);
                Console.WriteLine($"'{post.Title}' blog yazisi silindi.");
            }
            else
            {
                Console.WriteLine("Blog yazısı tapilmadi.");
            }
        }

        
        public override void DisplayDetails()
        {
            Console.WriteLine($"Admin: {Username}");
            Console.WriteLine("Idare edilen istifadeci sayi: " + users.Count);
            Console.WriteLine("Blog sayi: " + blogPosts.Count);
        }
    }

    public class RegularUser : User
    {
        public override void DisplayDetails()
        {
            Console.WriteLine($"Normal istifadeci: {Username}");
        }
        public override void EnsureAdminPermission()
        {
            throw new PermissionDeniedException("Bu əməliyyatı yalnız administrator yerinə yetirə bilər.");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AdminUser admin = new AdminUser { Username = "john_doe" };

            RegularUser user1 = new RegularUser { UserID = 1, Username = "user1" };
            RegularUser user2 = new RegularUser { UserID = 2, Username = "user2" };
            RegularUser user3 = new RegularUser { UserID = 3, Username = "user3" };

            BlogPost post1 = new BlogPost { Title = "İlk Blog Yazısı", Content = "salam dünya!", Author = admin };
            BlogPost post2 = new BlogPost { Title = "İkinci Blog Yazısı", Content = "qeribe bir blog!", Author = admin };
            BlogPost post3 = new BlogPost { Title = "Üçüncü Blog Yazısı", Content = "Daha fazla blog gelecek!", Author = admin };

            UserComment comment1 = new UserComment { CommentID = 1, Author = user1, Content = "mohtesem bir yazı!" };
            UserComment comment2 = new UserComment { CommentID = 2, Author = user2, Content = "Çok bilgilendirici, təşəkkürlər!" };
            UserComment comment3 = new UserComment { CommentID = 3, Author = user3, Content = "Daha fazla blog görmek isteyerem!" };
            UserComment comment4 = new UserComment { CommentID = 4, Author = user1, Content = "Yine harika bir paylaşım!" };
            UserComment comment5 = new UserComment { CommentID = 5, Author = user3, Content = "Təşəkkürlər, gözəl yazı!" };

            UserComment commentManager = new UserComment();

            try
            {
                commentManager.AddComment(post1, comment1);
                commentManager.AddComment(post1, comment2);

                commentManager.AddComment(post2, comment3);
                commentManager.AddComment(post2, comment4);

                commentManager.AddComment(post3, comment5);

                List<BlogPost> blogPosts = new List<BlogPost> { post1, post2, post3 };

                foreach (var post in blogPosts)
                {
                    Console.WriteLine($"\nYorumlar - {post.Title}:");

                    if (UserComment.comments.ContainsKey(post.PostID))
                    {
                        foreach (var comment in UserComment.comments[post.PostID])
                        {
                            Console.WriteLine($"Yorum: {comment.Content} - Yazarı: {comment.Author.Username}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu blog-a hələlik şərh edilməyib.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta: {ex.Message}");
            }
        }

    }

}
