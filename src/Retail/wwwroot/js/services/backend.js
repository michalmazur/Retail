(function () {
    "use strict";

    var backend = function ($http, $q) {

        var getStores = function () {
            return $http.get("/stores")
                .then(function (response) {
                    return response.data;
                });
        };

        var getStoresIndexedById = function () {
            return $http.get("/stores")
                .then(function (response) {
                    var stores = {};
                    angular.forEach(response.data, function (store) {
                        stores[store.id] = store;
                    });
                    return stores;
                });
        };

        var addStore = function (store) {
            return $http.post('/stores', store)
                .then(function (response) {
                    return response.data;
                });
        };

        var products = null;
        var getProducts = function (forceRefresh) {
            if (forceRefresh) {
                products = null;
            }
            if (products) {
                // see http://stackoverflow.com/a/30779102/322269
                return $q.resolve(products);
            } else {
                return $http.get("/products")
                    .then(function (response) {
                        products = response.data;
                        return products;
                    });
            }
        };

        var getProduct = function (id) {
            return $http.get('/products/' + id)
                .then(function (response) {
                    if (!response.data.barcode) {
                        response.data.barcode = null;
                    } else {
                        response.data.barcode = parseInt(response.data.barcode);
                    }
                    return response.data;
                });
        };

        var addProduct = function (product) {
            return $http.post('/products', product)
                .then(function (response) {
                    return response.data;
                });
        };

        var updateProduct = function (id, product) {
            return $http.put('/products/' + id, product)
                .then(function (response) {
                    return response.data;
                });
        };

        var deleteProduct = function (id) {
            return $http.delete('/products/' + id)
                .then(function (response) {
                    return response.data;
                });
        };

        var units = null;
        var getUnits = function () {
            if (units) {
                return $q.resolve(units);
            } else {
                return $http.get("/units")
                    .then(function (response) {
                        units = {};
                        angular.forEach(response.data, function (value, key) {
                            units[value.id] = {label: value.label, id: value.id};
                        });
                        return units;
                    });
            }
        };

        var clearCache = function () {
            units = null;
            products = null;
        };

        var getPrices = function (productId) {
            return $http.get('/products/' + productId + '/prices')
                .then(function (response) {
                    return response.data;
                });
        };

        var addPrice = function (productId, price) {
            return $http.post('/products/' + productId + '/prices', price)
                .then(function (response) {
                    return response.data;
                });
        };

        var deletePrice = function (productId, priceId) {
            return $http.delete('/products/' + productId + '/prices/' + priceId)
                .then(function (response) {
                    return response.data;
                });
        };

        return {
            getStores: getStores,
            getStoresIndexedById: getStoresIndexedById,
            addStore: addStore,
            getProduct: getProduct,
            getProducts: getProducts,
            addProduct: addProduct,
            updateProduct: updateProduct,
            deleteProduct: deleteProduct,
            getUnits: getUnits,
            getPrices: getPrices,
            addPrice: addPrice,
            deletePrice: deletePrice,
            clearCache: clearCache
        };
    };

    var retailApp = angular.module('retailApp');

    retailApp.factory("backend", backend);
})();