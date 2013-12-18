$.extend({
    guid: function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
        };
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
    }
});

$.fn.extend({
    //uploadUrl:用于处理上传的页面地址，upInfoUrl：用于得到上传进度等信息的页面地址
    HXAjaxUpload: function (uploadUrl, upInfoUrl, callback) {
        var guid = getGuid();

        if ($(this).attr("type").toLowerCase() != "file") { return; }
        $(this).change(function () {
            if ($("#ajaxUploadForm")) {
                $(this).wrap("<form id='ajaxUploadForm' action='" + uploadUrl + "&g=" + guid + "' method='post' enctype='multipart/form-data'></form>");
            }
            var submitSuccess = false;
            try {
                $("#ajaxUploadForm").ajaxSubmit({ success: function (data) {
                    
                }
                });
                submitSuccess = true;
            } catch (err) {
                alert(err);
                return;
            }

            $(this).unwrap();

            //发送获取进度的异步请求，等待响应
            getPer(callback);
        });

        function getPer(cb) {
                $.get(upInfoUrl, { "g": guid }, function (data) {
                    cb(data);
                    //$("#per").html(data);
                    if (data != "100") {
                        getPer(cb);
                    }
                });
        }

        function getGuid() {
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
        }

        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
        };
    }
});