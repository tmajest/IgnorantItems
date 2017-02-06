
angular.module("IgnorantItems", ['ui.bootstrap'])
    .controller("matchController", function($scope, $http, $q) {
        var summonerName = window.backendParams.summonerName;
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

        var setMasteryTree = function() {
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

                image.css("-webkit-filter", "none");
                image.css("border", "2px solid #FFF5A6");

                var parentDiv = image.parent();
                var rankText = mastery.Rank + "/" + mastery.Data.Ranks;
                parentDiv.append("<span class='masteryRank'>" + rankText + "</span>");
            }
        }

        $http.get("/api/matches/" + summonerName + "/" + matchId).success(function(data) {
            jQuery(".loadingContainer").hide();
            jQuery(".glyphicon-refresh-animate")
                .css("-animation: spin .7s infinite linear", "none 0s")
                .css(".glyphicon-refresh-animate", "none 0s");

            var champNameIndex = data.Champion.Image.Full.indexOf(".");
            var imageName = data.Champion.Image.Full.substring(0, champNameIndex) + "_0" + ".jpg";
            $scope.imageName = imageName;

            jQuery(".matchContainer").show();

            $scope.match = data;
            $scope.title = getTitle(data);
            $scope.kills = data.Kills;
            $scope.deaths = data.Deaths;
            $scope.assists = data.Assists;
            $scope.durationText = getDuration(data.MatchDuration);
            $scope.skillOrder = data.SkillOrder;
            $scope.spell1Id = data.Spell1Id;
            $scope.spell2Id = data.Spell2Id;
            $scope.finalBuild = data.FinalBuild;

            setMasteryTree();

            $http.get("/api/static/masteries").success(function(masteries) {
                $scope.masteries = masteries;
                $scope.masteryDescription = {};
                for (var key in masteries) {
                    if (masteries.hasOwnProperty(key)) {
                        var mastery = masteries[key];
                        $scope.masteryDescription[mastery.Id] = mastery.SanitizedDescription[mastery.SanitizedDescription.length - 1];
                    }
                }

                var len = $scope.match.Masteries.length;
                for (var i = 0; i < len; i++) {
                    var mastery = $scope.match.Masteries[i];
                    if (mastery.Rank === 0) {
                        continue;
                    }

                    $scope.masteryDescription[mastery.Data.Id] = mastery.Data.SanitizedDescription[mastery.Rank - 1];
                }

                len = data.SkillOrder.length;
                for (var i = 0; i < len; i++) {
                    var selector = ".skillRow" + data.SkillOrder[i] + " > .col" + (i + 1);
                    var col = jQuery(selector)
                        .css("background-color", "#4B73C9")
                        .css("border", "2px solid #3E4BAD")
                        .append("<div class=\"skillRank\">" + (i + 1) + "</div>");
                }
            });

            var twitchMatchId = $scope.match.TwitchVideoId;
            var options = {
                width: 700,
                height: 400,
                video: twitchMatchId,
                autoplay: false
            };
            $scope.playing = false;
            $scope.player = new Twitch.Player("twitchVideoContainer", options);
            $scope.player.setVolume(0.5);
            $scope.player.addEventListener(
                Twitch.Player.PLAY,
                function () {
                    if (!$scope.playing) {
                        $scope.player.seek($scope.match.TwitchOffset);
                        $scope.playing = true;
                    }
                });
        });

        $http.get("/api/static/summonerSpells").success(function(data) {
            var summonerSpells = {};
            for (var el in data) {
                summonerSpells[data[el].Id] = data[el];
            }
            $scope.summonerSpells = summonerSpells;
        });
    });
