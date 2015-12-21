angular.module("IgnorantItems", [])
    .controller("championInfoController", function($scope, $http) {
        var championId = window.backendParams.championId;
        $scope.allMatches = [];

        $http.get("/api/champions/" + championId).success(function(data) {
            $scope.allMatches = data;
            $scope.title = data[0].Champion.Name;
         });

        $http.get("/api/static/summonerSpells").success(function (data) {
            $scope.summonerSpells = {};

            for (var el in data) {
                $scope.summonerSpells[data[el].Id] = data[el];
            }
        });

        $scope.getMatchResultText = function(match) {
            return match.Won ? "Win" : "Loss";
        };

        $scope.getMatchResultColor = function(match) {
            return match.Won ? {"color": "#00b300"} : {"color": "#cc0000"};
        };
    });