﻿using ASM.SEVER.HttpInterfaces;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ASM.SEVER.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        [Inject]
        private ICategoryHttp categoryHttpRepo { get; set; }
        private void IncrementCount()
        {
            currentCount++;
        }

        protected override async Task OnInitializedAsync()
        {
            var a = await categoryHttpRepo.GetCategoriesAsync();
            
        }
    }
}
