$(document).ready(function () {
	var vNo = window.sessionStorage.getItem("vNo");

	if (vNo != null) {
		var param = {
			"vno": vNo
		};

		$.post("/api/volunteerdetail", param).done(function (data) {
			//data[0].
			$("#no").append("    제목");
			$("#title").append(data[0].vName);
			$("#vol").append(data[0].vStartvol + " ~ " + data[0].vEndvol);
			$("#col").append(data[0].vStartcollect + " ~ " + data[0].vEndcollect);
			$("#time").append(data[0].vTime+"시간");
			$("#num").append(data[0].vNownum+"명 / "+data[0].vCollectnum+"명");
			$("#week").append(data[0].vWeek);
			$("#aname").append(data[0].aName);
			$("#field").append(data[0].vField);
			$("#object").append(data[0].vObject);
			$("#place").append(data[0].vCity+" "+data[0].vGu+" "+data[0].vPlace);
			$("#detailcontent").append(data[0].vContents);
			$("#admin").append(" 관리자 : " + data[0].mName + "<br>" + " 주소 : " + data[0].mAddr + "<br>"+" 전화번호 : " + data[0].mNumber);
		});
	}
	else {
		vNo = 1;
	}
	$("#applybtn").click(function () {
		var vNo = window.sessionStorage.getItem("vNo");
		var mNo = window.sessionStorage.getItem("User");
		if (mNo != null) {
			var param = {
				"vno": vNo,
				"mno": mNo
			};
			$.post("/api/applyinsert", param).done(function (data) {
				var result = data;
				console.log(data);
				if (result == 2) {
					alert("신청완료.");
					location.href = location.href;
				} else {
					alert("이미 신청되어 있거나 신청이 불가합니다.");
					location.href = location.href;
				}
			});
		}
		else {
			alert("로그인이 필요합니다.");
			location.href="/Member/Login"
		}
	});
	$("#backlistbtn").click(function () {
		history.back();
	});
});