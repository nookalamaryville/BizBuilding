$(document).ready(function () {
  $.get("./scripts/templates/menu.htm", function (templates) {
    // Fetch the <script /> block from the loaded external
    // template file which contains menu links template.
    var template = $(templates).filter("#tpl-headermenu").html();
    $.getJSON("./scripts/json/menu.json", function (data) {
      Mustache.parse(template);
      var rendered = Mustache.render(template, data);
      $("#MenuItems").html(rendered);
    });
  });
  $("#dtyear").html(new Date().getFullYear());
});
