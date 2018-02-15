(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("UserEditCtrl",
        ["usersResource", UserEditCtrl]);

    function UserEditCtrl(usersResource) {
        var vm = this;

        vm.user = {};
        vm.message = '';

        usersResource.get({ id: 1 },
            function (data) {
                vm.user = data;
                vm.originalUser = angular.copy(data);
            });

        if (vm.user && vm.user.userId) {
            vm.title = "Edit";
        }
        else {
            vm.title = "New Product";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.user.userId) {
                vm.user.$update({ id: vm.user.userId },
                    function (data) {
                        vm.message = "Save Complete";
                    });
            }
            else {
                vm.user.$save(
                    function (data) {
                        vm.originalUser = angular.copy(data);
                        vm.message = "Save Complete";
                    });
           }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.user = angular.copy(vm.originalUser);
            vm.message = "";
        };
    }
}());