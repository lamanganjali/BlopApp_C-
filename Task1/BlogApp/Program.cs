namespace BlogApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                User user1 = new User { UserID = 1, Username = "leman_genceli", Email = "leman@example.com", Password = "12345" };
                
                BlogPost post1 = new BlogPost { Title = "Heyat", Content = "Xosbext olmaq ucun xosbext olmaq lazimdir!", Author = user1 };
                BlogPost post2 = new BlogPost { Title = "İlk Yazi", Content = "Xosbext olmaq!", Author = user1 };
                

                user1.AddBlogPost(post1);
                user1.AddBlogPost(post2);
                

                foreach (var post in user1.GetBlogPosts())
                {
                    Console.WriteLine($"{post.Title} - {post.Content} (Yazar: {post.Author.Username} ({post.DateCreated}))");
                }
                User user2 = new User { UserID = 1, Username = "qemzeli_qiz", Email = "qemzeliexample.com", Password = "12345" };
                BlogPost post3 = new BlogPost { Title = "gunluk problemler", Content = "Derdliyem!", Author = user2 };
                user2.AddBlogPost(post3);
            }
            catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
