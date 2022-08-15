
var Cart = {};
window.addEventCart = (dotNetHelper) => {
    Cart.DotNetHelper = dotNetHelper;



    Cart.InsertCart = function (cartDetail) {
        var carts = [];
        var a = sessionStorage.getItem("cart");
        if (a) {
            carts = JSON.parse(a)
        }
        var check = false;
        carts.forEach(function (item) {
           if(item.productId == cartDetail.productId) {
               item.quantity = item.quantity + 1;
               check = true;
           }
        })
       
        if (!check) {
            carts.push(cartDetail);
        }
        sessionStorage.setItem("cart", JSON.stringify(carts));
        return Cart.DotNetHelper.invokeMethodAsync("UpdateCart", JSON.stringify(carts));
    };


    Cart.AddSession = function (listCartDetail) {
        sessionStorage.removeItem("cart");
    }


    Cart.DeleteCart = function (id) {
        var carts = [];
        var a = sessionStorage.getItem("cart");
        if (a) {
            carts = JSON.parse(a)
        }
        var i = 0;
        carts.forEach(function (item) {
            if (item.productId == id) {
                carts.splice(i, 1);
            }
            i++;
        })

        sessionStorage.setItem("cart", JSON.stringify(carts));
        return Cart.DotNetHelper.invokeMethodAsync("UpdateCart", JSON.stringify(carts));
    }

    window.onload = function () {
        var a = sessionStorage.getItem("cart")
        if (a) {
            return Cart.DotNetHelper.invokeMethodAsync("UpdateCart", JSON.stringify(carts));

        }
    }


}