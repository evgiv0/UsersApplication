(function (){
    "use strict";

    angular
        .module("common.services")
        .factory("contactsResource",
        ["$resource", "appSettings", contactsResource]);

    function contactsResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/contacts/:id");
    }
})();