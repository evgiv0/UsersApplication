(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("UserListCtrl",
        UserListCtrl);

    function UserListCtrl() {
        var usersCtrl = this;

        usersCtrl.users = [
            {
                "userId": 1,
                "FirstName": "Zhenya",
                "MiddleName": "Igorevich",
                "LastName": "Ivaneev",
                "Contacts": [{ "value": "1concact" }, { "value": "2concact" }, { "value": "3concact" } ]
            },
            {
                "userId": 1,
                "FirstName": "Zhenya",
                "MiddleName": "Igorevich",
                "LastName": "Ivaneev",
                    "Contacts": [{ "value": "1concact" }, { "value": "2concact" }, { "value": "3concact" } ]

            },
            {
                "userId": 1,
                "FirstName": "Zhenya",
                "MiddleName": "Igorevich",
                "LastName": "Ivaneev",
                "Contacts": [{ "value": "1concact" }, { "value": "2concact" }, { "value": "3concact" }]

            },
            {
                "userId": 1,
                "FirstName": "Zhenya",
                "MiddleName": "Igorevich",
                "LastName": "Ivaneev",
                "Contacts": [{ "value": "1concact" }, { "value": "2concact" }, { "value": "3concact" }]

            },
            {
                "userId": 1,
                "FirstName": "Zhenya",
                "MiddleName": "Igorevich",
                "LastName": "Ivaneev",
                "Contacts": []
            }
        ];
    }
}());