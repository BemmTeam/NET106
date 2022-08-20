
window.Cart = {};


window.GetListCart = function () {
    var carts = [];
    carts = sessionStorage.getItem("cart");
    console.log(JSON.parse(carts))
    return carts;
}

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

    Cart.ClearCart = function () {

        sessionStorage.removeItem("cart")
        
        return Cart.DotNetHelper.invokeMethodAsync("ClearCart");

    }





    window.onload = function () {
        var a = sessionStorage.getItem("cart")
        if (a) {
            return Cart.DotNetHelper.invokeMethodAsync("UpdateCart", JSON.stringify(carts));
        }
    }


}