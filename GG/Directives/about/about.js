var ggModule = angular.module('ggModule');

ggModule.directive('ggAbout', ['ggService', '$window', '$http', function (ggService, $window, $http) {
    // Link Function - DOM Manipulation
    link = function ($scope, $element, $attrs) {

    }

    // Controller Function - Scope Manager
    controller = function ($scope) {





    }



    return {
        restrict: 'EA',
        scope: {
            onAppModeUpdate: '&',
        },
        templateUrl: 'directives/about/about.html',
        link: link,
        controller: controller
    };
}]);


