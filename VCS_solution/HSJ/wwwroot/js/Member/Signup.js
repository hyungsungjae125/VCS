$(document).ready(
	function () {
		$("form").submit(function (e) {
			e.preventDefault();

			var param = {
				"id": $("#id").val(),
				"pw": $("#pw").val(),
				"name": $("#name").val(),
				"addr": $("#addr").val(),
				"num": $("#num").val()
			};

			$.post("/api/signup", param).done(function (d) {
				var result = d;
				
				if (d == "1") {
					alert("회원가입 완료");
					location.href = "/Home/Index"
				} else {
					alert("실패...");
				}
				
			});
		});
});