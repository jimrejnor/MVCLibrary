
// Filter used in /Author for sorting authors by selected town in dropdown list
angular.module('MVCLibrary.filters', [])
    .filter('townFilter', [function () {
        return function (authors, selectedTown) {
            if (!angular.isUndefined(authors) && !angular.isUndefined(selectedTown) && selectedTown.TownID != -1) {

                var tempAuthors = [];
                angular.forEach(authors, function (author) {
                    angular.forEach(author.Towns, function (town) {
                        if (angular.equals(town.TownID, selectedTown.TownID)) {
                            tempAuthors.push(author);
                        }
                    });
                });
                return tempAuthors;
            } else {

                return authors;
            }
        }
    }]);
