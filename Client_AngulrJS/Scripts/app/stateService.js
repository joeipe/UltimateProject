(function () {

    var state = function ($http) {

        var getStates = function () {
            return $http.get("http://localhost:43075/api/State/GetStates");
        };

        var deleteState = function (stateID) {
            return $http.delete("http://localhost:43075/api/State/DeleteState?id=" + stateID)
        };

        var addState = function (stateName) {
            var data = {
                "ID": 0,
                "Name": stateName
            };

            return $http.post("http://localhost:43075/api/State/AddState", data)
        };

        var editState = function (stateID, stateName) {
            var data = {
                "ID": 0,
                "Name": stateName
            };

            return $http.put("http://localhost:43075/api/State/EditState?id=" + stateID, data)
        };

        return {
            getStates: getStates,
            deleteState: deleteState,
            addState: addState,
            editState: editState
        };
    };

    var module = angular.module("ultimateViewer");
    module.factory("state", state);

}());