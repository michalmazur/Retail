(function () {

    "use strict";

    var retailApp = angular.module('retailApp', ['ngRoute', 'ngResource', 'ngCookies', 'myDirectives']);

    retailApp.config(function ($routeProvider) {
        $routeProvider.when('/auth', {
            templateUrl: 'partials/login.html',
            controller: 'AuthController',
            controllerAs: 'vm'
        }).when('/stores', {
            templateUrl: 'partials/store-list.html',
            controller: 'StoreController',
            controllerAs: 'vm'
        }).when('/stores/add', {
            templateUrl: 'partials/store-add.html',
            controller: 'StoreController',
            controllerAs: 'vm'
        }).when('/products', {
            templateUrl: 'partials/product-list.html',
            controller: 'ProductListController',
            controllerAs: 'vm'
        }).when('/products/add', {
            templateUrl: 'partials/product-add.html',
            controller: 'NewProductController',
            controllerAs: 'vm'
        }).when('/products/add/:barcode', {
            templateUrl: 'partials/product-add.html',
            controller: 'NewProductController',
            controllerAs: 'vm'
        }).when('/products/:barcode', {
            templateUrl: 'partials/product-view.html',
            controller: 'ProductController',
            controllerAs: 'vm'
        }).otherwise({
            redirectTo: '/auth'
        });
    });
})();