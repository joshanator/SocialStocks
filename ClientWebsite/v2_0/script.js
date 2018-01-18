function collect(){
    var stock = $("#search-symbol")[0].value;

    var url = 'http://socialstockswebapi.azurewebsites.net/api/Stocks?symbol=' + stock;

    var json = $.getJSON(url, function(data) {
        console.log(data);

        draw(data);

    });
}