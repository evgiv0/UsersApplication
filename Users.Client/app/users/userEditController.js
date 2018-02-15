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

        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.user = angular.copy(vm.originalUser);
            vm.message = "";
        };
    }
}());