angular.module("IgnorantItems", [])
    .controller("homeController", function($scope, $http) {
        $scope.allMatches = [];

        $scope.title = "Recent Matches";

        $http.get("/api/matches").success(function(data) {
            $scope.allMatches = data;
            var len = data.length;
            for (var i = 0; i < len; i++) {
                setMatchColor(data[i]);
            }
         });

        $scope.getMatchResultText = function(match) {
            return match.Won ? "Win" : "Loss";
        };

        $scope.getMatchResultColor = function(match) {
            return match.Won ? {"color": "#00b300"} : {"color": "#cc0000"};
        };
    });