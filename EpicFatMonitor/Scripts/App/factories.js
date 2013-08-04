var factories = {};

factories.userService = function ($resource) {
    var factory = $resource('/rest/user/', {}, {
        get: { method: "GET" },
        update: { method: "PUT" },
        isArray: false
    });

    return factory;
};

fatMonitorApp.factory(factories);