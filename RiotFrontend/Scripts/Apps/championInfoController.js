angular.module("IgnorantItems", [])
    .controller("championInfoController", function($scope, $http) {
        var championId = window.backendParams.championId;
        $scope.allMatches = [];

        $http.get("/api/champions/" + championId).success(function(data) {
            $scope.allMatches = data;
            if (!data || data.length == 0) {
                $scope.title = "No data found for champion."
                jQuery(".matchContents").css("margin-top", "0");
            } else {
                $scope.title = data[0].Champion.Name;
                var champNameIndex = data[0].Champion.Image.Full.indexOf(".");
                var imageName = data[0].Champion.Image.Full.substring(0, champNameIndex) + "_0" + ".jpg";
                $scope.imageName = imageName;
            }

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