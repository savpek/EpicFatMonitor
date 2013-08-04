function LoginController($scope) {
    $scope.foo = "ABC";
}

fatMonitorApp.controller('HomeController', function ($scope, userService) {
    var dailyWeightApi = userService;

    $scope.sendWeight = function () {
        dailyWeightApi.get({}, function (user) {
            $scope.weight = user.Measurements[0].Weight;
        });
    };
});

fatMonitorApp.controller('StatsController', function ($scope) {
    $scope.items = ['foo', 'bar', 'jorma'];
})