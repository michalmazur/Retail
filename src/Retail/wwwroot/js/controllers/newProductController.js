(function () {
    "use strict";

    var retailApp = angular.module('retailApp');

    retailApp.controller('NewProductController', function ($location, $routeParams, backend, $log) {

        var vm = this;
        vm.isBusy = false;
        vm.amount = 1;
        vm.barcode = null;
        vm.units = {};
        vm.unit = {};

        if ($routeParams.barcode > 0) {
            vm.barcode = $routeParams.barcode;
        }

        var onUnitsLoaded = function (units) {
            vm.units = units;
            vm.unit = vm.units[1];
        };

        var onProductAdded = function (product) {
            backend.clearCache();
            $location.path("products/" + product.id);
        };

        var onError = function (error) {
            $log.log(error);
            alert("An error has occurred. Please reload the page.");
        };

        function cleanup() {
            vm.isBusy = false;
        }

        vm.loadUnits = function () {
            vm.isBusy = true;
            backend.getUnits().then(onUnitsLoaded, onError).finally(cleanup);
        };

        vm.addProduct = function () {
            vm.isBusy = true;

            var product = {
                label: vm.label,
                barcode: vm.barcode,
                unitId: vm.unit.id,
                amount: vm.amount
            };

            backend.addProduct(product).then(onProductAdded, onError).finally(cleanup);
        };

        vm.loadUnits();
    });
})();
