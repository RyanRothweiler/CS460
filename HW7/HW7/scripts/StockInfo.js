function GetPrices()
{
    console.log("Getting the new graph");

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/GetStockData",
        success: DisplayData
    });

    g = new Dygraph(

       // containing div
       document.getElementById("graph"),

       // CSV or path to a CSV file.
       "Date,Temperature\n" +
       "2008-05-07,75\n" +
       "2008-05-08,70\n" +
       "2008-05-09,80\n"

     );
}

function DisplayData(data)
{
    console.log("Data!");
    console.log(data.row);
}