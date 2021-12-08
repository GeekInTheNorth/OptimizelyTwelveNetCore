$(document).ready(function () {

    var myModal = new bootstrap.Modal(document.getElementById("edit-robots-content-modal"), {
        keyboard: false
    });

    $(".js-edit-button").click(function () {
        let siteId = $(this).data("siteid");
        $.get("/Robots/Edit/", { siteId: siteId })
            .done(function (data) {
                $(".js-modal-title").html(data.siteName);
                $(".js-modal-siteid").html(data.siteId);
                $(".js-modal-robots-content").html(data.robotsContent);

                myModal.toggle();
            })
            .fail(function () {
                alert("fail");
            });
    });
});