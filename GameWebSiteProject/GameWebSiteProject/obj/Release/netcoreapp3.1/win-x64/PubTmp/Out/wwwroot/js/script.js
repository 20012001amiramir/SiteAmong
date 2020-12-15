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
    var connectionChat = new WebSocketManager.Connection("ws://localhost:5000/chat");
    var connectionLike = new WebSocketManager.Connection("ws://localhost:5000/like");
    var connectionComment = new WebSocketManager.Connection("ws://localhost:5000/comment");
    connectionChat.enableLogging = true;
    connectionLike.enableLogging = true;
    connectionComment.enableLogging = true;

    connectionChat.connectionMethods.onConnected = () => {

    }

    connectionChat.connectionMethods.onDisconnected = () => {

    }

    connectionLike.connectionMethods.onConnected = () => {

    }

    connectionLike.connectionMethods.onDisconnected = () => {

    }

    connectionComment.connectionMethods.onConnected = () => {

    }

    connectionComment.connectionMethods.onDisconnected = () => {

    }

    connectionChat.clientMethods["pingMessage"] = (subject, username, avatar, content, time) => {

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

    connectionLike.clientMethods["pingLike"] = (likes) => {
        $('#likeamount').replaceWith('Likes ' + likes);  
        $('#newlikeamount').html('<p id="likeamount">Likes ' + likes + '</p>');   
    }

    connectionComment.clientMethods["pingComment"] = (foruser, username, avatar, content, time) => {
        var avatarSrc = 'data:image/jpeg; base64,' + avatar;
        $('#comments').append('<li id="row">' +
            '<div id="message-body">' + '<div id="desc">' + '<img id="messageAvatar" src="' + avatarSrc + '">' +
            '<h4><strong>' + username + '</strong></h4>' +
            '<h5><strong>To ' + foruser + '</strong></h5></div>' +
            '<div id="message-con">' + '<p id="messageText"><strong>' + content + '<strong></p>' +
            '<strong id="messageDate">"' + time + '"</strong>' +
            '</div ></div > <li>');
        $('#comments').scrollTop($('#comments').prop('scrollHeight'));
    }

    connectionLike.start(); 

    var $usernameLike = $('#usernameLikeAndComment');
    var $workname = $('#worknameInput');
    $("#like").on("click", function () {
        var usernameLike = $usernameLike.val();
        var workname = $workname.val();

        connectionLike.invoke("LeaveLike", usernameLike, workname);
    });

    connectionChat.start();

    var $usernameChat = $('#usernameChat');
        var $subject = $('#subject');
        var $messagecontent = $('#message-content');
    $messagecontent.keyup(function (e) {
        if (e.keyCode == 13) {
            var usernameChat = $usernameChat.val();
            var subject = $subject.val().trim();
            var content = $messagecontent.val().trim();
            
            if (content.length == 0) {
                return false;
            }
            connectionChat.invoke("SendMessage", usernameChat, subject, content);
            $messagecontent.val('');
        }
    });
    $('#messages').scrollTop($('#messages').prop('scrollHeight'));

    connectionComment.start();

    var $usernameComment = $('#usernameLikeAndComment');
    var $foruser = $('#foruser');
    var $commentcontent = $('#commentcontent');
    var $workname = $('#worknameInput');
    $commentcontent.keyup(function (e) {
        if (e.keyCode == 13) {
            var usernameComment = $usernameComment.val();
            var foruser = $foruser.val();
            var content = $commentcontent.val().trim();
            var workname = $workname.val();
            if (content.length == 0) {
                return false;
            }
            connectionComment.invoke("SendComment", usernameComment, workname, foruser, content);
            $commentcontent.val('');
        }
    });
    $('#comments').scrollTop($('#comments').prop('scrollHeight'));
});

document.getElementById("Dropdown").addEventListener('click', function (event) {  
    event.stopPropagation();
}); 



