(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("UserListCtrl",
        ["usersResource", UserListCtrl]);

    function UserListCtrl(usersResource) {
        var usersCtrl = this;

        usersCtrl.searchString = "ch";

        usersResource.query({
            $filter: "substringof('" + usersCtrl.searchString + "', FirstName)" + 
            "or substringof('" + usersCtrl.searchString + "', LastName)" + 
            "substringof('" + usersCtrl.searchString + "', MiddleName)"
        }, function (data) {
            usersCtrl.users = data;
        });
    }
}());