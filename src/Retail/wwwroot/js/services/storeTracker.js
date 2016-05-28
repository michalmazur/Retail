(function () {
    "use strict";

    var storeTracker = function ($cookies, $log) {

        var set = function (newValue) {
            $log.log("Store set to: " + newValue);
            $cookies.put('lastStoreId', newValue);
        };

        var get = function () {
            var lastStoreId = $cookies.get('lastStoreId');
            $log.log("Store retrieved: " + lastStoreId);
            return lastStoreId;
        };

        return {
            get: get,
            set: set
        };
    };

    var retailApp = angular.module('retailApp');

    retailApp.factory("storeTracker", storeTracker);
})();