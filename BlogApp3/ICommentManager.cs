using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogApp3
{
    public interface ICommentManager
    {
        void AddComment(BlogPost post, Comment comment);
        void DeleteComment(BlogPost post,Comment comment);
    }

}
