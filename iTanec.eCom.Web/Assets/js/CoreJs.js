/*

//Below code for navigation alert start here
var catcher = function () {
    var changed = false;
    
    $('form').each(function () {
        console.log($(this).data('initialForm'));
        console.log($(this).serialize());
        if ($(this).data('initialForm') != $(this).serialize()) {

            changed = true;
            console.log("changed" + changed);
            $(this).addClass('changed');
        } else {
            $(this).removeClass('changed');
        }
    });
    console.log("changed 1111" + changed);
    if (changed) {        
        return 'If you have made any changes to the fields without clicking the Submit/ Save button, your changes will be lost.';
    }
};

//Below code for navigation alert end here
*/


var isModelOpened = false;
var avoidUnSavedCheck = false;
var dataChanged = false;
var dataDialogChanged = false;
var isGlobalSearch = false;
var deplaySetTimeout = 100;

function SetInputChangedEvent() {
    $('form :input').change(function () {

        //$('.modal-dialog input').change(function () {
        //   dataDialogChanged = true;
        //});
        //console.log("data changes on form");
        
        if (!isModelOpened && !avoidUnSavedCheck && !isGlobalSearch) {
            dataChanged = true;
        }
        else if (isModelOpened) {
            dataDialogChanged = true;
        }
        isGlobalSearch = false;
        //console.log(dataChanged);
        //console.log(dataDialogChanged);
    });
}

$(document).ready(function () {

    //alert(dataChanged);
    //Below code for navigation alert start here

    /*$('form').each(function () {        
        $(this).data('initialForm', $(this).serialize());
    })*/

    //below code used in tenant tab
    //$('#tenant-tab-nav').bind('click', function () {
    $(document).click(function (e) {
        if ($(e.target).closest("a").length > 0) {
            
            //if (dataChanged) {
             //   $(window).bind('beforeunload', catcher);                
            //}

            window.onbeforeunload = function (e) {
                if (dataChanged == true) {
                    var changed = false;

                    $('form').each(function () {
                        console.log($(this).data('initialForm'));
                        console.log($(this).serialize());
                        if ($(this).data('initialForm') != $(this).serialize()) {

                            changed = true;
                            //console.log("changed" + changed);
                            $(this).addClass('changed');
                        } else {
                            $(this).removeClass('changed');
                        }
                    });
                    console.log("changed 1111" + changed);
                    if (changed) {
                        return 'If you have made any changes to the fields without clicking the Submit/ Save button, your changes will be lost.';
                    }
                    //return "Are you sure to exit?";
                }
            }
        }
    });

    
    $('.child-page').on('click', function () {
        //alert("66666");
        console.log("open child-page");
        isModelOpened = true;  

    });

    $('.page-cancel').on('click', function () {
        //alert("5555");
        dataChanged = false;        
        //console.log(dataChanged);
        //console.log(dataDialogChanged);
    });

    $('.child-page-cancel').on('click', function () {
        //alert("444444");
        isModelOpened = false;
        dataDialogChanged = false;
        //console.log(dataChanged);
        //console.log(dataDialogChanged);
    });

    $('.child-page-close').on('click', function () {
        //alert("333333");
        isModelOpened = false;
        dataDialogChanged = false;
        //console.log(dataChanged);
        //console.log(dataDialogChanged);
    });

    $('.page-save').on('click', function () {
        //alert("22222");
          //  dataChanged = false;
        //alert(dataChanged);
        //console.log(dataChanged);
        //console.log(dataDialogChanged);

    });

    $('.child-page-save').on('click', function () {
        //isModelOpened = false; //moved to RenderInformationalMessage, set ths flag to false if successfully saved
        //alert("11111");
        dataDialogChanged = false;
        //console.log(dataChanged);
        //console.log(dataDialogChanged);
    });


    /*$('.modal').on('shown', function () {
        alert("Hi");
        //$(this).find('input').focus();
    });*/


    $('.currency').on('focus', function () {
        if (parseInt($(this).val()) == 0) {
            $(this).val("");
        }
    });
    $('.currency').on('blur', function () {
        if ($(this).val() == "") {
            $(this).val("0");
        }
    });

    /*$(".modal-content").draggable({
        handle: ".modal-header"
    });*/


    $('.input-numeric').keydown(function (event) {

        // Allow special chars + arrows 
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9
            || event.keyCode == 27 || event.keyCode == 13
            || (event.keyCode == 65 && event.ctrlKey === true)
            || (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        } else {
            // If it's not a number stop the keypress
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });
    $('.input-decimal').keydown(function (event) {
        // Allow special chars + arrows 
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9
            || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 190 || event.keyCode == 110
            || (event.keyCode == 65 && event.ctrlKey === true)
            || (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        } else {
            // If it's not a number stop the keypress
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });
    $('input.basicdate').datepicker({
        format: 'mm/dd/yyyy',
        forceParse: false
    }).on('changeDate', function (e) {

        $(this).datepicker('hide');
    });

    //$('input.basictime').timepicker();

    /*$('input.maskPhone').mask("(999) 999-9999");
    $('input.maskSSN').mask("999-99-9999");
    $('input.basicdate').mask("99/99/9999");*/
});
var CoreJs = function () {

    function Initialize() {
        myValue = 1;
    }

    return {

        MakeReadOnly: function (contentHtml, isLocked) {
            var retHtml = contentHtml;
            if (retHtml.length > 0) {
                var templateHolder;
                if ($("#templateHolder").length === 0) {
                    $('body').append('<div id="templateHolder" style="display:none;height:0px"> </div>');
                }
                templateHolder = $("#templateHolder");
                $(templateHolder).html('');
                $(templateHolder).html(contentHtml);

                if (isLocked === true) {
                    $(templateHolder).find('input[type=text]').each(function () {
                        $(this).replaceWith($("<span />").text(this.value));
                    });

                    $(templateHolder).find('input[type=checkbox]').each(function () {
                        var replaceVal = ' Yes- ';
                        if ($(this).is(':checked')) {
                            replaceVal = ' Yes- ';
                        }
                        else {
                            replaceVal = ' No- ';
                        }
                        $(this).replaceWith($("<span />").text(replaceVal));
                    });

                    $(templateHolder).find('a').each(function () {
                        $(this).replaceWith('');
                    });

                    $(templateHolder).find('select').each(function () {
                        var curVal = ($(this).find("option:selected").text().toLowerCase().indexOf('select'.toLocaleLowerCase())) > -1 ? ' ' : $(this).find("option:selected").text();
                        $(this).replaceWith($("<span />").text(curVal));
                    });

                    $(templateHolder).find('textarea').each(function () {
                        var curVal = $(this).text();
                        $(this).replaceWith($("<div />").html(curVal));
                    });

                    retHtml = $(templateHolder).html();
                }
                else {
                    retHtml = contentHtml;
                }
            }
            return retHtml;
        },
        AjaxGet: function (url, data, callback) {
            $.ajax({
                type: "GET",
                url: url,
                data: data,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (data) {
                    callback(data);

                },
                error: RequestFailed
            });
        },
        PostAjaxIgnorePace: function (action, data, callback, failure) {
            action = baseUrl + action;
            Pace.ignore(
                function () {
                    $.ajax({
                        url: action,
                        type: 'POST',
                        data: data,
                        dataType: 'json',
                        processData: false,
                        contentType: 'application/json; charset=utf-8',
                        success: function (response, data) {
                            if (typeof callback == 'function') {
                                callback(response, data);
                            }
                        },
                        error: function (response) {
                            if (typeof failure == 'function') {
                                failure(response, data);
                            }
                        }
                    });
                }
                );

        },
        PostAjax: function (action, data, callback) {
            action = baseUrl + action;
            $.ajax({
                url: action,
                type: "POST",
                data: JSON.stringify(data),
                datatype: "json",
                processData: false,
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (callback === undefined)
                        RequestCompleted(response, data);
                    else
                        callback(response);
                },
                fail: function (response) {
                    RequestFailed(response, data);
                },
                error: function (response, ajaxOptions, thrownError) {
                    RequestFailed(response, data);
                }
            });

        },

        PostAjax2: function (action, data, callback) {

            var jqxhr = $.post(action, data, function (returnedViewModel) {
                callback(returnedViewModel.ViewModel);
            })
            .done(function () { })
            .fail(function () { alert("error"); })
            .always(function () { })

        },
        PostAjax3: function (action, data, callback) {
            action = baseUrl + action;
            $.ajax({
                url: action,
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (callback === undefined)
                        RequestCompleted(response, data);
                    else
                        callback(response);
                },
                fail: function (response) {
                    RequestFailed(response, data);
                },
                error: function (response, ajaxOptions, thrownError) {
                    RequestFailed(response, data);
                }
            });

        },

        PostAjaxPartialView: function (action, data, callback) {

            var jqxhr = $.post(action, data, function (returnedView) {
                callback(returnedView);
            })
            .done(function () { })
            .fail(function () { alert("error"); })
            .always(function () { })

        },

        RenderValidationErrors: function (validationErrors) {

            for (var val in validationErrors) {
                document.getElementById(val).setAttribute("class", "validation-error");
            }
        },

        ClearValidationErrors: function () {
            $(':input').removeClass('validation-error');

        },

        FormatJsonDate: function (jsonDate) {

            if (jsonDate == null) return "";
            if (jsonDate.length == 0) return "";

            var year = jsonDate.substr(0, 4);
            var month = jsonDate.substr(5, 2);
            var day = jsonDate.substr(8, 2);

            var tempDate = month + "/" + day + "/" + year;
            var date = new Date(tempDate);

            var monthOfYear = parseInt(date.getMonth() + 1);
            var dayOfMonth = parseInt(date.getDate());

            if (monthOfYear < 10)
                monthOfYear = "0" + monthOfYear;

            if (dayOfMonth < 10)
                dayOfMonth = "0" + dayOfMonth;

            var output = monthOfYear + "/" + dayOfMonth + "/" + date.getFullYear();
            if (year == '0001')
                output = '';

            return output;
        },


        FormatDateTime: function (jsonDate) {

            if (jsonDate == null) return "";
            if (jsonDate.length == 0) return "";

            var d = new Date(parseInt(jsonDate.substr(6)));
            var year = d.getFullYear();
            var month = MVC5WebApplication.Pad(d.getMonth() + 1);
            var day = MVC5WebApplication.Pad(d.getDate());
            var hour = MVC5WebApplication.Pad(d.getHours());
            var minutes = MVC5WebApplication.Pad(d.getMinutes());

            var dd = "AM";
            var h = hour;
            if (h >= 12) {
                h = hour - 12;
                dd = "PM";
            }
            if (h == 0) {
                h = 12;
            }

            var output = month + "/" + day + "/" + year + " " + h + ":" + minutes + " " + dd;

            return output;
        },

        Pad: function (num) {
            num = "0" + num;
            return num.slice(-2);
        },

        FormatDateMMDDYYYY: function (date) {

            var date = new Date(date);

            var monthOfYear = parseInt(date.getMonth() + 1);
            var dayOfMonth = parseInt(date.getDate());

            if (monthOfYear < 10)
                monthOfYear = "0" + monthOfYear;

            if (dayOfMonth < 10)
                dayOfMonth = "0" + dayOfMonth;

            var output = monthOfYear + "/" + dayOfMonth + "/" + date.getFullYear();
            return output;
        },


        DisplayTransactionStatus: function (statusNumber) {
            if (statusNumber == "1")
                return "Draft";
            if (statusNumber == "2")
                return "Approved";
            if (statusNumber == "3")
                return "Paid";
        },

        DisplayAjax: function () {

            $("#AjaxIndicator").dialog({
                resizable: false,
                position: 'center',
                height: 120,
                width: 300,
                modal: true,
                dialogClass: 'ajax-modal'
            });

        },

        HideAjax: function () {
            $("#AjaxIndicator").dialog('close');
        },

        RenderErrorMessage: function (errorMessage) {            
            var returnMessage = "";
            if (errorMessage == undefined || errorMessage == '')
                CoreJs.HideAjax();
            if (errorMessage != undefined) {
                //for (var i = 0; i < errorMessage.length; i++) {
                //    alert(errorMessage[i]);
                //    returnMessage = returnMessage + errorMessage[i] + "<br/>";
                //}

                //noty({
                //    text: '<strong>' + errorMessage + '</strong>', layout: 'topRight', type: 'error', timeout: false, buttons: [
                //{ addClass: 'btn btn-danger btn-xs', text: 'Ok', onClick: function ($noty) { $noty.close(); } }]
                //});

                /*$.pnotify({
                    title: 'Error',
                    text: errorMessage,
                    type: 'error',
                    addclass: "alert-danger",
                    hide: false                    
                });*/

                PNotify.prototype.options.confirm.buttons = [];

                new PNotify({
                    title: 'Error',
                    text: errorMessage,
                    type: 'error',
                    addclass: "alert-danger",
                    hide: false,
                    confirm: {
                        confirm: true,
                        buttons: [{
                            text: 'Ok',
                            addClass: 'ok',
                            click: function (notice) {
                                notice.remove();
                            }
                        }]
                    },
                    buttons: {
                        closer: true,
                        sticker: false
                    },
                    after_open: function (ui) {
                        $(".ok", ui.container).focus();
                    }
                })
            }
            CoreJs.HideAjax();

        },

        IsGuidEmpty: function (guid) {
            var emptyGuid = "00000000-0000-0000-0000-000000000000";
            if (guid == emptyGuid)
                return true;
            else
                return false;
        },

        SetEmptyGuid: function () {
            var emptyGuid = "00000000-0000-0000-0000-000000000000";
            return emptyGuid;
        },

        RenderInformationalMessage: function (informationalMessage) {

            var $notifyMsg      = informationalMessage;
            var $notifyType     = 'info';
            var $notifyFrom     = 'top';
            var $notifyAlign    = 'right';
            var $notifyIcon     = 'fa fa-info-circle';
            var $notifyUrl      = '';

            jQuery.notify({
                icon: $notifyIcon,
                message: $notifyMsg,
                url: $notifyUrl
            },
                {
                    element: 'body',
                    type: $notifyType,
                    allow_dismiss: true,
                    newest_on_top: true,
                    showProgressbar: false,
                    placement: {
                        from: $notifyFrom,
                        align: $notifyAlign
                    },
                    offset: 20,
                    spacing: 10,
                    z_index: 1033,
                    delay: 5000,
                    timer: 1000,
                    animate: {
                        enter: 'animated fadeIn',
                        exit: 'animated fadeOutDown'
                    }
                });

        },

        DisplayAjax: function () {
            console.log(new Date());
            $.blockUI.defaults.css.border = '1px solid black';
            $.blockUI.defaults.overlayCSS.backgroundColor = 'white';
            $.blockUI.defaults.overlayCSS.opacity = .3;
            $.blockUI({ message: '<h3><img src="../img/ajax-loader.gif" /> Executing request...</h3>' });

        },

        HideAjax: function () {
            console.log(new Date());
            $.unblockUI();
        },

        dataTable: function (target) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "aaSorting": [],
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]]
                });

            return dt;
        },
        dataTable2: function (target) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "aaSorting": [],
                    "bAutoWidth": false,
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "oLanguage": {
                        "sEmptyTable":     "No information found."
                    },
                    "aLengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]]
                });

            return dt;
        },
        dataTable3: function (target) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "aaSorting": [],
                    "bAutoWidth": false,
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[5, 10], [5, 10]]
                });

            return dt;
        },
        dataTableBasicWithLimitation: function (target) {
            var dt = $(target).dataTable(
                {
                    "bFilter": false,
                    "bJQueryUI": false,
                    "sPaginationType": "full_numbers",
                    "bPaginate": false,
                    "bInfo": false,
                    "bSort": false,
                    'scrollY': 70,
                    'sDom': 't'
                });

            return dt;
        },
        dataTableFull: function(target){
            var dt = $(target).dataTable({
                columnDefs: [{ orderable: false, targets: [4] }],
                pageLength: 10,
                lengthMenu: [[5, 10, 15, 20], [5, 10, 15, 20]]
            });
        },
        dataTableBasic: function (target) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "columnDefs": [{ orderable: false, targets: [4] }],
                    "bSort": true,
                    "bAutoWidth" : false,
                    'filter': true,
                    'info': true,
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[20, 50, 100 - 1], [20, 50, 100, "All"]],
                    "fnDrawCallback": function (oSettings) {
                        
                    }
                });

            return dt;
        },
        dataTableBasic2: function (target) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "bSort": false,
                    "bAutoWidth": false,
                    "aaSorting": [],
                    'filter': false,
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "oLanguage": {
                        "sEmptyTable": "No data available."
                    },
                    "aLengthMenu": [[20, 50, 100 - 1], [20, 50, 100, "All"]],
                    "fnDrawCallback": function (oSettings) {

                    }
                });

            return dt;
        },
        
        dataTableBasicWithSearch: function (target) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "aaSorting": [],
                    'filter': true,
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[20, 50, 100 - 1], [20, 50, 100, "All"]]
                });

            return dt;
        },
        dataTableBasicWithSearchAndDefaultSort: function (target, columnToSort, sortBy) {
            var dt = $(target).dataTable(
                {
                    //'bRetrieve': true,
                    //"bJQueryUI": true,
                    //"sDom": "<'row'<'col-sm-6'<'dt_actions'>l><'col-sm-6'f>r>t<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    //"oLanguage": {
                    //    "sLengthMenu": "_MENU_ records per page"

                    //}
                    "aaSorting": [],
                    'filter': true,
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[20, 50, 100 - 1], [20, 50, 100, "All"]],
                    "order": [[columnToSort, sortBy]]
                });

            return dt;
        },
       
        customDataTableWithTotal: function (target, sumColumnIndex) {
            var dt = $(target).dataTable(
                {
                    "aaSorting": [],
                    'filter': true,
                    'info': false,
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[20, 50, 100 - 1], [20, 50, 100, "All"]],
                    "footerCallback": function (row, data, start, end, display) {
                        var api = this.api();

                        var intval = function (i) {
                            //Excuse this ugliness, it comes from the datatables sample

                            return typeof i === 'string' ?
                                i.replace(/[\$,]/g, '') * 1 :
                                typeof i === 'number' ?
                                i : 0;
                        };


                        //var sumColumnIndex = 7;//$('th').filter(function (i) { return $(this).text() == 'Cost'; }).first().index();
                        var totalData = api.column(sumColumnIndex).data();
                        var total = totalData.reduce(function (a, b) { return intval(a) + intval(b); }, 0).toFixed(2);
                        var pageTotalData = api.column(sumColumnIndex, { page: 'current' }).data();
                        var pageTotal = pageTotalData.reduce(function (a, b) { return intval(a) + intval(b); }, 0).toFixed(2);
                        var searchTotalData = api.column(sumColumnIndex, { 'filter': 'applied' }).data();
                        var searchTotal = searchTotalData.reduce(function (a, b) { return intval(a) + intval(b); }, 0).toFixed(2);

                        if (searchTotal != null)
                            searchTotal = numeral(searchTotal).format('$0,0.00');

                        // Update footer
                        $(api.column(sumColumnIndex).footer()).html(

                              searchTotal
                        );
                    }

                });

            return dt;
        },
        customDataTable: function (target, sumColumnIndex, formId, element) {
            var dt = $(target).dataTable(
                {
                    "aaSorting": [],
                    'filter': true,
                    'info': false,
                    //"bServerSide": true,
                    "bDestroy": true,
                    "fnDrawCallback": function () {
                        
                        $(formId).find(element).each(function () {
                            $(this).attr('checked', false);
                        });
                    },
                    'sDom': 'lTfr<"clearfix">tip',
                    "aLengthMenu": [[20, 50, 100 - 1], [20, 50, 100, "All"]],
                    "aoColumnDefs": [
                                      { 'bSortable': false, 'aTargets': [0] }
                    ],
                    "footerCallback": function (row, data, start, end, display) {
                        var api = this.api();

                        var intval = function (i) {
                            //Excuse this ugliness, it comes from the datatables sample

                            return typeof i === 'string' ?
                                i.replace(/[\$,]/g, '') * 1 :
                                typeof i === 'number' ?
                                i : 0;
                        };


                        //var sumColumnIndex = 7;//$('th').filter(function (i) { return $(this).text() == 'Cost'; }).first().index();
                        var totalData = api.column(sumColumnIndex).data();
                        var total = totalData.reduce(function (a, b) { return intval(a) + intval(b); }, 0).toFixed(2);
                        var pageTotalData = api.column(sumColumnIndex, { page: 'current' }).data();
                        var pageTotal = pageTotalData.reduce(function (a, b) { return intval(a) + intval(b); }, 0).toFixed(2);
                        var searchTotalData = api.column(sumColumnIndex, { 'filter': 'applied' }).data();
                        var searchTotal = searchTotalData.reduce(function (a, b) { return intval(a) + intval(b); }, 0).toFixed(2);

                        if (searchTotal != null)
                            searchTotal = numeral(searchTotal).format('$0,0.00');

                        // Update footer
                        $(api.column(sumColumnIndex).footer()).html(

                              searchTotal
                        );
                    }

                });

            return dt;
        },
        refreshTable: function (target) {
            if (target != undefined) {
                target.fnClearTable();
                target.fnDestroy();
            }
        },
        FormatCurrency: function (num) {
            if (num == null)
                return numeral(0).format('$0,0.00');;

            var amount = numeral(num).format('$0,0.00');

            return amount;
        },
        FormatDecimal: function (num) {
            if (num == null)
                return numeral(0).format('0,0.00');;

            var amount = numeral(num).format('0,0.00');

            return amount;
        },
        FormatDate: function (dateString) {
            if (dateString == null)
                return null;

            var date = moment(dateString).format("MM/DD/YYYY");

            if (date == '01/01/1900' || date == '01/01/0001')
                date = null;
            return date;
        },

        pickList: function (target, sourceLabel, targetLabel) {
            $(target).pickList({
                addAllLabel: '<i class="fa fa-forward"></i>',
                addLabel: '<i class="fa fa-caret-right"></i>',
                removeAllLabel: '<i class="fa  fa-backward"></i>',
                removeLabel: '<i class="fa fa-caret-left"></i>',
                sourceListLabel: sourceLabel,
                targetListLabel: targetLabel
            });
        },
        refreshPickList: function (target) {
            $(target).empty();
            $(target).pickList("destroy");
        },
        getPickList: function (target) {
            var selectedItems = $(target).serialize();
            var splitItems = selectedItems.split('&');
            var assignedItems = [];
            for (var i = 0; i < splitItems.length; i++) {
                var splitItemId = splitItems[i].split('=');
                console.log(splitItems[i]);
                assignedItems.push(splitItemId[1]);
            }
            return assignedItems.join(',');
        }

    };

}();

function RequestFailed(response, model) {
    var jsonResponse = jsonParse(response.responseText);
    /*model.MessageBox("");
    model.MessageBox(CoreJs.RenderErrorMessage(jsonResponse.ReturnMessage));*/
    CoreJs.RenderErrorMessage(jsonResponse.ReturnMessage);    
}

function RequestFailedError(response) {
    CoreJs.ClearValidationErrors();
    var message = [];
    message.push(response);
    CoreJs.RenderErrorMessage(message);
}

function RequestCompleted(response, model) {
    CoreJs.ClearValidationErrors();
    CoreJs.RenderInformationalMessage(response.ReturnMessage);
    CoreJs.HideAjax();
}




/*Validation Starts here*/

function jQueryValidatorWrapper(formId) {
    // Get an Id for the "<div>" to diaply the error messages.
    // The Id is made sure to be unique in the web page.
    var rules = {
    };
    var messages = {
    };
    $("#" + formId + " div").removeClass("f_error");
    var n = 0;
    // hook up the form, the validation rules, and messages with jQuery validate.

    var validator = $("#" + formId).validate({

        rules: rules,
        messages: messages,

        //Therefore the error labels are also wrapped into li elements (wrapper option).
        focusInvalid: false,
        onkeyup: false,
        focusCleanup: false,
        onclick: false,
        onfocus: false,
        onblur: false,
        onfocusout: false,
        onchange: false,
        errorClass: 'error',
        validClass: 'valid',
        highlight: function (element) {
            $(element).closest('div').addClass("f_error");
            console.log('highlight');
        },
        unhighlight: function (element) {
            $(element).closest('div').removeClass("f_error");
            console.log('unhighlight');
        },
        errorPlacement: function (error, element) {
        },
        showErrors: function (errorMap, errorList) {
            //PNotify.removeAll();
            
            var messages1 = "";
            n = 0;
            if (n != errorList.length)
                n = errorList.length;
            else
                n = 0;
            $.each(errorList, function (index, value) {
                if (n == errorList.length) {
                    messages1 += "<li>" + value.message + "</li>";
                }

            });

            if (messages1 != '') {
                PNotify.prototype.options.confirm.buttons = [];
                //alert(dataChanged);
                
                new PNotify({
                    title: 'Please correct the following errors:',
                    text: "<ul>" + messages1 + "</ui>",
                    type: 'error',
                    hide: false,
                    confirm: {
                        confirm: true,
                        buttons: [{
                            text: 'Ok ',
                            addClass: 'ok',
                            click: function (notice) {
                                notice.remove();                                
                            }
                        }]
                    },
                    buttons: {
                        closer: true,
                        sticker: false
                    },
                    after_open: function (ui) {
                        $(".ok", ui.container).focus();                        
                    }
                })

                
                /*$.pnotify({
                    title: 'Please correct the following errors:',
                    text: "<ul>" + messages1 + "</ui>",
                    type: 'error',
                    hide: false,
                    confirm: {
                        confirm: true,
                        buttons: [{
                            text: 'Okay!',
                            addClass: 'ok'
                        }, {
                            text: 'No!',
                            addClass: 'no'
                        }]
                    },
                    buttons: {
                        closer: true,
                        sticker: false
                    },
                    after_open: function (ui) {
                        $(".ok", ui.container).focus();
                    }
                });*/

            }
        }
    });

    // This is the function to call whem make the validation
    this.validate = function () {
        var result = validator.form();
        validator.resetForm();
        return result;
    };
    /*this.addMethod = function (name, func, message) {
        $.validator.addMethod(name, func, message);
    };*/

    $.validator.addMethod("isDate", function (value, element) { return isDate(value); }, "Please enter a valid date")
    $.validator.addMethod("futuredate", function (value, element) {
        var sysdate = new Date();
        var value = new Date(value);
        if (value > sysdate) {
            return false;
        }
        else {
            return true;
        }

    }, "");

    $.validator.addMethod("dobcheck", function (value, element) {
        var today = new Date();
        var birthDate = new Date(value);
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        if (age < 14 || age > 100) {
            return false;
        }
        else {
            return true;
        }

    }, "");

    $.validator.addMethod("validphone", function (value, element) {
        //If false, the validation fails and the message below is displayed
        var CharactersRegex = /^(?:(?:\(?(?:00|\+)([1-4]\d\d|[1-9]\d?)\)?)?[\-\.\ \\\/]?)?((?:\(?\d{1,}\)?[\-\.\ \\\/]?){0,})(?:[\-\.\ \\\/]?(?:#|ext\.?|extension|x)[\-\.\ \\\/]?(\d+))?$/i
        if (CharactersRegex.test(value)) {
            return true;
        }
        else {
            return false;
        }
    }, "");

    jQuery.validator.addMethod("comparedates", function (value, element, params) {
        var startdate = new Date(params[0]);
        var enddate = new Date(params[1]);
        if (startdate >= enddate) {
            return false;
        }
        else
            return true;
    }, "");
}

function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal == '')
        return false;

    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/; //Declare Regex
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray == null)
        return false;

    //Checks for mm/dd/yyyy format.
    dtMonth = dtArray[1];
    dtDay = dtArray[3];
    dtYear = dtArray[5];

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }
    return true;
}

function GetQueryStringValueByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}



