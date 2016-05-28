(function () {
    "use strict";

    var keywordTracker = function ($log) {

        var keyword;

        var set = function (newValue) {
            $log.log("Keyword set to: " + newValue);
            keyword = newValue;
        };

        var get = function () {
            $log.log("Keyword retrieved: " + keyword);
            return keyword;
        };

        return {
            get: get,
            set: set
        };
    };

    var retailApp = angular.module('retailApp');

    retailApp.factory("keywordTracker", keywordTracker);
})();