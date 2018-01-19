function search() {
    if(!$('.card#search').hasClass('full-width')) {
        searchPage();
    }
    collect();
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