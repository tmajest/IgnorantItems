
angular.module("IgnorantItems", ['ui.bootstrap'])
    .controller("matchController", function($scope, $http) {
        var matchId = window.backendParams.matchId;

        var getDuration = function(durationInSeconds) {
            var total = durationInSeconds;
            var hours = parseInt(total / 3600, 10);
            total -= (hours * 3600);
            var minutes = parseInt(total / 60, 10);
            total -= (minutes * 60);
            var seconds = parseInt(total, 10);
            
            return hours > 0
                ? hours + "h " + minutes + "m " + seconds + "s"
                : minutes + "m " + seconds + "s";
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

        var setMasteries = function() {
            var len = $scope.match.Masteries.length;
            for (var i = 0; i < len; i++) {
                var mastery = $scope.match.Masteries[i];
                if (mastery.Rank === 0) {
                    continue;
                }

                var selector = "#f" + mastery.Data.Id + " img";
                var image = jQuery(selector);
                if (!image) {
                    continue;
                }

                $scope.masteryDescription[mastery.Data.Id] = mastery.Data.SanitizedDescription[mastery.Rank - 1];

                image.css("-webkit-filter", "none");
                image.css("border", "2px solid #FFF5A6");

                var parentDiv = image.parent();
                var rankText = mastery.Rank + "/" + mastery.Data.Ranks;
                parentDiv.append("<span class='masteryRank'>" + rankText + "</span>");
            }
        }

        $http.get("/api/matches/" + matchId).success(function(data) {
            $scope.match = data;
            $scope.imageName = data.Champion.Image.Full;
            $scope.title = getTitle(data);
            $scope.kills = data.Kills;
            $scope.deaths = data.Deaths;
            $scope.assists = data.Assists;
            $scope.durationText = getDuration(data.MatchDuration);
            setMasteries();
        });

        $http.get("/api/static/masteries").success(function(data) {
            $scope.masteries = data;
            $scope.masteryDescription = {};
            var len = data.length;
            for (var key in data) {
                if (data.hasOwnProperty(key)) {
                    var mastery = data[key];
                    $scope.masteryDescription[mastery.Id] = mastery.SanitizedDescription[mastery.SanitizedDescription.length - 1];
                }
            }
        });
    });
