var PageAPI = (function () {
    function init() {
        $(".add-section").on('click', function () {
            var lastOrderSectionNumber = $("section article").last().attr('id');
            lastOrderSectionNumber++;
            console.log("i");
            $(this).before("<article id='" + lastOrderSectionNumber + "'><h1 id='test'>Titre</h1><p>Contenu</p></article>");
            EditAPI.init();
        })
    }

    return {
        init: init
    }
})();