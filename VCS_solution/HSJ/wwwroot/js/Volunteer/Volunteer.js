var list = angular.module("myApp", []);
list.controller("noticelist", function ($scope, $http) {
	$scope.currentPage = 0;
	$scope.pageSize = 5;
	$scope.data = [];
	$scope.pageList = [];
	$scope.numberOfPage = 3;
	$http.get("/api/notice").then(function (d) {
		console.log(d);
		$scope.data = d.data;
		$scope.numberOfPage = Math.ceil($scope.data.length / $scope.pageSize);
		for (var i = 0; i < $scope.numberOfPage; i++) {
			$scope.pageList.push({ "no": i + 1 });
		}
	}, function (d) { console.log(d); });

	$scope.btn = function (state) {
		if (state == 0) {
			$scope.currentPage--;
		} else if (state == 1) {
			$scope.currentPage++;
		}

		if ($scope.currentPage < 0) {
			$scope.currentPage = 0;
		} else if ($scope.currentPage == $scope.data.lengt) {
			$scope.currentPage = (numberOfPage - 1);
		}
	}

	$scope.list = function (vNo) {
		location.href = "/Volunteer/VolunteerDetail";
		window.sessionStorage.setItem("vNo", vNo);
	}

	$scope.page = function (row) {
		$scope.currentPage = (row.no - 1);
	}

});
list.filter('startFrom', function () {
	return function (input, start) {
		start = +start; //parse to int
		return input.slice(start);
	}
});