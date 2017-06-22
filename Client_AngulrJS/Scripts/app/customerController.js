(function () {

    var app = angular.module("ultimateViewer");

    var CustomerController = function ($scope, customer) {
        $scope.message = "Customer";

        var onGetAllCountriesComplete = function (reponse) {
            $scope.countries = reponse.data;
        };

        var getAllCountries = function () {
            customer.getAllCountries().then(onGetAllCountriesComplete);
        };

        var onGetAllCustomersComplete = function (reponse) {
            $scope.customers = reponse.data;
        };

        var getAllCustomers = function () {
            customer.getAllCustomers().then(onGetAllCustomersComplete);
        };

        var onGetCustomersByCountryComplete = function (response) {
            $scope.customers = response.data;
        };

        $scope.getCustomersByCountry = function () {
            customer.getCustomersByCountry($scope.selectedCountry).then(onGetCustomersByCountryComplete)
        };
        getAllCountries();
        $scope.selectedCountry = "--Select--";
        getAllCustomers();
    };

    app.controller("CustomerController", CustomerController);

}());