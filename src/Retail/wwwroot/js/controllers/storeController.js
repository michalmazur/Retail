(function () {
    "use strict";

    var retailApp = angular.module('retailApp');

    retailApp.controller('StoreController', function ($location, backend, $log) {

        var vm = this;
        vm.stores = [];
        vm.isBusy = false;

        var showLoader = function () {
            vm.isBusy = false;
        };

        var onFinally = function () {
            vm.isBusy = false;
        };

        var onError = function (error) {
            $log.log(error);
            alert("An error has occurred. Please reload the page.");
        };

        var onStoresLoaded = function (stores) {
            angular.copy(stores, vm.stores);
        };

        var onStoreSaved = function () {
            $location.path('stores');
        };

        vm.loadStores = function () {
            showLoader();
            backend.getStores().then(onStoresLoaded, onError).finally(onFinally);
        };

        vm.addStore = function () {
            showLoader();
            var store = {
                label: vm.label
            };
            backend.addStore(store).then(onStoreSaved, onError).finally(onFinally);
        };

        vm.loadStores();
    });
})();