(function () {
    "use strict";

    angular.module("myDirectives", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            scope: {
                show: "=displayWhen"
            },
            templateUrl: "/directives/waitCursor.html",
            restrict: 'E'
        };
    }
})();