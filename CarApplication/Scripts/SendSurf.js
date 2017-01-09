(function () {
    var chatme = $.connection.chat; 

    chatme.client.addMessage = function (message) {
        $('#listMessages').append('<li>' + message + '</li>');

    };

    $("#SendMessage").click(function () {
        var msg = $("#msg").val();
        

        var userName = $('#userName').val();
        chatme.server.send(userName, msg);
        $("#msg").val('');
        
    });

    //var Model = function () {
    //    var self = this;
    //    self.message = ko.observable(""),
    //    self.messages = ko.observableArray()
    //};

    //Model.prototype = {
    //    sendMessage: function () {
    //        var self = this;
    //        chat.server.send(self.message());
    //        self.message("");
    //    },
    //    addMessage: function (message) {
    //        var self = this;
    //        self.messages.push(message);
    //    }
    //};

    //var model = new Model();
    //$(function () {
    //    ko.applyBindings(model);
    //});

    $.connection.hub.start();    

}());