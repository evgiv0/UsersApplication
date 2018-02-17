(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("usersResource",
        ["$resource", "appSettings", usersResource]);

    function usersResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/users/:id", null,
            {
                update: {
                    method: 'PUT'
                },
                query: {
                    method: 'GET',
                    isArray: false
                }
            });
    }
})();