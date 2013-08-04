'use strict';

var fatMonitorApp = angular.module('fatMonitorApp', ['ngResource']);

fatMonitorApp.config(function ($routeProvider) {
    $routeProvider.when('/Home', { templateUrl: 'Views/home.html', controller: 'HomeController' });
    $routeProvider.when('/Stats', { templateUrl: 'Views/stats.html', controller: 'StatsController' });
    $routeProvider.otherwise({redirectTo: '/Home'});
});