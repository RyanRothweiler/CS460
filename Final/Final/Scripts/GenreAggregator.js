function GetGenreData(genreWanting)
{
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/GetGenreData/",
        data: {g: genreWanting},
        success: DisplayData
    });

}

function DisplayData(jsonData)
{
    document.getElementById("genreList").innerHTML = "";

    console.log(jsonData.artworksCount);

    for (var index = 0; index < jsonData.artworksCount; index++) {
        var artTitle = jsonData.artworks[index].ArtworkTitle;
        var artAuthor = jsonData.artworks[index].ArtistName;
        var entry = "" + artTitle + " by " + artAuthor;
        document.getElementById("genreList").innerHTML += "<li class=\"list-group-item\">" + entry + "</li>";
    }
}