using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Helper
{
    public class CartHelper
    {

        private List<CartDetail> cartDetails;

        public List<CartDetail> CartDetails
        {

            get => cartDetails;
            set
            {
                cartDetails = value; 

            }
        }

        public void AddCart(CartDetail cartDetail)
        {
            cartDetails.Add(cartDetail);
        }

        public void RemoveCart(Guid id)
        {
            foreach (var item in cartDetails)
            {
                if (item.CartDetailId == id)
                {
                    cartDetails.Remove(item);
                }
            }
        }


        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
