(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("UserEditCtrl",
        ["usersResource", "$routeParams", UserEditCtrl]);

    function UserEditCtrl(usersResource, $routeParams) {
        var vm = this;

        vm.user = {};
        vm.message = '';

        var userId = $routeParams.id;

        usersResource.get({ id: userId },
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