(function () {
    var CreatePetsController = function ($scope, $http, $window) {
        $scope.createPet = function () {
            var pets = {};
            pets.Name = $scope.petName;
            pets.OwnerId = 1;
 
            $http.post('http://localhost:52181/api/Pets', pets).then(function (response) {
                $window.alert("Pet" + " " + $scope.petName + " " + "has been added!");
                console.log($scope.petName);
                console.log(pets);
                $scope.petName = "";
            });
        };
    };
    petsApp.controller("CreatePetsController", ["$scope", "$http", "$window", CreatePetsController]);
}());