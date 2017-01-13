(function () {
    var PetsController = function ($scope, $http, $routeParams) {
        var ownId = $routeParams.id;
        var GetPets = function () {
            $http.get('http://localhost:52181/api/Pets' +"/"+ ownId).then(function (response) {
                $scope.Pets = response.data;
                $scope.pid = ownId;
            });
        };
        GetPets();
    };
    petsApp.controller("PetsController", ["$scope", "$http", "$routeParams", PetsController]);
}());