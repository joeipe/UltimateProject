(function () {

    var customer = function ($http) {
        var getAllCountries = function () {
            return $http.get("http://localhost:43075/api/Customer/GetAllCountries");
        };

        var getAllCustomers = function () {
            return $http.get("http://localhost:43075/api/Customer/GetAllCustomers");
        };

        var getCustomersByCountry = function (selectedCountry) {
            return $http.get("http://localhost:43075/api/Customer/GetCustomersByCountry?country=" + selectedCountry)
        };

        return {
            getAllCountries: getAllCountries,
            getAllCustomers: getAllCustomers,
            getCustomersByCountry: getCustomersByCountry
        };
    };

    var module = angular.module("ultimateViewer");
    module.factory("customer", customer);

}());