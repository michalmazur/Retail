(function () {
    "use strict";

    var retailApp = angular.module('retailApp');

    retailApp.controller('AuthController', function (auth, $location, $rootScope) {

        var vm = this;
        vm.profile = null;
        vm.username = "demo";
        vm.password = "demo";
        vm.message = "";

        $rootScope.$on('logout', function (event, data) {
            vm.profile = data;
        });

        $rootScope.$on('login', function (event, data) {
            vm.profile = data;
        });

        vm.login = function () {
            vm.message = "";
            vm.isBusy = true;
            auth.login(vm.username, vm.password).then(function (profile) {
                vm.profile = profile;
                $location.path('products');
            }, function () {
                vm.message = "Invalid username or password.";
            }).finally(function () {
                vm.isBusy = false;
            });
        };

        auth.checkStatus();
    });
})();