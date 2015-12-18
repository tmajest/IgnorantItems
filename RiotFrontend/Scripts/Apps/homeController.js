angular.module("IgnorantItems", [])
    .controller("homeController", function($scope, $http) {
        $scope.allMatches = [];

        $scope.title = "Recent Matches";

        $http.get("/matches").success(function(data) {
            $scope.allMatches = data;
         });

        $scope.getMatchResultText = function(match) {
            return match.Won ? "Win" : "Loss";
        };

        $scope.getMatchResultColor = function(match) {
            return match.Won ? "{'color': '#00b300'}" : "{'color': '#cc0000'}";
        };
    });