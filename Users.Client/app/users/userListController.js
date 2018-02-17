(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("UserListCtrl",
        ["usersResource", UserListCtrl]);

    function UserListCtrl(usersResource) {
        var vm = this;

        vm.pagging = {
            currentPage: 1,
            itemsPerPage: 5,
            totalItems: 0
        };

        usersResource.query(function (data) {
            var t = data;
            vm.users = t.users;
            vm.pagging.totalItems = t.countUser;
        });

        
    }
}());