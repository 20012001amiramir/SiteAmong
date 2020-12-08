var count = 0;
setInterval(function () {
    document.getElementById("headpic").style.backgroundPosition = '-' + ++count + 'px';
}, 100);