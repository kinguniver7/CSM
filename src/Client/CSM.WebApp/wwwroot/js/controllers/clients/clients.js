window.csm = window.csm || {};
window.csm.controllers = window.csm.controllers || {};

(function () {
  var _c = {};
  _c.init = function () {
    $("#btnCreteClient").on("click", _c.createClient);
  };

  _c.createClient = function () {
    $.ajax({
      url: "clients/create",
      type: "POST",
      data: $("#createClientForm").serialize(),
      dataType: 'json',
      success: function (result) {
        $("#createClientModal").modal('hide');
        if (window.csm.toastr) {
          window.csm.toastr.success("Success");
        }
      },
      error: function (er) {
        console.log(er);
        if (window.csm.toastr) {
          window.csm.toastr.error("Error");
        }
      }
    });
  };
  
  _c.init();
  //window.csm.controllers.clients = _c;
}());