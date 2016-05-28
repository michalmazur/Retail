(function () {
    "use strict";

    var retailApp = angular.module('retailApp');

    retailApp.controller('ProductController', function ($routeParams, backend, $location, storeTracker, $log) {

        var vm = this;
        vm.editMode = false;
        vm.isBusy = true;
        vm.units = {};
        vm.selectedUnit = {};
        vm.stores = {};
        vm.store = {};
        vm.prices = [];
        vm.newPrice = {};

        vm.toggleEditMode = function () {
            vm.editMode = !vm.editMode;
        };

        vm.onUnitSelected = function () {
            vm.product.unitId = vm.selectedUnit.id;
        };

        vm.update = function () {
            backend.updateProduct(vm.product.id, vm.product).then(onProductUpdated, onError);
        };

        vm.deleteProduct = function () {
            backend.deleteProduct(vm.product.id).then(onProductDeleted, onError);
        };

        vm.addPrice = function () {
            storeTracker.set(vm.store.id);

            vm.newPrice.storeId = vm.store.id;
            vm.newPrice.productId = vm.product.id;

            vm.isBusy = true;
            backend.addPrice(vm.product.id, vm.newPrice).then(loadPrices, onError).finally(cleanup);
        };

        vm.delete = function (id) {
            backend.deletePrice(vm.product.id, id).then(loadPrices, onError);
        };

        var onUnitsLoaded = function (units) {
            vm.units = units;
            backend.getProduct($routeParams.barcode).then(onProductLoaded, onError);
        };

        var onProductLoaded = function (product) {
            vm.product = product;
            vm.selectedUnit = vm.units[product.unitId];
        };

        var onProductUpdated = function () {
            vm.toggleEditMode();
        };

        var onProductDeleted = function () {
            backend.clearCache();
            $location.path('products');
        };

        var onPricesLoaded = function (prices) {
            vm.prices = prices;
        };

        var onStoresLoaded = function (stores) {
            vm.stores = stores;
            vm.store = vm.stores[storeTracker.get()];
        };

        var onError = function (error) {
            $log.log(error);
            alert("An error has occurred. Please reload the page.");
        };

        var cleanup = function () {
            vm.isBusy = false;
        };

        var loadPrices = function () {
            backend.getPrices($routeParams.barcode).then(onPricesLoaded, onError).finally(cleanup);
        };

        var loadStores = function () {
            backend.getStoresIndexedById().then(onStoresLoaded, onError).finally(cleanup);
        };

        backend.getUnits().then(onUnitsLoaded, onError);
        loadPrices();
        loadStores();
    });
})();
