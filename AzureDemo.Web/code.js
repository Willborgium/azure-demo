var retrieveMessage = function(){
	var key = $("#keyControl").val();

	$.ajax({
		url: "http://homesitedemo.azurewebsites.net/AzureDemo/GetMessage/" + key,
		dataType: "json",
		success: function(args){
			$("#messageControl").val(args);
		},
		error: function(args){
			alert(args);
		}
	});
}

var saveMessage = function(){
	var key = $("#keyControl").val();

	var message = $("#messageControl").val();

	$.ajax({
		url: "http://homesitedemo.azurewebsites.net/AzureDemo/SaveMessage/" + key,
		dataType: "json",
		method: "POST",
		contentType: "application/json",
		data: JSON.stringify(message),
		success: function(args){
			alert(args);
		},
		error: function(args){
			alert(args);
		}
	});
}