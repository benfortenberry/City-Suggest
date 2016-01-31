/// <reference path="../angular.js" />
/// <reference path="Module.js" />

app.service('ggService', function ($http) {


    //this.debugAdmin = true;
    //this.debugREC = false;
    //this.debugAlumna = false;

    //change app mode
    this.updateAppMode = function (mode) {

        $location.path(mode.mode); // path not hash


        // Set Mode

        this.appMode = mode.mode;
    }

  


    this.searchVenue = function (searchVenue) {
        //  console.log(JSON.stringify(searchVenue));
        var request = $http({
            method: "post",
            url: "API/searchVenue",
            data: searchVenue
        });
        return request;
    };

    // Get All bidders
    this.getAllTimes = function (mixer) {

        if(mixer)
            return $http.get("api/allTimes_Mixer");
        else
            return $http.get("api/allTimes_Mixer");
    }

    // Get All bidders
    this.getAllVenues = function () {
        return $http.get("api/allVenues");
    }

    this.getAllTags = function (mixer) {
        if (mixer)
            return $http.get("api/allTags_Mixer");
        else
            return $http.get("api/allTags_Mixer");
    }

    this.getAllPrices = function (mixer) {
        if (mixer)
            return $http.get("api/allPrices_Mixer");
        else
            return $http.get("api/allPrices_Mixer");
    }

    this.getAllTypes = function (mixer) {
        if (mixer)
            return $http.get("api/allTypes_Mixer");
        else
            return $http.get("api/allTypes_Mixer");
    }

    //Get All content
    //this.getAllContent = function () {
    //    return $http.get("API/allContent");
    //}

    //Get All bidders
    //this.getAllSororities = function () {
    //    return $http.get("API/allSororities");
    //}

    //Get All bidders
    //this.getAllOrgs = function () {
    //    return $http.get("API/allAffiliates");
    //}

    //Get All bidders
    //this.getAllSchools = function () {
    //    return $http.get("API/allSchools");
    //}


    //this.searchAffiliate = function (searchVal) {
    //    return $http.get('API/searchAffiliates/' + searchVal, {
    //        params: {

    //        }
    //    }).then(function (response) {
    //        // alert(JSON.stringify(response));
    //        return response.data.map(function (item) {
    //            return item
    //        });
    //    });



    //};

    //this.searchSorority = function (searchVal) {
    //    return $http.get('API/searchSorority/' + searchVal, {
    //        params: {

    //        }
    //    }).then(function (response) {
    //        // alert(JSON.stringify(response));
    //        return response.data.map(function (item) {
    //            return item.SororityName;
    //        });
    //    });



    //};

    this.updateVenue = function (venue) {
        var request = $http({
            method: "put",
            url: "API/updateVenue",
            data: venue
        });
        return request;
    };

    this.deleteVenue = function (venue) {

        //  console.log(price);


        var request = $http({
            method: "put",
            url: "API/deleteVenue",
            data: venue
        });
        return request;
    };

    this.addPrice = function (venue, price) {

      //  console.log(price);

        venue.prices = [];

        if (price.id)
            venue.prices.push(price);
        else
            venue.prices.push({ id: null, priceText: price });

        var request = $http({
            method: "put",
            url: "API/addPrice",
            data: venue
        });
        return request;
    };

    this.removePrice = function (venue, price) {

      //  console.log(price);

        venue.prices = [];

       
            venue.prices.push(price);
       
        var request = $http({
            method: "put",
            url: "API/removePrice",
            data: venue
        });
        return request;
    };


    this.addType = function (venue, type) {

        //  console.log(price);

        venue.types = [];

        if (type.id)
            venue.types.push(type);
        else
            venue.types.push({ id: null, typeText: type });

        var request = $http({
            method: "put",
            url: "API/addType",
            data: venue
        });
        return request;
    };

    this.removeType = function (venue, type) {

        //  console.log(price);

        venue.types = [];


        venue.types.push(type);

        var request = $http({
            method: "put",
            url: "API/removeType",
            data: venue
        });
        return request;
    };


    this.addTag = function (venue, tag) {

        //  console.log(tag);

        venue.tags = [];

        if (tag.id)
            venue.tags.push(tag);
        else
            venue.tags.push({ id: null, tagText: tag });

        var request = $http({
            method: "put",
            url: "API/addTag",
            data: venue
        });
        return request;
    };

    this.removeTag = function (venue, tag) {

        //  console.log(tag);

        venue.tags = [];


        venue.tags.push(tag);

        var request = $http({
            method: "put",
            url: "API/removeTag",
            data: venue
        });
        return request;
    };

    this.addTime = function (venue, time) {

        //  console.log(time);

        venue.times = [];

        if (time.id)
            venue.times.push(time);
        else
            venue.times.push({ id: null, timeText: time });

        var request = $http({
            method: "put",
            url: "API/addTime",
            data: venue
        });
        return request;
    };

    this.removeTime = function (venue, time) {

        //  console.log(time);

        venue.times = [];


        venue.times.push(time);

        var request = $http({
            method: "put",
            url: "API/removeTime",
            data: venue
        });
        return request;
    };
    //this.removeUser = function (user) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/removeUser",
    //        data: user
    //    });
    //    return request;
    //};

    //this.updateContent = function (content) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/updateContent",
    //        data: content
    //    });
    //    return request;
    //};

    //this.updateOrg = function (org) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/updateOrg",
    //        data: org
    //    });
    //    return request;
    //};

    //this.removeOrg = function (org) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/removeOrg",
    //        data: org
    //    });
    //    return request;
    //};

    //this.updateSor = function (sor) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/updateSorority",
    //        data: sor
    //    });
    //    return request;
    //};

    //this.removeSorority = function (sor) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/removeSorority",
    //        data: sor
    //    });
    //    return request;
    //};

    //this.updateSch = function (sch) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/updateSchool",
    //        data: sch
    //    });
    //    return request;
    //};

    //this.removeSchool = function (sch) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/removeSchool",
    //        data: sch
    //    });
    //    return request;
    //};


    //this.changePassword = function (user) {
    //    var request = $http({
    //        method: "post",
    //        url: "API/changePassword",
    //        data: user
    //    });


    //    return request;
    //};

    //this.getInviteEmail = function () {

    //    var html = $http({
    //        method: "get",
    //        url: "API/getInviteEmail"
    //    });

    //    return html;

    //};


    //this.getHomeHTML = function () {

    //    var html = $http({
    //        method: "get",
    //        url: "API/getHomeHTML"
    //    });

    //    return html;

    //};

    //this.getHomeLowerMiddle = function () {

    //    var html = $http({
    //        method: "get",
    //        url: "API/getHomeLowerMiddle"
    //    });

    //    return html;

    //};

    //this.getHomeLowerLeft = function () {

    //    var html = $http({
    //        method: "get",
    //        url: "API/getHomeLowerLeft"
    //    });

    //    return html;

    //};

    //this.getHomeLowerRight = function () {

    //    var html = $http({
    //        method: "get",
    //        url: "API/getHomeLowerRight"
    //    });

    //    return html;

    //};

    //this.getRECEmail = function () {

    //    var html = $http({
    //        method: "get",
    //        url: "API/getRECEmail"
    //    });

    //    return html;

    //};



    //this.searchSchool = function (searchVal) {
    //    return $http.get('API/searchSchools/' + searchVal, {
    //        params: {

    //        }
    //    }).then(function (response) {
    //        // alert(JSON.stringify(response));
    //        return response.data.map(function (item) {
    //            return item.SchoolName;
    //        });
    //    });


    //};



    //this.searchAllSchool = function (searchVal) {
    //    return $http.get('https://inventory.data.gov/api/action/datastore_search?resource_id=38625c3d-5388-4c16-a30f-d105432553a4&q=' + searchVal, {
    //        params: {

    //        }
    //    }).then(function (response) {
    //        return response.data.result.records.map(function (item) {
    //            return item.INSTNM;
    //        });
    //    });
    //};




    // Get All Sororities

    //this.getSororities = function () {
    //    return $http.get("API/getSororities");
    //}



    //get  rush history for rec id
    //this.getMyRECs = function (user) {


    //    var request = $http({
    //        method: "post",
    //        url: "API/getMyRECs/",
    //        data: user

    //    });

    //    return request;
    //};



    //this.emailRecRequest = function (email) {
    //    // alert(email);
    //    // alert(JSON.stringify(email));
    //    var request = $http({
    //        method: "put",
    //        url: "API/emailRecRequest",
    //        data: email
    //    });
    //    return request;
    //};







    //create new user
    //this.postUser = function (user) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/postUser",
    //        data: user
    //    });
    //    return request;
    //};

    //this.disableUser = function (user) {
    //    var request = $http({
    //        method: "post",
    //        url: "API/disableUser",
    //        data: user
    //    });
    //    return request;
    //};

    //create new affiliate
    //this.postAffiliate = function (affiliate) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/postAffiliate",
    //        data: affiliate
    //    });
    //    return request;
    //};

    //create new school
    //this.postSchool = function (school) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/postSchool",
    //        data: affiliate
    //    });
    //    return request;
    //};

    //create new sorority
    //this.postSchool = function (sorority) {
    //    var request = $http({
    //        method: "put",
    //        url: "API/postSorority",
    //        data: sorority
    //    });
    //    return request;
    //};

    //check if email already exists
    //this.checkEmail = function (user) {
    //    var request = $http({
    //        method: "post",
    //        url: "API/checkEmail",
    //        data: user
    //    });
    //    return request;
    //};


    //check if email already exists
    //this.passwordReminder = function (user) {
    //    // alert(email);

    //    var request = $http({
    //        method: "post",
    //        url: "API/passwordReminder",
    //        data: user
    //    });
    //    return request;
    //};

    //this.getUserData = function (user) {
    //    // alert(email);

    //    var request = $http({
    //        method: "post",
    //        url: "API/getUserData",
    //        data: user
    //    });
    //    return request;
    //};

    //login
    //this.login = function (user) {
    //    var request = $http({
    //        method: "post",
    //        url: "API/login",
    //        data: user
    //    });
    //    return request;
    //};



    //this.toggleComplete = function (historyID) {
    //    return $http.post('API/toggleComplete/' + historyID, {
    //        params: {

    //        }
    //    }).then(function (response) {
    //        //  alert(JSON.stringify(response));
    //        return response.data;
    //    });
    //};


    //this.getOrgInfo = function (orgID) {
    //    return $http.post('API/getOrgInfo/' + orgID, {
    //        params: {

    //        }
    //    }).then(function (response) {

    //        return response.data;
    //    });
    //};



    //login
    //this.requestREC = function (historyEntry) {



    //    var request = $http({
    //        method: "post",
    //        url: "API/requestREC",
    //        data: historyEntry
    //    });
    //    return request;
    //};

    //this.sendEmail = function () {

    //    var request = $http({
    //        method: "post",
    //        url: "API/sendEmail"
    //    });
    //    return request;
    //};




});