(function () {

    var app = angular.module("ultimateViewer");

    var StateTemplateController = function ($scope, $window, $location, $routeParams, state) {

        $scope.message = "State Template";

        if ($routeParams.stateID && $routeParams.stateName) {
            $scope.txtStateName = $routeParams.stateName;
        }

        $scope.btnCancel_Click = function () {
            $window.history.back();
        };

        var onAddStateComplete = function (response) {
            $location.path('/State');
        };

        $scope.btnSubmit_Click = function () {
            if ($routeParams.stateID) {
                state.editState($routeParams.stateID, $scope.txtStateName)
                     .then(function (response) {
                         $location.path('/State');
                     });
            }
            else {
                state.addState($scope.txtStateName).then(onAddStateComplete);
            }
        };
    };

    app.controller("StateTemplateController", ["$scope", "$window", "$location", "$routeParams", "state", StateTemplateController]);

}());