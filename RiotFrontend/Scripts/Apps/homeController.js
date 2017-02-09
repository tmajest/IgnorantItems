angular.module("IgnorantItems", [])
    .controller("homeController", function($scope, $http) {
        $scope.matches = [];
        $scope.title = "Recent Matches";
        
        var MATCHES_TO_REQUEST = 10;

        var hideLoadingAnimation = function () {
            jQuery(".loadingWheel").hide();
            jQuery(".loadingWheel")
                .css("-animation: spin .7s infinite linear", "none 0s")
                .css(".glyphicon-refresh-animate", "none 0s");
        };

        var showLoadingAnimation = function () {
            jQuery(".loadingWheel").show();
            jQuery(".loadingWheel")
                .css("-animation: spin .7s infinite linear", "")
                .css(".glyphicon-refresh-animate", "");
        };

        var loadMatches = function(skip, count) {
            jQuery(".loadMatchesButton").prop("disabled", true);
            showLoadingAnimation();

            var url = "/api/matches?skip=" + skip + "&count=" + count;
            $http.get(url).success(function(data) {
                if (data && data.Matches) {
                    for (var i = 0; i < data.Matches.length; i++) {
                        $scope.matches.push(data.Matches[i]);
                    }
                }

                jQuery(".loadMatchesButton").prop("disabled", false);
                hideLoadingAnimation();
            });

        };

        $scope.getMatchResultText = function(match) {
            return match.Won ? "Win" : "Loss";
        };

        $scope.getMatchResultColor = function(match) {
            return match.Won ? {"color": "#00b300"} : {"color": "#cc0000"};
        };
        
        $http.get("/api/static/summonerSpells").success(function (data) {
            $scope.summonerSpells = {};

            for (var el in data) {
                $scope.summonerSpells[data[el].Id] = data[el];
            }
        });

        loadMatches(0, MATCHES_TO_REQUEST);

        jQuery(".loadMatchesButton").click(function() {
            loadMatches($scope.matches.length, MATCHES_TO_REQUEST);
        });
    });
