var ggModule = angular.module('ggModule');

ggModule.directive('ggMenu', ['ggService', '$window', '$http', function (ggService, $window, $http) {
    // Link Function - DOM Manipulation
    link = function ($scope, $element, $attrs) {

    }

    // Controller Function - Scope Manager
    controller = function ($scope) {



        $scope.$watch(function () {
            return $scope.appMode;
        },
            function (value) {
                if($scope.appMode != undefined)
                ggService.appMode = $scope.appMode;

            }
        );


    }



    return {
        restrict: 'EA',
        scope: {
            onAppModeUpdate: '&',
        },
        templateUrl: 'directives/Menu/Menu.html',
        link: link,
        controller: controller
    };
}]);


