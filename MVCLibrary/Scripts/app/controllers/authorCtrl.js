/* 
    ----- Author List Controller -----
    */
angular.module('MVCLibrary.controllers', ['ngAnimate'])
    .controller('authorCtrl', ['$scope', '$location', 'authorAPIservice', function ($scope, $location, authorAPIservice) {

        $scope.status = null;
        $scope.nameFilter = null;

        var allTown = { "TownID": -1, "Name": "Show All" };
        $scope.selectedTown = allTown;

        // without this search will be done on all properties of model
        // we want only by its last name
        $scope.searchFilter = function (author) {
            var keyword = new RegExp($scope.nameFilter, 'i');
            return !$scope.nameFilter || keyword.test(author.LastName);
        }

        // AUTHOR SERVICE
        authorAPIservice.getAuthors()
            .success(function (response) {
                $scope.authors = response.Authors;
            })
            .error(function (error) {
                $scope.status = 'Unable to load authors: ' + error.message;
            });


        authorAPIservice.getTowns()
            .success(function (response) {
                $scope.towns = response.Towns;
              
                $scope.towns.splice(0, 0, allTown);
            })
            .error(function (error) {
                $scope.status = 'Unable to load towns: ' + error.message;
            });

        $scope.deleteAuthor = function (id) {
            authorAPIservice.deleteAuthor(id)
                .success(function (response) {
                    for (var i = 0; i < $scope.authors.length; i++) {
                        var town = $scope.authors[i];
                        if (id === author.AuthorID) {
                            $scope.authors.splice(i, 1);
                            break;
                        }
                    }
                })
                .error(function (error) {
                    $scope.status = 'Unable to delete town: ' + error.message;
                });
        };


        // Show particular author
        $scope.viewAuthor = function (id) {
            $location.path("/" + id);
        };



        // Show in view header
        $scope.authorsCount = {
            0: "There are no authors added. Please add new author!",
            1: "Only one author",
            other: "Currently {} authors in database!"
        }
    }]);
 
angular.module('MVCLibrary.filters', [])
    .filter('townFilter', [function() {
        return function (authors, selectedTown) {
            if (!angular.isUndefined(authors) && !angular.isUndefined(selectedTown) && selectedTown.TownID != -1)
            {
               
                var tempAuthors = [];
                angular.forEach(authors, function (author) {
                    angular.forEach(author.Towns, function (town) {
                        if (angular.equals(town.TownID, selectedTown.TownID))
                        {
                            tempAuthors.push(author);
                        }
                    });
                });
                return tempAuthors;
            } else
            {
                
                return authors;
            }
        }
    }]);