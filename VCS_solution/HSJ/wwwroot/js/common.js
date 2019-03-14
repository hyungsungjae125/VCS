$(document).ready(function () {
	$("#login").click(function () {
		location.href = "/Member/Login";
	});

	$("#join").click(function () {
		location.href = "/Member/Signup";
	});
	var logininfo = sessionStorage.getItem("User");
	if (logininfo != null) {
		$("#header #right").empty();
		var html2 = '';
		html2 += '<button type="submit" name="logout" class="logout" id="logout2">로그아웃</button>';
		$("#header #right").append(html2);
	}

	$("#logout2").click(
		function (e) {
			sessionStorage.removeItem("User");
			sessionStorage.removeItem("UserdNo");
			sessionStorage.removeItem("UserId");
			alert("로그아웃하셨습니다.");
			location.href = location.href;
		}
	);
});
