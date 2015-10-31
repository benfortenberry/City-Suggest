﻿var ggModule = angular.module('ggModule');

ggModule.directive('ggMixer', ['ggService', '$window', '$http', function (ggService, $window, $http) {
    // Link Function - DOM Manipulation
    link = function ($scope, $element, $attrs) {

    }

    // Controller Function - Scope Manager
    controller = function ($scope) {


        //$scope.updateContent = function (con) {

        //    rushService.updateContent(con);

        //}


        //$scope.updateUser = function (user) {

        //   ggService.updateUser(user);

        //}

        //$scope.removeUser = function (user) {
        //    var retVal = confirm("Are you sure you want to delete this User?  There is no undo.");
        //    if (retVal == true) {
        //        rushService.removeUser(user).then(function (result) {

        //            rushService.getAllUsers().then(function (result) {
        //                //alert(JSON.stringify(result.data));

        //                $scope.Users = result.data;
        //            });

        //        });

        //    }

        //}

        //$scope.updateOrg = function (org) {

        //    rushService.updateOrg(org);

        //}

        //$scope.removeOrg = function (org) {

        //    var retVal = confirm("Are you sure you want to delete this Organization? There is no undo.");
        //    if (retVal == true) {
        //        rushService.removeOrg(org).then(function (result) {


        //            rushService.getAllOrgs().then(function (result) {

        //                $scope.Organizations = result.data;
        //            });

        //        });


        //    }

        //}

        //$scope.updateSch = function (sch) {

        //    rushService.updateSch(sch);

        //}

        //$scope.removeSchool = function (sch) {
        //    var retVal = confirm("Are you sure you want to delete this School? There is no undo.");
        //    if (retVal == true) {
        //        rushService.removeSchool(sch).then(function (result) {

        //            rushService.getAllSchools().then(function (result) {
        //                // alert(JSON.stringify(result.data));

        //                $scope.Schools = result.data;
        //            });


        //        });
        //    }

        //}

        //$scope.updateSor = function (sor) {

        //    rushService.updateSor(sor);

        //}

        //$scope.removeSorority = function (sor) {
        //    var retVal = confirm("Are you sure you want to delete this Sorority? There is no undo.");
        //    if (retVal == true) {
        //        rushService.removeSorority(sor).then(function (result) {

        //            rushService.getAllSororities().then(function (result) {
        //                //   alert(JSON.stringify(result.data));

        //                $scope.Sororities = result.data;
        //            });


        //        });
        //    }

        //}


        //$scope.$watch(function () {
        //    return rushService.appMode;
        //}, function (newVal, oldVal) {
        //    $scope.appMode = rushService.appMode;


        //    if ($scope.appMode == 'admin') {

        //        $window.scrollTo(0, 0)
        //        // alert('admin');

        //        rushService.getAllOrgs().then(function (result) {
        //            //   alert(JSON.stringify(result.data));

        //            $scope.Organizations = result.data;
        //        });

        //        rushService.getAllSchools().then(function (result) {
        //            // alert(JSON.stringify(result.data));

        //            $scope.Schools = result.data;
        //        });

        //        rushService.getAllSororities().then(function (result) {
        //            //   alert(JSON.stringify(result.data));

        //            $scope.Sororities = result.data;
        //        });

        //        rushService.getAllUsers().then(function (result) {
        //            //alert(JSON.stringify(result.data));

        //            $scope.Users = result.data;
        //        });

        //        rushService.getAllContent().then(function (result) {
        //            //  alert(JSON.stringify(result.data));

        //            $scope.Contents = result.data;
        //        });




        //    }

        //});





        //$scope.appModeUpdate = function (selectedMode) {

        //    rushService.updateAppMode({ mode: selectedMode });

        //    // alert(selectedMode);
        //    $scope.onAppModeUpdate({ mode: selectedMode });


        //}

    }



    return {
        restrict: 'EA',
        scope: {
            onAppModeUpdate: '&',
        },
        templateUrl: 'directives/mixer/mixer.html',
        link: link,
        controller: controller
    };
}]);



app.controller('AdminInstanceCtrl', ['$scope', '$modalInstance', function ($scope, $modalInstance) {


    $scope.ok = function () {
        $modalInstance.close();
    };


    $scope.Cancel = function () {
        $modalInstance.dismiss();
    };
}]);