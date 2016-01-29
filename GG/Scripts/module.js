/// <reference path="../angular.js" />
var app;
(function () {
    app = angular.module("ggModule", [ 'angular-loading-bar', 'wu.masonry', 'ui.bootstrap']);

    app.filter('getById', function() {
        return function(input, id) {
            var i=0, len=input.length;
            for (; i<len; i++) {
                if (+input[i].id == +id) {
                    return input[i];
                }
            }
            return null;
        }
    });

})();


//app.run(function ($rootScope, $templateCache) {
//    $rootScope.$on('$viewContentLoaded', function () {
//        $templateCache.removeAll();
//    });
//});