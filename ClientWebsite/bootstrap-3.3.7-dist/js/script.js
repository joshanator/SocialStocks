window.onload = checkForQuery;

function checkForQuery(){
    var url = window.location.href; 
    var queryString = url ? url.split('?')[1] : window.location.search.slice(1);
    
    if(queryString != "" && queryString != "#" && queryString != undefined){
        searchPage();
        setTimeout(handleQuery(queryString), 5000);
    }

}

function handleQuery(queryString){
    var parameters = queryString.split("&");
    var stock = parameters[1].substr(7);

    if(parameters[0] == "trends"){
        var hashtag = parameters[2].substr(8);
        collectTrends(stock,hashtag);
    }
    else if(parameters[0] == "user"){
        var user = parameters[2].substr(5);
        var keyword = parameters[3].substr(8);
        var number = "";
        if(parameters.length == 5){
            number = parameters[4].substr(7);
        }
        collectUser(stock,user,keyword,number);
    }
    else if(parameters[0] == "stock"){
        collectStock(stock);
    }
}



function search() {
    if(!$('.card#search').hasClass('full-width')) {
        searchPage();
    }
    if($("#comparison-user")[0].className == "tab-pane fade active show"){
        var stock = $("#search-symbol")[0].value;
        var user = $("#searchUser")[0].value;
        var keyword = $("#searchKeyword")[0].value;
        var number = $("#searchNumberOfTweets")[0].value;
        collectUser(stock,user,keyword,number);
    }
    else if($("#comparison-trends")[0].className == "tab-pane fade active show"){
        var stock = $("#search-symbol")[0].value;
        var hashtag = $("#searchHashtag")[0].value;
        collectTrends(stock,hashtag);
    }
    else{
        var stock = $("#search-symbol")[0].value;
        collectStock(stock);
    }
    
}

function searchPage() {
    $('.card#search').addClass('full-width')
    $('.main-page').css('display', 'none');
    $('.search-page').attr('style', 'display: block !important');
}

function mainPage() {
    $('.card#search').removeClass('full-width')
    $('.main-page').css('display', 'block');
    $('.search-page').attr('style', '');
    history.pushState({}, "", "?");
}