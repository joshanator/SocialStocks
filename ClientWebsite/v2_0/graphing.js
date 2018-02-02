google.charts.load('current', {packages: ['corechart', 'line']});
// google.charts.setOnLoadCallback(drawCurveTypes);

function drawStocks(json) {
    
    
      var data = new google.visualization.DataTable();
      data.addColumn('date', 'X');
      data.addColumn('number', 'Stock Price');


    for(i=0;i<json.length;i++){
        var date = new Date(json[i].date.substr(0,10));
        data.addRow([date, json[i].price]);
    }


      var options = {
        hAxis: {
          title: 'Date'
        },
        vAxis: {
          title: 'Value'
        },
        series: {
          1: {curveType: 'function'}
        }
      };

      var chart = new google.visualization.LineChart($('#search-results')[0]);
      chart.draw(data, options);
    }


function drawUser(json) {
    
    
    var data = new google.visualization.DataTable();
    data.addColumn('date', 'Date');
    data.addColumn('number', 'Stock Price');
    data.addColumn('number', 'Keyword Frequency');


  for(i=0;i<json.length;i++){
      var date = new Date(json[i].date.substr(0,10));
      data.addRow([date, json[i].price, json[i].count]);
  }


    var options = {
      series: {
          0: {axis: 'Stock'},
          1: {axis: 'Frequency'}
        },
        axes: {
          y: {
            Stock: {label: 'Stock Price'},
            Frequency: {label: 'Frequency'}
          }
        }
    };

    var chart = new google.charts.Line($('#search-results')[0]);
    chart.draw(data, options);
}


function drawTrends(json) {
    
    
      var data = new google.visualization.DataTable();
      data.addColumn('date', 'Date');
      data.addColumn('number', 'Stock Price');
     data.addColumn('number', 'Trending Value');


    for(i=0;i<json.length;i++){
        var date = new Date(json[i].date.substr(0,10));
        data.addRow([date, json[i].stockPrice, json[i].trendingValue]);
    }


      var options = {
        series: {
            0: {axis: 'Stock'},
            1: {axis: 'Trending'}
          },
          axes: {
            y: {
              Stock: {label: 'Stock Price'},
              Trending: {label: 'Trending'}
            }
          }
      };

      var chart = new google.charts.Line($('#search-results')[0]);
      chart.draw(data, options);
    }



function collectStock(stock){
    var query = "symbol=" + stock;

    var stateObj = {symbol: stock};
    history.pushState(stateObj, "Symbol: " + stock, "?stock&" + query);

    var url = 'http://socialstockswebapi.azurewebsites.net/api/Stocks?' + query;

    var json = $.getJSON(url, function(data) {
        console.log(data);
        drawStocks(data);
    });
}


function collectUser(stock,user,keyword,number){
    var query = "symbol=" + stock + "&user=" + user + "&keyword=" + keyword;

    if(number != ""){
        query += "&number=" + number;
    }

    var stateObj = {symbol: stock, user:user, keyword:keyword, number:number};
    history.pushState(stateObj, "Symbol: " + stock, "?user&" +query);

    var url = 'http://socialstockswebapi.azurewebsites.net/api/User?' + query;

    var json = $.getJSON(url, function(data) {
        console.log(data);
        drawUser(data);
    });
}


function collectTrends(stock,hashtag){
    var query = "symbol=" + stock + "&hashtag=" + hashtag;

    var stateObj = {symbol: stock, hashtag:hashtag};
    history.pushState(stateObj, "Symbol: " + stock, "?trends&" + query);

    var url = 'http://socialstockswebapi.azurewebsites.net/api/Combined?' + query;

    var json = $.getJSON(url, function(data) {
        console.log(data);
        drawTrends(data);
    });
}