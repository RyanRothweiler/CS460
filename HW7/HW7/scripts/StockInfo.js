var dateCol, openCol, highCol, lowCol;
var openEnabled = true;
var highEnabled = true;
var lowEnabled = true;

function GetPrices()
{
    var symbol = document.getElementById("symbol").value;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/GetStockData/",
        data: { sym: symbol },
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
    for (var y = 0; y < 24; y++) {
        assembledData += dateCol[y] + ",";

        if (openEnabled) {
            assembledData += openCol[y] + ",";
        }
        if (highEnabled) {
            assembledData += highCol[y] + ",";
        }
        if (lowEnabled) {
            assembledData += lowCol[y];
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
    document.getElementById("symbolHeader").innerHTML = data.symbol;
}

function DisplayData(data)
{
    dateCol = data.date;
    openCol = data.open;
    highCol = data.high;
    lowCol = data.low;
    
    DisplayFromGlobal();
}