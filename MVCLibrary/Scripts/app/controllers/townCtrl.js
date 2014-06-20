/* 
    ----- Town List Controller -----
    */
angular.module('MVCLibrary.controllers', ['ngAnimate'])
    .controller('townCtrl', ['$scope', '$location', 'townAPIservice', function ($scope, $location, townAPIservice) {

        $scope.status = null;
        $scope.nameFilter = null;

        // without this search will be done on all properties of model
        // we want only by its name
        $scope.searchFilter = function (town) {
            var keyword = new RegExp($scope.nameFilter, 'i');
            return !$scope.nameFilter || keyword.test(town.Name);
        }

        // TOWN SERVICE
        townAPIservice.getTowns()
            .success(function (response) {
                $scope.towns = response.Towns;
            })
            .error(function (error) {
                $scope.status = 'Unable to load towns: ' + error.message;
        });

        $scope.deleteTown = function (id) {
            townAPIservice.deleteTown(id)
                .success(function (response) {
                    for (var i = 0; i < $scope.towns.length; i++)
                    {
                        var town = $scope.towns[i];
                        if (id === town.TownID)
                        {
                            $scope.towns.splice(i, 1);
                            break;
                        }
                    }
                })
                .error(function (error) {
                    $scope.status = 'Unable to delete town: ' + error.message;
                });
        };


        // Show particular town
        $scope.viewTown = function (id) {
            $location.path("/" + id);
        };



        // Show in view header
        $scope.townsCount = {
            0: "There are no towns added. Please add new town!",
            1: "Only one town in database",
            other: "Currently {} towns in database!"
        }
    }]);

/* 
    ----- Town Detail Controller -----
    */
//angular.module('MVCLibrary.controllers', [])
//    .controller('townDetailCtrl', ['$scope', '$routeParams', '$location', 'townAPIservice', function ($scope, $routeParams, $location, townAPIservice) {

//        $scope.id = $routeParams.id;

//        // Back to list
//        $scope.returnToList = function () {
//            $location.path("/");
//        };

//        townAPIservice.getTownDetail($scope.id).success(function (response) {
//            $scope.town = response;
//        });

//    }]);