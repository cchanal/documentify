var EditAPI = (function () {
    function init() {
        $('.jumbotron, article').froalaEditor({
            toolbarInline: true,
            charCounterCount: false,
            toolbarButtons: ['bold', 'italic', 'underline', 'strikeThrough', 'color', 'emoticons', '-', 'paragraphFormat', 'align', 'formatOL', 'formatUL', 'indent', 'outdent', '-', 'insertImage', 'insertLink', 'insertFile', 'insertVideo', 'undo', 'redo']
        })
    }

    return{
        init: init
    }
})();