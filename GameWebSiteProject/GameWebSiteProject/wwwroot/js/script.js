var count = 0;
setInterval(function () {
    document.getElementById("headpic").style.backgroundPosition = '-' + ++count + 'px';
}, 100);

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgInp").change(function () {
    readURL(this);
});

$(document).ready(function () {
    var connection = new WebSocketManager.Connection("ws://localhost:5000/chat");
    connection.enableLogging = true;

    connection.connectionMethods.onConnected = () => {

    }

    connection.connectionMethods.onDisconnected = () => {

    }

    connection.clientMethods["pingMessage"] = (subject, username, avatar, content, time) => {

        var avatarSrc = 'data:image/jpeg; base64,' + avatar;
        $('#messages').append('<li id="row">' +
            '<div id="message-body">' + '<div id="desc">' + '<img id="messageAvatar" src="' + avatarSrc + '">' +
            '<h4><strong>' + username + '</strong></h4>' + 
            '<h5><strong>"' + subject + '"</strong></h5></div>' +
            '<div id="message-con">' + '<p id="messageText"><strong>' + content + '<strong></p>' +
            '<strong id="messageDate">"' + time + '"</strong>' +
            '</div ></div > <li>');
        $('#messages').scrollTop($('#messages').prop('scrollHeight'));
        }

        connection.start();

        var username;
        var $username = $('#username');
        var $userid = $('#userid');
        var $subject = $('#subject');
        var $messagecontent = $('#message-content');
    $messagecontent.keyup(function (e) {
        if (e.keyCode == 13) {
            var userid = $userid.val();
            var subject = $subject.val().trim();
            var content = $messagecontent.val().trim();
            
            if (content.length == 0) {
                return false;
            }
            connection.invoke("SendMessage", userid, subject, content);
            $messagecontent.val('');
        }
    });
    $('#messages').scrollTop($('#messages').prop('scrollHeight'));
});



