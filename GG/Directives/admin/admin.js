var ggModule = angular.module('ggModule');

ggModule.directive('ggAdmin', ['ggService', '$window', '$http', 'ngToast', function (ggService, $window, $http, ngToast) {
    // Link Function - DOM Manipulation
    link = function ($scope, $element, $attrs) {

    }

    // Controller Function - Scope Manager
    controller = function ($scope) {



        ggService.getAllVenues().then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.venues = result.data;
            
        });

        ggService.getAllPrices(false).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.prices = result.data;
          //  console.log($scope.prices);

        });

        ggService.getAllTypes(false).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.types = result.data;
         //   console.log($scope.prices);

        });


        $scope.updateVenue = function(venue)
        {
            ggService.updateVenue(venue).then(function (result) {
               //  alert(result.data);
               

                ggService.getAllVenues().then(function (result) {
                    // alert(result.data);
                    // console.log(result.data);
                    $scope.venues = {};
                    $scope.venues = result.data;

                });

                console.log(venue);
                if (venue.add == true) {
                    venue = null;
                    $scope.addVenue = {}
                }



            
                //  console.log($scope.prices);

            });


         

           
        }


        $scope.toast = function () {
            ngToast.create({
                className: 'success',
                content: 'Venue Saved!',
                horizontalPosition: 'left'
            });

        }

        $scope.addPrice = function (venue, price) {

            if (price) {


                ggService.addPrice(venue, price).then(function (result) {

                    venue.selectedPrice = null;
                    venue.prices = result.data;

                });

            }


        };

        $scope.removePrice = function (venue, price) {

            if (price) {


                ggService.removePrice(venue, price).then(function (result) {

                 
                    venue.prices = result.data;

                });

            }


        };

        $scope.deleteVenue = function (venue) {

         


                ggService.deleteVenue(venue).then(function (result) {


                    if (result.data)
                    {

                        ngToast.create({
                            className: 'success',
                            content: 'Venue Deleted',
                            horizontalPosition: 'left'
                        });

                        ggService.getAllVenues().then(function (result) {
                            //  alert(result.data);
                            //  alert(JSON.stringify(result.data));
                            $scope.venues = result.data;

                        });

                    }
                      

                });


        };


        $scope.addType = function (venue, type) {

            if (type) {


                ggService.addType(venue, type).then(function (result) {

                    venue.selectedType = null;
                    venue.types = result.data;

                });

            }


        };

        $scope.removeType = function (venue, type) {

            if (type) {


                ggService.removeType(venue, type).then(function (result) {


                    venue.types = result.data;

                });

            }


        };

        $scope.addTag = function (venue, tag) {

            if (tag) {


                ggService.addTag(venue, tag).then(function (result) {

                    venue.selectedTag = null;
                    venue.tags = result.data;

                });

            }


        };

        $scope.removeTag = function (venue, tag) {

            if (tag) {


                ggService.removeTag(venue, tag).then(function (result) {


                    venue.tags = result.data;

                });

            }


        };

        $scope.addTime = function (venue, time) {

            if (time) {


                ggService.addTime(venue, time).then(function (result) {

                    venue.selectedTime = null;
                    venue.times = result.data;

                });

            }


        };

        $scope.removeTime = function (venue, time) {

            if (time) {


                ggService.removeTime(venue, time).then(function (result) {


                    venue.times = result.data;

                });

            }


        };
       

        ggService.getAllTags(false).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.tags = result.data;
          //  console.log($scope.prices);

        });

        ggService.getAllTimes(false).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.times = result.data;
            console.log($scope.prices);

        });

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
        templateUrl: 'directives/admin/admin.html',
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