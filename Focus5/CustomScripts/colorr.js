
var ulel = document.querySelectorAll('.switcher li');
    var cl = [];

        for (i = 0; i < ulel.length; i++) {
        cl.push(ulel[i].getAttribute('data-color'));
            ulel[i].addEventListener('click', function(){
                document.body.classList.remove(...cl);
                document.body.classList.add(this.getAttribute('data-color'));
            },
                false
            );
        }
 