

using ASM.SHARE.Entities;
using System.Collections.Generic;


namespace ASM.SHARE.Models
{
    public class MockCategory
    {
        private List<Category> categories = new()
        {
            new Category() { Name = "Đồ ăn" },
            new Category() { Name = "Đồ uống" },
            new Category() { Name = "Đồ chay" },
            new Category() { Name = "Tráng miệng" },

        };

        public List<Category> GetCategories()
        {

            return categories;
        }
    }
}