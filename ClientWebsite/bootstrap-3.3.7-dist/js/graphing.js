google.charts.load('current', {packages: ['corechart', 'line']});
// google.charts.setOnLoadCallback(drawCurveTypes);

function draw(json) {
    
    var stock = $("#symbol")[0].value;

      var data = new google.visualization.DataTable();
      data.addColumn('date', 'X');
      data.addColumn('number', stock);


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


    function collect(){
        var stock = $("#symbol")[0].value;

        var url = 'http://socialstockswebapi.azurewebsites.net/api/Stocks?symbol=' + stock;

        var json = $.getJSON(url, function(data) {
            console.log(data);
    
            draw(data);
    
        });
    }