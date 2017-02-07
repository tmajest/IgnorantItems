angular.module("IgnorantItems", [])
    .controller("homeController", function($scope, $http) {
        $scope.allMatches = [];
        $scope.title = "Recent Matches";
        
        var MATCHES_TO_REQUEST = 10;

        var setActivePage = function(i) {
            jQuery(".page" + $scope.matchIndex).removeClass('active');
            jQuery(".page" + i).addClass('active');
        }

        var showContent = function () {
            jQuery(".loadingOuterContainer").hide();
            jQuery(".glyphicon-refresh-animate")
                .css("-animation: spin .7s infinite linear", "none 0s")
                .css(".glyphicon-refresh-animate", "none 0s");
            jQuery(".allMatches").show();
        };

        var hideContent = function () {
            jQuery(".loadingOuterContainer").show();
            jQuery(".glyphicon-refresh-animate")
                .css("-animation: spin .7s infinite linear", "")
                .css(".glyphicon-refresh-animate", "");
            jQuery(".allMatches").hide();
        };

        var pageData = function (i) {
            if ($scope.matchIndex == i) {
                return;
            } else if (i in $scope.allMatches) {
                hideContent();
                setActivePage(i);
                $scope.currentMatchList = $scope.allMatches[i];
                $scope.matchIndex = i;
                showContent();
            } else {
                var skip = MATCHES_TO_REQUEST * i;
                hideContent();
                $http.get("/api/matches?skip=" + skip + "&count=" + MATCHES_TO_REQUEST).success(function(data) {
                    setActivePage(i);
                    var matches = data.Matches;
                    $scope.allMatches[i] = matches;
                    $scope.currentMatchList = matches;
                    $scope.matchIndex = i;
                    showContent();
                });
            }
        };

        var setupPaginationButtons = function(i) {
            jQuery(".page" + (i)).click(function() {
                pageData(i);
            });
        }

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

        $scope.matchIndex = -1;
        $scope.allMatches = {};
        pageData(0);

        // Pagination buttons
        setupPaginationButtons(0);
        setupPaginationButtons(1);
        setupPaginationButtons(2);
        setupPaginationButtons(3);
        setupPaginationButtons(4);
    });
