(function () {
    "use strict";

    var retailApp = angular.module('retailApp');

    retailApp.controller('ProductListController', function (backend, keywordTracker, $log) {

        var vm = this;
        vm.units = {};
        vm.products = [];
        vm.maxItems = 50;
        vm.keyword = keywordTracker.get();

        var onProductsLoaded = function (products) {
            vm.products = angular.copy(products, vm.products);
        };

        var onUnitsLoaded = function (units) {
            vm.units = units;
        };

        var onError = function (error) {
            $log.log(error);
            alert("An error has occurred. Please reload the page.");
        };

        var loadProducts = function (forceRefresh) {
            backend.getProducts(forceRefresh).then(onProductsLoaded, onError);
        };

        vm.setKeyword = function (keyword) {
            keywordTracker.set(keyword);
        };

        vm.refresh = function () {
            loadProducts(true);
        };

        loadProducts(false);
        backend.getUnits().then(onUnitsLoaded, onError);
    });
})();
