using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp
{
    internal class User
    {
        private int userID;
        private string username;
        private string email;
        private string password;
        
        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Email
        {
            get => email;
            set
            {
                if (IsValidEmail(value))
                    email = value;
                else
                    throw new ArgumentException("E-mail is invalid");
            }
        }
        public string Password { get => password; set => password = value; }

        private bool IsValidEmail(string email)
        {

            return email.Contains("@");
        }

        private List<BlogPost> blogPosts = new List<BlogPost>();

        public void AddBlogPost(BlogPost post)
        {
            blogPosts.Add(post);
        }

        public List<BlogPost> GetBlogPosts()
        {
            return blogPosts;
        }
    }
}
