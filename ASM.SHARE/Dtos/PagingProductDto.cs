using ASM.SHARE.Entities;
using System.Collections.Generic;

namespace ASM.SHARE.Dtos
{
    public class PagingProductDto
    {
        public int PageSize { get; set; } = 6;

        public int PageCount { get; set; }

        public int PageSelected { get; set; } = 1;

        public string Search { get; set; }

        public List<Product> Data { get; set; }


    }
}
