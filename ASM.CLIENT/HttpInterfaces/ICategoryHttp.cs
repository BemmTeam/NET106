using ASM.SHARE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpInterfaces
{
    public interface ICategoryHttp
    {

        Task<List<Category>> GetCategories();


    }
}
