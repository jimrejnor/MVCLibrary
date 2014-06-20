
angular.module('MVCLibrary.services', [])
    .factory('townAPIservice', ['$http', function ($http) {

        var townAPI = {};
        var baseURL = '/Town';

        townAPI.getTowns = function () {
            return $http.get(baseURL + '/GetTowns');
        }

        townAPI.deleteTown = function (id) {
            return $http.delete(baseURL + '/' + id);
        }

        townAPI.getTownDetail = function (id) {
            return $http({
                method: 'GET',
                url: '/Town/' + id
            });
        }

        return townAPI;
}]);