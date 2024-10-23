using BlogApp4;

namespace BlogApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Tag { CategoryID = 1, CategoryName = "Tech", Metadata = "Technology" });
            categories.Add(new Genre { CategoryID = 2, CategoryName = "Fiction" });

            try
            {
                foreach (var category in categories)
                {
                    category.GetCategoryDetails();
                }

                Category invalidCategory = categories.Find(c => c.CategoryID == 10);
                if (invalidCategory == null) throw new Exception("Category not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}


