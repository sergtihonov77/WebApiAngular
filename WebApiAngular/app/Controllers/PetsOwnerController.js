(function () {
    var PetsOwnerController = function ($scope, $http) {
        var GetOwners = function () {
            $http.get('http://localhost:52181/api/PetsOwner').then(function (response) {
                $scope.Owners = response.data;
            });
        };
        GetOwners();

        $scope.deleteOwner = function (ownerId) {
            $http.delete('http://localhost:52181/api/PetsOwner' + "/" + ownerId).then(function (response) {
                GetOwners();
            });
        };
    };
    petsApp.controller("PetsOwnerController", ["$scope", "$http", PetsOwnerController]);
}());