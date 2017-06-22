(function () {

    var app = angular.module("ultimateViewer", ["ngRoute", "ui.bootstrap"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/Customer", {
                templateUrl: "app/Customer.html",
                controller: "CustomerController"
            })
            .when("/State", {
                templateUrl: "app/State.html",
                controller: "StateController"
            })
            .when("/newState", {
                templateUrl: "app/StateTemplate.html",
                controller: "StateTemplateController"
            })
            .when("/editState/:stateID/:stateName", {
                templateUrl: "app/StateTemplate.html",
                controller: "StateTemplateController"
            })
            .otherwise({ redirectTo: "/Customer" });
    });

}());