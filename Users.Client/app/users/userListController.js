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
            vm.users = data.users;
            vm.pagging.totalItems = data.countUser;
        });

        
    }
}());