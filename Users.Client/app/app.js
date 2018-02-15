(function () {
    "use strict";

    var app = angular.module("userManagement", ["ngRoute","common.services"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "app/users/userListView.html",
                controller: "UserListCtrl"
            })
            .when("/Users/Edit/:id", {
                templateUrl: "app/users/userEditView.html",
                controller: "UserEditCtrl"
            })

            .otherwise("/", {
                templateUrl: "index.html",
                controller: "UserListCtrl"
            });
    });
}());