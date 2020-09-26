$("body").on("keypress",function(event) {
   $("h1").text($("h1").text() + event.key);
})
