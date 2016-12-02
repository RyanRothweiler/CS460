﻿function GetBootyValues()
{
        $.ajax({
        	type: "GET",
        	dataType: "json",
        	url: "/Home/GetBooty/",
        	data: { },
        	success: DisplayData
    	});
}

function DisplayData(data)
{
	document.getElementById("bootyList").innerHTML = "";

	for (var index = 0; index < data.bootySize; index++)
	{
		var item = data.bootyVal[index];
		var itemDesc = "" + item.Name + " - " + item.Booty;
		document.getElementById("bootyList").innerHTML += "<li class=\"list-group-item\">" + itemDesc + "</li>";
	}
}