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


        vm.search = function (row) {
            return angular.lowercase(row.firstName).indexOf(angular.lowercase(vm.searchString) || '') !== -1
                || angular.lowercase(row.middleName).indexOf(angular.lowercase(vm.searchString) || '') !== -1
                || angular.lowercase(row.lastName).indexOf(angular.lowercase(vm.searchString) || '') !== -1
                || searchInContacts(row.contacts);
        };

        function searchInContacts(contacts){
            var isExist = false;
            for (var i = 0; i < contacts.length; i++) {
                if (contacts[i].value.indexOf(angular.lowercase(vm.searchString) || '') !== -1)
                    isExist = true;
            }
            return isExist;
        }
    }
}());