
angular.module("IgnorantItems", [])
    .controller("matchController", function($scope, $http) {
        var matchId = window.backendParams.matchId;
        var durationInSeconds = window.backendParams.seconds;


        var getDuration = function(durationInSeconds) {
            var total = durationInSeconds;
            var hours = total / 3600;
            total -= (hours * 3600);
            var minutes = total / 60;
            total -= (minutes * 60);
            var seconds = total;
            
            $scope.durationText = (hours > 0) ? [hours, minutes, seconds].join("/") : minutes + "/" + seconds;
        }

        var getTitle = function(match) {
            var title = [match.ProName, ": "];
            if (match.Won) {
                title.push("Win");
            } else {
                title.push("Loss");
            }

            return title.join("");
        }

        $http.get("/api/matches/" + matchId).success(function(data) {
            $scope.match = data;
            $scope.imageName = data.Champion.Image.Full;
            $scope.title = getTitle(data);
            $scope.kills = data.Kills;
            $scope.deaths = data.Deaths;
            $scope.assists = data.Assists;
        });
    });
