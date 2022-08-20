
var Account = {};


window.addEventAccount = (dotNetHelper) => {

    Account.dotNetHelper = dotNetHelper;

    Account.Login = function (id, name, token) {
        var user = {};
        user.id = id;
        user.name = name;
        user.Token = token;
        sessionStorage.setItem("user", JSON.stringify(user))
        return Account.dotNetHelper.invokeMethodAsync("CheckLogin");

    }


    Account.GetUserId = function () {
        var user = sessionStorage.getItem("user")
        if (user) {
            var a = JSON.parse(user);
            return a.id;
        }
        return null;
    }

    Account.GetName = function () {
        var user = sessionStorage.getItem("user")
        if (user) {
            var a = JSON.parse(user);
            return a.name;
        }
        return null;
    }

    Account.GetToken = function () {
        var user = sessionStorage.getItem("user")
        if (user) {
            var a = JSON.parse(user);
            return a.Token;
        }
        return null;
    }

    Account.IsLogin = function () {
        var user = sessionStorage.getItem("user")
        if (user) {
            return true;
        }
        return false;
    }

    Account.CheckLogin = function () {
        return Account.dotNetHelper.invokeMethodAsync("CheckLogin");
    }
}