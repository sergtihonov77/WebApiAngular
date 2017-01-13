(function () {
    var CreatePetsOwnerController = function ($scope, $http, $window, $route) {

        $scope.createOwner = function () {
            var owner = {
                Name: $scope.ownerName
            };
            $http.post('http://localhost:52181/api/PetsOwner', owner).then(function (response) {
                $window.alert("User" + " " + $scope.ownerName + " " + "has been added!").$route.reload(true);
            });
        };
    };
    petsApp.controller("CreatePetsOwnerController", ["$scope", "$http", "$window", "$route", CreatePetsOwnerController]);
}());