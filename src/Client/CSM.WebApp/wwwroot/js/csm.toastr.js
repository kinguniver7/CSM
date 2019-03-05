window.csm = window.csm || {};

(function () {
  var _baseToastrEnum = {
    TOASTR: 1,
    BOOTSTRAP:2
  };

  var init = function (opt) {
    switch (opt) {
      default:
        toastr.options.positionClass = 'toast-bottom-center';
        toastr.options.closeButton = true;
        toastr.options.progressBar = true;

        window.csm.toastr = toastr;
    }
  };
  init();
})();