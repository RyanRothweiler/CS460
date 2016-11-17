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

function DisplayData(data)
{
    console.log(data.yahooFile);
    g = new Dygraph(
        document.getElementById("graph"), 
        data.yahooFile, 
        {
            xlabel: 'Date',
            ylabel: 'Price',
            valueRange: [0, 300],
            height: 700,
        }
    );
    document.getElementById("symbolHeader").innerHTML = data.symbol;
}