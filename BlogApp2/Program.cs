using System;
using System.Collections.Generic;

namespace BlogApp2
{
    // Custom exception for permission errors
    

    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Istifadeci: {Username}");
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
        
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                AdminUser admin = new AdminUser { UserID = 1, Username = "admin1" };
                RegularUser user1 = new RegularUser { UserID = 2, Username = "user1" };
                RegularUser user2 = new RegularUser { UserID = 3, Username = "user2" };

                admin.AddUser(user1);
                admin.AddUser(user2);

                BlogPost post1 = new BlogPost { Title = "Admin Postu", Content = "Admin yazısı", Author = admin };

                admin.DisplayDetails();
                user1.DisplayDetails();
                user2.DisplayDetails();

                BlogPost user1Post = new BlogPost { Title = "User1's Post", Content = "User yazısı", Author = user1 };
                admin.AddBlogPost(user1Post);
            }
            catch (PermissionDeniedException ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Umumi xeta: {ex.Message}");
            }
        }
    }
}
