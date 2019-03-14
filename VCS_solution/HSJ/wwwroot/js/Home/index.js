

$(document).ready(function () {

	var logininfo = sessionStorage.getItem("User");
	if (logininfo != null) {
		$("#contents #info").empty();
		var loginId = sessionStorage.getItem("UserId");
		var html = '';
		html += '<h1>' + loginId + '님 환영합니다</h1>';
		html += '<button type="submit" name="logout" class="logout" id="logout">로그아웃</button>';
		$("#contents #info").append(html);
	}

	$("#logout").click(
		function (e) {
			sessionStorage.removeItem("User");
			sessionStorage.removeItem("UserdNo");
			sessionStorage.removeItem("UserId");
			alert("로그아웃하셨습니다.");
			location.href = location.href;
		}
	);

	$("form").submit(function(e) {
		e.preventDefault();      
		var inputid = $("input[name=id]").val();
		var inputpw = $("input[name=password]").val();
		//alert("아이디" + inputid + " 비밀번호" + inputpw);
		if (inputid == "" && inputpw == "") {
			alert("아이디나 비밀번호를 확인해주세요!");
			return false;
		}

		$.post("/api/login", { id: inputid, pw: inputpw }).done(
			function(data) {
				var mNo = data[0].mNo;
				var dNo = data[0].dNo;
				//alert("회원번호" + mNo + "/구분번호" + dNo);
				switch (dNo) {
					case 1:
						alert(inputid + "님 로그인하셨습니다");
						if (window.sessionStorage) {
							sessionStorage.setItem("User", mNo);
							sessionStorage.setItem("UserdNo", dNo);
							sessionStorage.setItem("UserId", inputid);
							var position = sessionStorage.getItem("User");
							//alert(position);
						}
						location.href = "/Home/index";
						break;
					case 0:
						alert("아이디나 비밀번호를 확인해주세요!");
						break;
					defalut:
						alert("아이디나 비밀번호를 확인해주세요!");
						break;
				}
			}
		);
	});

	
	
	$("#signup").click(function () {
		location.href = "/Member/Signup";
	});

	$("#idpw").click(function () {
		location.href = "/Member/Searchidpw";
	});
});