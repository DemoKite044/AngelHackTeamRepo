var angelHackApp = angular.module("angelHackApp", []);

angelHackApp.controller("angelHackCtrl", function ($scope, $http) {

    $scope.search = function (keyword) {
  
        if (keyword == undefined || keyword == "")
        {
            $scope.result = "Please enter a location.";
            $scope.locations = new Object();
        }
        else
        {
            $http(
            {
                url: "/Home/Search?keyword=" + keyword,
                method: "GET"
            }).success(function (data) {
                if (data.length == 0)
                {
                    $scope.result = "Sorry, we can't find a toilet near your location.";
                    $scope.locations = new Object();
                }
                else
                {
                    $scope.result = "We suggest the following:";
                    $scope.locations = data;
                }
            });
        }
        
    };
});

angelHackApp.controller("addCtrl", function ($scope, $http) {
    $scope.add = function (location) {
        $http(
            {
                url: "/Home/Add",
                method: "POST",
                data: { location: location }
            }).success(function()
            {
                alert("success!");
            });
    }
});