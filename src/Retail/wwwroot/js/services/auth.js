(function () {
    "use strict";

    var auth = function ($http, $rootScope) {

        var login = function (username, password) {
            return $http.post('/session', {username: username, password: password})
                .then(function (response) {
                    $rootScope.$broadcast("login", response.data);
                    return response.data;
                });
        };

        var logout = function () {
            return $http.delete('/session').then(function (response) {
                $rootScope.$broadcast("logout", {id: 0, username: ""});
            });
        };

        var profile = null;
        var checkStatus = function () {
            return $http.get('/session')
                .then(function (response) {
                        profile = {
                            id: response.data.id,
                            username: response.data.username
                        };
                        $rootScope.$broadcast("login", profile);
                        return profile;
                    }, function (error) {

                    }
                );
        };

        var isLoggedIn = function () {
            return !!profile;
        };

        return {
            login: login,
            logout: logout,
            checkStatus: checkStatus,
            isLoggedIn: isLoggedIn
        };
    };

    var retailApp = angular.module('retailApp');

    retailApp.factory("auth", auth);
})();