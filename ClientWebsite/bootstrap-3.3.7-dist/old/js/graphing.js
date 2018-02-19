google.charts.load('current', {packages: ['corechart', 'line']});
// google.charts.setOnLoadCallback(drawCurveTypes);

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

    var chart = new google.charts.Line(document.getElementById('chart_div'));
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

      var chart = new google.charts.Line(document.getElementById('chart_div'));
      chart.draw(data, options);
    }

    




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

      var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
      chart.draw(data, options);
    }


    function collectUser(){
        var stock = $("#symbol1")[0].value;
        var user = $("#user")[0].value;
        var keyword = $("#keyword")[0].value;
        var number = $("#number")[0].value;

        var url = 'http://socialstockswebapi.azurewebsites.net/api/User?symbol=' + stock + "&user=" + user + "&keyword=" + keyword;

        if(number != ""){
            url += "&number=" + number;
        }

        var json = $.getJSON(url, function(data) {
            console.log(data);
    
            drawUser(data);
    
        });
    }

    function collectTrends(){
        var stock = $("#symbol2")[0].value;
        var hashtag = $("#hashtag")[0].value;

        var url = 'http://socialstockswebapi.azurewebsites.net/api/Combined?hashtag=' + hashtag + "&symbol=" + stock;

        var json = $.getJSON(url, function(data) {
            console.log(data);
    
            drawTrends(data);
    
        });
    }

    function collectStocks(){
        var stock = $("#symbol3")[0].value;
        var start = $("#startDate")[0].value;
        var end = $("#endDate")[0].value;

        var url = 'http://socialstockswebapi.azurewebsites.net/api/Stocks?symbol=' + stock;

        if(start != ""){
            url+= "&start=" + start;
        }
        if(end != ""){
            url+= "&end=" + end;
        }


        var json = $.getJSON(url, function(data) {
            console.log(data);
    
            drawStocks(data);
    
        });
    }