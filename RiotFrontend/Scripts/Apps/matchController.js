
angular.module("IgnorantItems", ['ui.bootstrap'])
    .controller("matchController", function($scope, $http, $q) {
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

        var setMasteriesToolTip = function() {
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

        var matchesFunc = function() {
            var d = $q.defer();
            $http.get("/api/matches/" + matchId).then(function(data) {
                d.resolve(data);
            });
            return d.promise;
        }

        var masteriesFunc = function() {
            var d = $q.defer();
            $http.get("/api/static/masteries").then(function(data) {
                d.resolve(data);
            });
            return d.promise;
        }

        var setMatchInfo = function(match) {
            $scope.match = match;
            $scope.imageName = match.Champion.Image.Full;
            $scope.title = getTitle(match);
            $scope.kills = match.Kills;
            $scope.deaths = match.Deaths;
            $scope.assists = match.Assists;
            $scope.durationText = getDuration(match.MatchDuration);
            $scope.spell1Id = match.Spell1Id;
            $scope.spell2Id = match.Spell2Id;
        }

        var setMasteryInfo = function(masteries) {
            $scope.masteries = masteries;
            $scope.masteryDescription = {};
            var len = masteries.length;
            for (var key in masteries) {
                if (masteries.hasOwnProperty(key)) {
                    var mastery = masteries[key];
                    $scope.masteryDescription[mastery.Id] = mastery.SanitizedDescription[mastery.SanitizedDescription.length - 1];
                }
            }
            setMasteriesToolTip();
        }

        $q.all([matchesFunc(), masteriesFunc()]).then(function(responses) {
            setMatchInfo(responses[0].data);
            setMasteryInfo(responses[1].data);
        });

        $http.get("/api/static/summonerSpells").success(function(data) {
            var summonerSpells = {};
            for (var el in data) {
                summonerSpells[data[el].Id] = data[el];
            }
            $scope.summonerSpells = summonerSpells;
        });
    });
