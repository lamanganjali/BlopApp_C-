using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp4
{
    public abstract class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public abstract void GetCategoryDetails();
    }

    public class Tag : Category
    {
        public string Metadata { get; set; }

        public override void GetCategoryDetails()
        {
            Console.WriteLine($"Tag: {CategoryName}, Metadata: {Metadata}");
        }
    }

    public class Genre : Category
    {
        public override void GetCategoryDetails()
        {
            Console.WriteLine($"Genre: {CategoryName}");
        }
    }


}
