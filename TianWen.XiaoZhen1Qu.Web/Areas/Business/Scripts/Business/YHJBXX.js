KISSY.ready(function (S) {
    KISSY.use('dom,event,anim', function (S, DOM, Event, Anim) {
        var btn = DOM.get('#btnReg');
        Event.on(btn, 'click', function () {
            new Anim('#demo-img', 'left: 400px; opacity: 0', 2, 'easeOut',
              function () {
                  new Anim('#demo-txt', 'left: 0; opacity: 1; fontSize: 28px', 2, 'bounceOut').run();
              }).run();
        });
    });
});