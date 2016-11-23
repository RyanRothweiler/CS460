var dateCol = [""];
var openCol = [""];
var highCol = [""];
var lowCol = [""];
var openColTwo = [""];
var highColTwo = [""];
var lowColTwo = [""];

var openEnabled = true;
var highEnabled = true;
var lowEnabled = true;

var symbolOne = "";
var symbolTwo = "";

var first = true;

function GetPrices(gnum)
{
    if (first)
    {
        first = false;

        for (var index = 0; index < 24; index++)
        {
            dateCol[index] = "";

            openCol[index] = "";
            openColTwo[index] = "";

            lowCol[index] = "";
            lowColTwo[index] = "";

            highCol[index] = "";
            highColTwo[index] = "";
        }
    }

    var symbol = document.getElementById("symbol").value;

    var bow = "";
    if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
        bow = "Opera";
    }
    else if (navigator.userAgent.indexOf("Chrome") != -1) {
        bow = "Chrome";
    }
    else if (navigator.userAgent.indexOf("Safari") != -1) {
        bow = "Safari";
    }
    else if (navigator.userAgent.indexOf("Firefox") != -1) {
        bow = "Firefox";
    }
    else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
    {
        bow = "IE";
    }
    else {
        bow = "Unknown";
    }

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/GetStockData/",
        data: { sym: symbol, graphNum : gnum , browser : bow},
        success: DisplayData
    });
}

function ToggleOpen()
{
    openEnabled = !openEnabled;
    DisplayFromGlobal();
}

function ToggleHigh()
{
    highEnabled = !highEnabled;
    DisplayFromGlobal();
}

function ToggleLow()
{
    lowEnabled = !lowEnabled;
    DisplayFromGlobal();
}


function BuildData()
{
    var assembledData = "";
    for (var y = 0; y < 24; y++)
    {
        console.log(y);

        assembledData += dateCol[y] + ",";

        if (openEnabled) 
        {
            assembledData += openCol[y] + ",";
            assembledData += openColTwo[y] + ",";
        }
        if (highEnabled)
        {
            assembledData += highCol[y] + ",";
            assembledData += highColTwo[y] + ",";
        }
        if (lowEnabled)
        {
            assembledData += lowCol[y];
            assembledData += lowColTwo[y];
        }

        assembledData += "\n";
    }
    return (assembledData);
}

function DisplayFromGlobal()
{
    g = new Dygraph(
        document.getElementById("graph"),
        BuildData(),
        {
            xlabel: 'Date',
            ylabel: 'Price',
        }
    );

    document.getElementById("symbolHeader").innerHTML = symbolOne + " and " + symbolTwo;
}

function DisplayData(data)
{
    dateCol = data.date;

    if (data.graphNum == "first")
    {
        openCol = data.open;
        highCol = data.high;
        lowCol = data.low;

        symbolOne = data.symbol;
    }

    if (data.graphNum == "second")
    {
        openColTwo = data.open;
        highColTwo = data.high;
        lowColTwo = data.low;

        symbolTwo = data.symbol;
    }

    DisplayFromGlobal();
}