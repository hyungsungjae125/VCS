angular.module("myApp", []).controller("noticelist", function ($scope, $http) {

	$scope.data = [];
	$http.post("/api/notice").then(function (d) {
		console.log(d.data);
		$scope.data = d.data;
	}, function (d) { console.log(d); });

	$scope.btn = function (data, index) {
		console.log(data, index, $scope.data[index]);
	}

});