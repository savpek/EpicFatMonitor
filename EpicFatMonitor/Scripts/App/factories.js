var factories = {};

factories.dailyWeightApiFactory = function ($resource) {
    var factory = $resource('/rest/settings', {}, {
        get: { method: "GET" },
        update: { method: "PUT" },
        isArray: false
    });

    return factory;
};

fatMonitorApp.factory(factories);