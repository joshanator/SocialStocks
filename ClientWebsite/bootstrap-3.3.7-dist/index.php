<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Social Stocks</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/starter-template.css" rel="stylesheet">
      
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
      
      <script type="text/javascript" src="bower_components/jquery/dist/jquery.min.js"></script>
  <script type="text/javascript" src="bower_components/moment/min/moment.min.js"></script>
  <script type="text/javascript" src="js/bootstrap.min.js"></script>
  <script type="text/javascript" src="bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"></script>
  <link rel="stylesheet" href="css/bootstrap.min.css" />
  <link rel="stylesheet" href="bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>
    <nav class="navbar navbar navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">Social Stocks</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="index.php">Home</a></li>
            <li><a href="about.html">About</a></li>
            <li><a href="documentation.html">API Documentation</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <div class="container">

      <div class="starter-template">
          
          <div class="panel panel-primary">
          <div class="panel-heading">
            <h3 class="panel-title">Search</h3>
          </div>
          <div class="panel-body">
              
              
              <ul class="nav nav-tabs">
<!--                    <li class="active"><a data-toggle="tab" href="#home">Recent</a></li>-->
                    <li class="active"><a data-toggle="tab" href="#menu1">User</a></li>
                    <li><a data-toggle="tab" href="#menu2">Trends</a></li>
                  <li><a data-toggle="tab" href="#menu3">Stock</a></li>
                  <li><a data-toggle="tab" href="#menu4">Suggested</a></li>
              </ul>
              

                <div class="tab-content">
                    
<!--
                    <div id="home" class="tab-pane fade in active">
                      <h3>Search Recent(6-9 Day old) Data</h3>
                      <p>
                        <form class="" action="index.php">

                            <div class="form-group">
                                <input type="text" name="symbol" placeholder="Stock Symbol" class="form-control">
                            </div>
                            
                            <div class="form-group">
                                <input type="text" name="type" placeholder="Recent(limited to last 100 posts) or Popular" class="form-control">
                            </div>
                            
                            <div class="form-group">
                                <input type="text" name="q" placeholder="Search Query (https://dev.twitter.com/rest/public/search)" class="form-control">
                            </div>

                            <button type="submit" class="btn btn-success">Search</button>
                        </form>

                        
                        
                        </p>
                    </div>
-->
              
                    <div id="menu1" class="tab-pane fade in active">
                      <h3>Search Data From a Specific User</h3>
                      <p>
                          
                          <form class="" action="index.php">

                            <div class="form-group">
                                <input type="text" name="symbol" placeholder="Stock Symbol" class="form-control">
                            </div>

                            <div class="form-group">
                                <input type="text" name="user" placeholder="User" class="form-control">
                            </div>

                            <div class="form-group">
                                <input type="text" name="keyword" placeholder="Keyword" class="form-control">
                            </div>

                            <button type="submit" class="btn btn-success">Search</button>
                        </form>
                        
                        </p>
                    </div>
                    <div id="menu2" class="tab-pane fade">
                      <h3>Search From Historical(2006 - Present) Trending Hashtags</h3>
                      <p>
                          
                          <form class="" action="index.php">
                              
                            <div class="form-group">
                                <input type="text" name="symbol" placeholder="Stock Symbol" class="form-control">
                            </div>


                            <div class="form-group">
                                <input type="text" name="hashtag" placeholder="Hashtag" class="form-control">
                            </div>

                            <button type="submit" class="btn btn-success">Search</button>
                        </form>
                        
                        
                        </p>
                    </div>
                    <div id="menu3" class="tab-pane fade">
                      <h3>Search Stock Data</h3>
                      <p>
                          
                          <form class="" action="index.php">
                              
                            <div class="form-group">
                                <input type="text" name="symbol" placeholder="Stock Symbol" class="form-control">
                            </div>


                            <button type="submit" class="btn btn-success">Search</button>
                        </form>
                        
                        
                        </p>
                    </div>
        
                    <div id="menu4" class="tab-pane fade">
                      <h3>Suggested</h3>
                      <p>
                          <a href="index.php?symbol=TWX&user=realDonaldTrump&keyword=media"><button class="btn btn-default btn-lg">User: Time Warner Stock vs. Trump Tweeting "media"</button></a>
<!--                          <a href="index.php?symbol=LUV&q=flight+%3A%28&type=popular"><button class="btn btn-default btn-lg">Recent: Southwest Airlines Stock vs. Popular Negative Posts About Flights</button></a>-->
                          <a href="index.php?symbol=MSTR&start=2016-02-19&end=2017-02-19="><button class="btn btn-default btn-lg">Stock: MSTR</button></a>
                        </p>
                    </div>    
                </div>
              
              
          </div>
        </div>
          
          
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Results</h3>
            </div>
            <div class="panel-body">
                <?php
                      if(isset($_GET['symbol']) && isset($_GET['user']) && isset($_GET['keyword'])) {
                          echo '<iframe width="1000" height="450" src="https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=87AA2CB64AAA87A4381B54A734728DB9&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['symbol'] . '^' . $_GET['user'] . '^' . $_GET['keyword'] . '"></iframe>';
                      }
                      else if(isset($_GET['symbol']) && isset($_GET['hashtag'])) {
                          echo '<iframe width="1000" height="450" src="https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=7B6DDE61405655A3CC812BB0621F3184&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['hashtag'] . "^" . $_GET['symbol'] . '"></iframe>';
                      }
                      else if(isset($_GET['symbol']) && isset($_GET['q'])) {
                          //echo '<iframe width="1000" height="450" src="https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=BF2811294EDE067FBDA24E9F14B4FC25&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['symbol'] . '^2016-02-10%252000%253A00^2017-02-10%252000%253A00"></iframe>';
                      }
                      else if(isset($_GET['symbol'])) {
                          echo '<iframe width="1000" height="450" src="https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=BF2811294EDE067FBDA24E9F14B4FC25&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['symbol'] . '^2016-02-10%252000%253A00^2017-02-10%252000%253A00"></iframe>';
                      }
                ?>
            </div>
        </div>
              
          
      </div>

    </div><!-- /.container -->
      
      
      
    
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
  </body>
</html>