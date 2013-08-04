function LoginController($scope) {
    $scope.foo = "ABC";
}

fatMonitorApp.controller('HomeController', function ($scope, userService) {
    if (userService.measurements !== undefined) {
        $scope.weight = userService.measurements[0].Weight;
        $scope.email = userService.email;
    }

    $scope.$on('userServiceUpdated', function () {
        $scope.weight = userService.measurements[0].Weight;
        $scope.email = userService.email;
    });

    $scope.sendWeight = function () {
        
    };
});

fatMonitorApp.controller('StatsController', function ($scope, userService) {
    var calculateValues = function () {
        $scope.measurements = userService.measurements.sort(function (a, b) { return a.Time < b.Time; });
        $scope.email = userService.email;

        var initialWeight = $scope.measurements[0].Weight;

        var i;
        for (i = 0; i < $scope.measurements.length; i++) {
            var weight = $scope.measurements[i].Weight;
            $scope.measurements[i].fromInitialPercent = (weight / initialWeight * 100) - 100;
        }
    };

    if (userService.email !== undefined) {
        calculateValues();
    }

    $scope.$on('userServiceUpdated', function () {
        calculateValues();
    });
});