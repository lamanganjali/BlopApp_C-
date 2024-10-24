﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp3
{
    public abstract class Comment
    {
        public int CommentID { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }

        public abstract void DisplayComment();
    }

}
