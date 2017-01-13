var petsApp = angular.module('petsApp', ["ngRoute","solo.table"]);

petsApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: 'app/Views/PetsOwner/Index.html',
            controller: 'PetsOwnerController'
        })
        .when("/Pets/:id", {
            templateUrl: 'app/Views/Pets/Pets.html',
            controller: 'PetsController'
        })
         .otherwise({
             templateUrl: '/',
             controller: 'PetsOwnerController'
         })


});