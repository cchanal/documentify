var EditAPI = (function () {
    function init() {
        $('.jumbotron, article').froalaEditor({
            toolbarInline: true,
            charCounterCount: false,
            language: 'fr',
            toolbarButtons: ['paragraphFormat', 'bold', 'italic', 'underline', 'strikeThrough', 'align', '-', 'formatOL', 'formatUL', '|', 'insertLink', 'insertTable', 'undo', 'redo']
        })
    }

    return{
        init: init
    }
})();