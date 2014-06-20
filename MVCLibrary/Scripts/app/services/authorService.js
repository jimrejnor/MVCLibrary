



angular.module('MVCLibrary.services', [])
    .factory('authorAPIservice', ['$http', function ($http) {

        var authorAPI = {};
        var baseURL = '/Author';

        authorAPI.getAuthors = function () {
            return $http.get(baseURL + '/GetAuthors');
        }

        authorAPI.getTowns = function () {
            return $http.get(baseURL + '/GetTowns');
        }

        authorAPI.deleteAuthor = function (id) {
            return $http.delete(baseURL + '/Delete/' + id);
        }

        authorAPI.getAuthorDetail = function (id) {
            return $http({
                method: 'GET',
                url: '/Author/' + id
            });
        }

        return authorAPI;
    }]);