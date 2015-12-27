﻿
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

        $http.get("/api/matches/" + matchId).success(function(data) {
            $scope.match = data;
            $scope.imageName = data.Champion.Image.Full;
            $scope.title = getTitle(data);
            $scope.kills = data.Kills;
            $scope.deaths = data.Deaths;
            $scope.assists = data.Assists;
            $scope.durationText = getDuration(data.MatchDuration);
            $scope.skillOrder = data.SkillOrder;
            $scope.spell1Id = data.Spell1Id;
            $scope.spell2Id = data.Spell2Id;
            $scope.items = data.Items;

            setMasteryTree();

            $http.get("/api/static/masteries").success(function(masteries) {
                $scope.masteries = masteries;
                $scope.masteryDescription = {};
                var len = masteries.length;
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
        });

        $http.get("/api/static/summonerSpells").success(function(data) {
            var summonerSpells = {};
            for (var el in data) {
                summonerSpells[data[el].Id] = data[el];
            }
            $scope.summonerSpells = summonerSpells;
        });
    });
