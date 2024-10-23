using System;
using System.Collections.Generic;

namespace BlogApp3
{
    public class UserComment : Comment, ICommentManager
    {
        public static Dictionary<int, List<Comment>> comments = new Dictionary<int, List<Comment>>();

        public void AddComment(BlogPost post, Comment comment)
        {
            if (post == null)
            {
                throw new ArgumentException("Blog yazısı tapılmadı.");
            }

            if (!comments.ContainsKey(post.PostID))
            {
                comments[post.PostID] = new List<Comment>();
            }

            
            comments[post.PostID].Add(comment);
            Console.WriteLine($"Yorum əlavə edildi: {comment.Content} - Yazarı: {comment.Author.Username}");
        }

        public void DeleteComment(BlogPost post, Comment comment)
        {
            if (post == null || !comments.ContainsKey(post.PostID))
            {
                Console.WriteLine("Blog yazısı tapılmadı.");
                return;
            }

            if (comments[post.PostID].Remove(comment))
            {
                Console.WriteLine("Yorum silindi.");
            }
            else
            {
                Console.WriteLine("Yorum tapılmadı.");
            }
        }

        public override void DisplayComment()
        {
            Console.WriteLine($"Yorum: {Content} - Yazarı: {Author.Username}");
        }
    }
}
