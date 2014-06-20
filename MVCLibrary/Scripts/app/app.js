
angular.module('MVCLibrary', [

    'ngRoute',
    'MVCLibrary.controllers',
    'MVCLibrary.services',
    'MVCLibrary.animations',
    'MVCLibrary.filters',

]);
       //.config(['$routeProvider', function ($routeProvider) {

       //    $routeProvider.
       //         when("/Town", { templateUrl: "/Views/Town/Index", controller: "townCtrl" }).
       //         when("/Town/:id", { templateUrl: "", controller: "townDetailCtrl" }).
       //         otherwise({ redirectTo: '/Town' });

       //}]);