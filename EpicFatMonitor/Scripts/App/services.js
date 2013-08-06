var factories = {};

factories.userService = function ($resource, $rootScope) {
    var restApi = $resource('/rest/user/', {}, {
        get: { method: "GET" },
        post: { method: "POST" },
        isArray: false
    });

    var service = {};

    restApi.get({}, function (user) {
        console.log("User rest request completed.");
        service.measurements = user.Measurements;
        service.email = user.Email;

        $rootScope.$broadcast('userServiceUpdated');
    });

    service.Save = function () {
        restApi.post({ "email": service.email, "measurements" : service.measurements}, function() {
            
        });

        console.log("service.Save called.");
    };

    return service;
};

fatMonitorApp.factory(factories);