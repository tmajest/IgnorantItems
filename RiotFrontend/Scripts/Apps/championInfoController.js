angular.module("IgnorantItems", [])
    .controller("championInfoController", function($scope, $http) {
        var championId = window.backendParams.championId;
        var MATCHES_TO_REQUEST = 10;

        $scope.matches = [];
        $scope.disableLoading = false;

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

        var enableLoadingButton = function() {
            jQuery(".loadMatchesButton").removeAttribute("disabled");
            $scope.disableLoading = false;
        };

        var disableLoadingButton = function() {
            jQuery(".loadMatchesButton").prop("disabled", true);
            $scope.disableLoading = true;
        };

        var loadMatches = function(skip, count) {
            disableLoadingButton();
            showLoadingAnimation();

            var url = "/api/champions/" + championId + "?skip=" + skip + "&count=" + count;
            $http({ method: "GET", url: url}).then(
                function(response) {
                    var data = response.data;
                    if (data && data.Matches && data.Matches.length > 0) {
                        $scope.title = data.Matches[0].Champion.Name;
                        var champNameIndex = data.Matches[0].Champion.Image.Full.indexOf(".");
                        var imageName = data.Matches[0].Champion.Image.Full
                            .substring(0, champNameIndex) +
                            "_0" +
                            ".jpg";
                        $scope.imageName = imageName;

                        for (var i = 0; i < data.Matches.length; i++) {
                            $scope.matches.push(data.Matches[i]);
                        }

                        hideLoadingAnimation();
                        if (data.Matches.length < count) {
                            disableLoadingButton();
                        } else {
                            enableLoadingButton();
                        }

                    } else {
                        disableLoadingButton();
                        hideLoadingAnimation();
                    }
                },
                function() {
                    disableLoadingButton();
                    hideLoadingAnimation();
                });
        };

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

        jQuery(".loadMatchesButton").click(function(e) {
            if (!$scope.disableLoading) {
                loadMatches($scope.matches.length, MATCHES_TO_REQUEST);
            }
        });

        loadMatches(0, MATCHES_TO_REQUEST);
    });