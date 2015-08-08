var angelHackApp = angular.module("angelHackApp", []);

angelHackApp.controller("contactCtrl", function ($scope, $http) {
    $scope.contact = function (name, message) {
        $http(
            {
                url: "/Home/Contact",
                method: "POST",
                data: { name: name, message:message }
            }).success(function()
            {
                alert("success!");
            });
    }
});