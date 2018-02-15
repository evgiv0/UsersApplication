(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("UserListCtrl",
        ["usersResource", UserListCtrl]);

    function UserListCtrl(usersResource) {
        var vm = this;

        vm.searchString = "ch";

        vm.queryData = function (searchString) {
            usersResource.query({
                $filter: "substringof('" + searchString + "', FirstName)" +
                "or substringof('" + searchString + "', LastName)" +
                "or substringof('" + searchString + "', MiddleName)"
            }, function (data) {
                vm.users = data;
            });
        };

        vm.queryData("ch");
    }
}());