angular.module("IgnorantItems", [])
    .controller("championsController", function($scope, $http) {
        $http.get("/api/champions").success(function(data) {
            $scope.allChampions = data;
         });
    });
