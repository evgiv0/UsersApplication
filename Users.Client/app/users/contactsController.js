(function () {
    "use strict";
    angular
        .module("userManagement")
        .controller("ContactsCtrl",
        ["contactsResource", ContactsCtrl]);

    function ContactsCtrl(usersResource) {
        var vm = this;

        vm.deleteContact = function(contactId){
            console.log("delete");
        };
    }
}());