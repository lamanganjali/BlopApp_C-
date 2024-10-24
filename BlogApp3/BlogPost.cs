using System;

namespace BlogApp3
{
    public class BlogPost
    {

        private static int nextPostId = 1;

        
        private int postId;
        private string title;
        private User author;
        private DateTime dateCreated;
        private string content;

        public int PostID => postId;

        public string Title
        {
            get => title;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    title = value;
                else
                    throw new ArgumentException("Title cannot be null or empty.");
            }
        }

        public User Author
        {
            get => author;
            set
            {
                if (value != null)
                    author = value;
                else
                    throw new ArgumentException("Author cannot be null.");
                if (value is AdminUser)
                    author = value;
                else
                    throw new PermissionDeniedException("Only AdminUser can be the author of a BlogPost.");
            }
        }

        public DateTime DateCreated => dateCreated; 

        public string Content
        {
            get => content;
            set
            {
                if (value.Length <= 500)
                    content = value;
                else
                    throw new ArgumentException("Content cannot be more than 500 characters.");

            }
        }

        public BlogPost()
        {
            postId = nextPostId++;
            dateCreated = DateTime.Now;

        }
    }
}
