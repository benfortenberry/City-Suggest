/// <reference path="../angular.js" />


/// <reference path="Module.js" />

//The controller is having 'ggService' dependency.
//This controller makes call to methods from the service 

app.run(function ($rootScope, $location, ggService) {
    var joinOrgID = $location.search().joinorg;
    if (joinOrgID != null) {
        // alert('rad');

        //  $scope.appMode = 'sign-up';
        ggService.joinOrgID = joinOrgID;
        // ggService.updateAppMode('sign-up');
    }


});


app.controller('ggController', function ($scope, $location, ggService, $filter) {

    
    ggService.getAllTimes().then(function (result) {
      //  alert(result.data);
     //  alert(JSON.stringify(result.data));
        $scope.times = result.data;

    });

    ggService.getAllPrices().then(function (result) {
        //  alert(result.data);
       //  alert(JSON.stringify(result.data));
        $scope.prices = result.data;

    });

    ggService.getAllTypes().then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.types = result.data;

    });

    ggService.getAllTags().then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.tags = result.data;

    });

    // List data and initial item
    //$scope.listItems = {
    //    xs: "Short",
    //    sm: "Tall",
    //    md: "Grande",
    //    lg: "Venti",
    //    xl: "Trenta"
    //}
    $scope.currentTime = "anytime";
    $scope.currentPrice = "whatever";
    $scope.currentType = "random place";
    $scope.currentTag = "anything";

    // Natural Language Form control
    $scope.nlTimeOpen = false;
    $scope.nlTimeOpenToggle = function (index) {
       
      
        if (index) {
         
            $scope.currentTime = $filter('getById')($scope.times, index).timeText;
        }
        $scope.nlTimeOpen = !$scope.nlTimeOpen;
    };


    $scope.nlPriceOpen = false;
    $scope.nlPriceOpenToggle = function (index) {


        if (index) {

            $scope.currentPrice = $filter('getById')($scope.prices, index).priceText;
        }
        $scope.nlPriceOpen = !$scope.nlPriceOpen;
    };

    $scope.nlTypeOpen = false;
    $scope.nlTypeOpenToggle = function (index) {


        if (index) {

            $scope.currentType = $filter('getById')($scope.types, index).typeText;
        }
        $scope.nlTypeOpen = !$scope.nlTypeOpen;
    };

    $scope.nlTagOpen = false;
    $scope.nlTagOpenToggle = function (index) {


        if (index) {

            $scope.currentTag = $filter('getById')($scope.tags, index).tagText;
        }
        $scope.nlTagOpen = !$scope.nlTagOpen;
    };
    $scope.changeView = function (view) {

    }

    $scope.$watch(function () {
        return ggService.joinOrgID;
    },
        function (value) {
            if (ggService.joinOrgID != null) {
                ggService.appMode = 'sign-up';
            }
        }
    )




    if (ggService.debugAdmin == true) {
        $scope.inputEmail = "admin@sororityrecommendations.com";
        $scope.inputPassword = "rushrecs2015!";


    }

    if (ggService.debugREC == true) {
        $scope.inputEmail = "ben@benfortenberry.com";
        $scope.inputPassword = "purplefink";

    }

    if (ggService.debugAlumna == true) {
        $scope.inputEmail = "benfortenberry@outlook.com";
        $scope.inputPassword = "purplefink";

    }


    $scope.$watch(function () {
        return $location.path();
    }, function (value) {

        // value = value.replace("/", "");
        //// console.log(value);
        // if (value == "#" || value == "" || value == "/" || value == "home")

        //   //  $scope.updateAppMode('#');

        // else {
        //     if (value != '~') {

        //         $scope.updateAppMode(value);
        //     }
        // }


    }
    );






    $location.path('');





    $scope.IsLoggedIn = false;


    $scope.Logout = function () {
        ggService.user = 0;
        $scope.isLoggedIn = false;
        $scope.user = null;
        $scope.updateAppMode('#');
        ggService.appMode = '#';
        ggService.user = null;

        var modalInstance = $modal.open({
            templateUrl: 'LogoutModal.html',
            controller: 'LogoutInstanceCtrl',

            backdrop: 'static',
            resolve: {


                //selectedFormType: function () {
                //    return $scope.selectedFormType;
                //}
            }
        });


    }


    $scope.contactus = function () {
        ggService.emailType = 'c';

    }

    $scope.Login = function (inputEmail, inputPassword) {


        //  alert(inputEmail + ' ' + inputPassword);

        if ($scope.loginForm.$valid) {

            var user = {

                EmailAddress: inputEmail,

                Password: inputPassword

            };

            var result = ggService.login(user)
                .then(function (result) {

                    // alert(result.data);

                    if (result.data.UserID == 0) {
                        $scope.loginError = true;
                        $scope.inputEmail = "";
                        $scope.inputPassword = "";

                    }
                    else {
                        $scope.inputEmail = "";
                        $scope.inputPassword = "";

                        $scope.isLoggedIn = true;
                        $scope.loginError = false;

                        $scope.user = result.data;
                        ggService.user = result.data;



                    }




                }

        )
        }

    };

    //$scope.$watch('location.url()', function (url) {

    //    if (url.substring(1) == "#")

    //        updateAppMode('home')

    //else
    //    updateAppMode(url.substring(1))

    //});



    $scope.appMode = '#';
    ggService.appMode = '#';

    $scope.$watch(function () {
        return ggService.user;
    }, function (newVal, oldVal) {
        $scope.user = ggService.user;
        if ($scope.user != null) {
            $scope.isLoggedIn = true;
            $scope.loginError = false;
        }

    });


    $scope.$watch(function () {
        return ggService.appMode;
    }, function (newVal, oldVal) {
        $scope.appMode = ggService.appMode;

    });


    $scope.updateAppMode = function (mode) {

        $location.path(mode); // path not hash
        ggService.appMode = mode;

        // Set Mode
        $scope.appMode = mode;


    }


});



app.controller('LogoutInstanceCtrl', ['$scope', '$modalInstance', function ($scope, $modalInstance) {


    $scope.ok = function () {
        $modalInstance.close();
    };


    $scope.Cancel = function () {
        $modalInstance.dismiss();
    };
}]);