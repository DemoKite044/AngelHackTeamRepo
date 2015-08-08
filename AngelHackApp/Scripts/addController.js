var angelHackApp = angular.module("angelHackApp", []);

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