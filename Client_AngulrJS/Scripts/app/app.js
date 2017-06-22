(function () {

    var app = angular.module("ultimateViewer", ["ngRoute", "ui.bootstrap"]);

    app.config(["$routeProvider",
        function ($routeProvider) {
        $routeProvider
            .when("/Customer", {
                templateUrl: "Customer.html",
                controller: "CustomerController"
            })
            .when("/State", {
                templateUrl: "State.html",
                controller: "StateController"
            })
            .when("/newState", {
                templateUrl: "StateTemplate.html",
                controller: "StateTemplateController"
            })
            .when("/editState/:stateID/:stateName", {
                templateUrl: "StateTemplate.html",
                controller: "StateTemplateController"
            })
            .otherwise({ redirectTo: "/Customer" });
    }]);

}());