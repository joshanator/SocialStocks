function search() {
    if(!$('.card#search').hasClass('full-width')) {
        searchPage();
    }
    if($("#comparison-user")[0].className == "tab-pane fade active show"){
        collectUser();
    }
    else if($("#comparison-trends")[0].className == "tab-pane fade active show"){
        collectTrends();
    }
    else{
        collectStock();
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
}