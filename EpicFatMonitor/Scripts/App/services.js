var factories = {};

factories.userService = function ($resource, $rootScope) {
    var restApi = $resource('/rest/user/', {}, {
        get: { method: "GET" },
        update: { method: "PUT" },
        isArray: false
    });

    var service = {};

    restApi.get({}, function (user) {
        console.log("User rest request completed.");
        service.measurements = user.Measurements;
        service.email = user.Email;

        $rootScope.$broadcast('userServiceUpdated');
    });

    service.Save = function() {
        console.log("service.Save called.");
    };

    service.ValueUpdated = function() {

    };

    return service;
};

fatMonitorApp.factory(factories);