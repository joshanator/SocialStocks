<?php
    if(isset($_GET['symbol']) && isset($_GET['user']) && isset($_GET['keyword'])) {
        echo 'https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=87AA2CB64AAA87A4381B54A734728DB9&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['symbol'] . '^' . $_GET['user'] . '^' . $_GET['keyword'];
    }
    else if(isset($_GET['symbol']) && isset($_GET['hashtag'])) {
        echo 'https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=7B6DDE61405655A3CC812BB0621F3184&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['hashtag'] . "^" . $_GET['symbol'];
    }
    else if(isset($_GET['symbol']) && isset($_GET['q'])) {
        //echo '<iframe width="1000" height="450" src="https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.fvbgb4001&visMode=0&reportViewMode=2&reportID=BF2811294EDE067FBDA24E9F14B4FC25&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['symbol'] . '^2016-02-10%252000%253A00^2017-02-10%252000%253A00"></iframe>';
    }
    else if(isset($_GET['symbol'])) {
        echo 'https://env-48431.customer.cloud.microstrategy.com:443/MicroStrategy/servlet/mstrWeb?evt=4001&src=mstrWeb.4001&visMode=0&reportViewMode=2&reportID=BF2811294EDE067FBDA24E9F14B4FC25&Server=ENV-48431LAIOUSE1&Project=MicroStrategy%20Tutorial&Port=0&share=1&hiddensections=header,path,dockTop,dockLeft,footer&uid=mstr&pwd=Wr3aCTg53uOp&ConnMode=1&valuePromptAnswers=' . $_GET['symbol'] . '^2016-02-10%252000%253A00^2017-02-10%252000%253A00';
    }
    else {
        echo 'about:blank';
    } 
?>