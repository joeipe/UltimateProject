(function () {

    var app = angular.module("ultimateViewer");

    var StateController = function ($scope, $location, state) {

        $scope.message = "State";

        var onGetStatesComplete = function (response) {
            $scope.states = response.data;
        };

        var getStates = function () {
            state.getStates().then(onGetStatesComplete);
        };

        var onDeleteStateComplete = function (reponse) {
            getStates();
        };

        $scope.deleteState = function (stateID) {
            var wantToDel = confirm("Are you sure you want to delete?");
            if (wantToDel) {
                state.deleteState(stateID).then(onDeleteStateComplete);
            }
            else
                return false;
        };

        $scope.btnAddState_Click = function () {
            $location.path("/newState");
        };

        $scope.editState = function (stateID, stateName) {
            $location.path('/editState/' + stateID + '/' + stateName);
        };

        getStates();

    };

    app.controller("StateController", StateController);

}());