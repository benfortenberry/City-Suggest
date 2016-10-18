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


app.controller('ggController', function ($scope, $location, ggService, $filter, $uibModal, $log) {


    $scope.appMode = 'mixer';

    var adminValue = $location.search().admin;
    if (adminValue == 'true')
        $scope.appMode = 'admin';


    if (window.location.href.indexOf("admin") > -1) {
        $scope.appMode = 'admin';
    }

    $(document).ready(function () {
        if (window.location.href.indexOf("admin") > -1) {
            $scope.appMode = 'admin';
            ggService.appMode = 'admin'
        }
    });

   // console.log(adminValue);

    $scope.myInterval = 5000;
    $scope.noWrapSlides = false;
    var slides = $scope.slides = [];
    var currIndex = 0;


    ggService.getCarouselImages().then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.carouselImages = result.data;

    });

    ggService.getAllTimes(true).then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.times = result.data;

    });

    ggService.getAllPrices(true).then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.prices = result.data;

    });

    ggService.getAllTypes(true).then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.types = result.data;

    });

    ggService.getAllTags(true).then(function (result) {
        //  alert(result.data);
        //  alert(JSON.stringify(result.data));
        $scope.tags = result.data;

    });

    $scope.getMoreTypes = function () {

        ggService.getAllTypes(true).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.types = result.data;

        });

    }


    $scope.getMoreTags = function () {

        ggService.getAllTags(true).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.tags = result.data;

        });

    }


    $scope.getMoreTimes = function () {

        ggService.getAllTimes(true).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.times = result.data;

        });

    }


    $scope.getMorePrices = function () {

        ggService.getAllPrices(true).then(function (result) {
            //  alert(result.data);
            //  alert(JSON.stringify(result.data));
            $scope.prices = result.data;

        });

    }




    // List data and initial item
    //$scope.listItems = {
    //    xs: "Short",
    //    sm: "Tall",
    //    md: "Grande",
    //    lg: "Venti",
    //    xl: "Trenta"
    //}

    $scope.findVenue = function () {


        var venueSearch = { "time": $scope.currentTime, "tag": $scope.currentTag, "price": $scope.currentPrice, "type": $scope.currentType }
        //   alert(JSON.stringify(venueSearch));
        ggService.searchVenue(venueSearch).then(function (result) {
            //  alert(result.data);
            //     alert(JSON.stringify(result.data));

            $scope.appMode = "results";
            $scope.venues = result.data;

        });



    }


    $scope.currentTime = "anytime";
    $scope.currentPrice = "whatever";
    $scope.currentType = "random place";
    $scope.currentTag = "anything";

    // Natural Language Form control
    $scope.nlTimeOpen = false;
    $scope.nlTimeOpenToggle = function (index) {


        if (index && index != 'anytime') {

            $scope.currentTime = $filter('getById')($scope.times, index).timeText;
        }
        else
            $scope.currentTime = 'anytime';

        $scope.nlTimeOpen = !$scope.nlTimeOpen;
    };


    $scope.tryAgain = function () {

        $scope.results = 0;
        $scope.appMode = 'mixer';
        $scope.currentTime = 'anytime';
        $scope.currentPrice = 'whatever';
        $scope.currentTag = 'anything';
        $scope.currentType = 'random place';

    }





    $scope.nlPriceOpen = false;
    $scope.nlPriceOpenToggle = function (index) {


        if (index && index != 'whatever') {

            $scope.currentPrice = $filter('getById')($scope.prices, index).priceText;
        }
        else
            $scope.currentPrice = 'whatever';

        $scope.nlPriceOpen = !$scope.nlPriceOpen;
    };

    $scope.nlTypeOpen = false;
    $scope.nlTypeOpenToggle = function (index) {

        if (index && index != 'random place') {


            $scope.currentType = $filter('getById')($scope.types, index).typeText;
        }
        else
            $scope.currentType = 'random place';

        $scope.nlTypeOpen = !$scope.nlTypeOpen;
    };

    $scope.$watch(function () {
        return ggService.appMode;
    },
         function (value) {
             if (ggService.appMode != undefined)
                 $scope.appMode = ggService.appMode;


         }
     );

    $scope.animationsEnabled = true;

    $scope.open = function (venue) {

        $scope.venue = venue;

        //var modalInstance = $uibModal.open({
        //    animation: $scope.animationsEnabled,
        //    templateUrl: 'directives/venueModal.html?v=1',
        //    controller: 'ModalInstanceCtrl',
        //    size: 'lg',
        //    resolve: {
        //        venue: function () {
        //           return venue;
        //        }
        //    }
        //});

        //modalInstance.result.then(function (selectedItem) {
        //    $scope.selected = selectedItem;
        //}, function () {
        //    $log.info('Modal dismissed at: ' + new Date());
        //});
    };

    $scope.nlTagOpen = false;
    $scope.nlTagOpenToggle = function (index) {


        if (index && index != 'anything') {

            $scope.currentTag = $filter('getById')($scope.tags, index).tagText;
            console.log($scope.currentTag);
        }
        else
            $scope.currentTag = 'anything';

        $scope.nlTagOpen = !$scope.nlTagOpen;
    };

}

  );

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, venue) {

    //$scope.items = items;
    //$scope.selected = {
    //    item: $scope.items[0]
    //};
    $scope.venue = venue;

    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});