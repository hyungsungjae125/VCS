$(document).ready(function () {
	var vNo = window.sessionStorage.getItem("vNo");

	if (vNo != null) {
		console.log(vNo);
	}
	else {
		vNo = 1;
	}


});