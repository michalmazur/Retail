(function () {
    "use strict";

    var retailApp = angular.module('retailApp');

    retailApp.controller('MenuController', function ($location, backend, auth, $rootScope) {

        var vm = this;
        vm.user = {
            id: 0,
            username: ""
        };

        $rootScope.$on('login', function (event, data) {
            vm.user = data;
        });

        $rootScope.$on('logout', function (event, data) {
            vm.user = data;
            $location.path('auth');
        });

        vm.logout = function() {
            auth.logout();
        };

        auth.checkStatus();

    });
})();