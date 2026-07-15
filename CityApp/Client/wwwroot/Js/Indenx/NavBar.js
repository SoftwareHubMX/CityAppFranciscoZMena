export function focus() {
    let btnNosostros = document.querySelector("#btn_servicios");
    let btnServicios = document.querySelector("#btn_modulos");
    let btnOfertas = document.querySelector("#btn_turismo");
    let btnTestimonios = document.querySelector("#btn_colaboradores");
    let btnContacto = document.querySelector("#btn_contacto");

    let secNosostros = document.querySelector("#Nosotros").getBoundingClientRect();
    let secServicios = document.querySelector("#Modulos").getBoundingClientRect();
    let secOfertas = document.querySelector("#Turismo").getBoundingClientRect();
    let secTestimonios = document.querySelector("#Colaboradores").getBoundingClientRect();
    let secContacto = document.querySelector("#Contacto").getBoundingClientRect();

    var numDes = 0;

    function tamañoPagina() {
        if (window.innerWidth < 600) {
            numDes = 80;
        } else {
            numDes = 55;
        }
    }

    btnNosostros.addEventListener("click", () => {
        tamañoPagina();
        window.scroll(0, (secNosostros.top - numDes));
    });

    btnServicios.addEventListener("click", () => {
        tamañoPagina();
        window.scroll(0, (secServicios.top - numDes));
    });

    btnOfertas.addEventListener("click", () => {
        tamañoPagina();
        window.scroll(0, (secOfertas.top - numDes));
    });


    btnTestimonios.addEventListener("click", () => {
        tamañoPagina();
        window.scroll(0, (secTestimonios.top - numDes));
    });

    btnContacto.addEventListener("click", () => {
        tamañoPagina();
        window.scroll(0, (secContacto.top - numDes));
    });

    var nav = document.getElementById('Nav-bar');
    window.onscroll = function () {
        var distanceScrolled = document.documentElement.scrollTop;
        if (window.innerWidth > 678) {
            if (distanceScrolled > 200) {
                nav.classList.add('fijo');
            }
            else {
                nav.classList.remove('fijo');
            }
        }
        else {
            if (distanceScrolled > 300) {
                nav.classList.add('fijo');
            }
            else {
                nav.classList.remove('fijo');
            }
        }
    }



    if (window.innerWidth > 678) {
        const sr = ScrollReveal({
            origin: 'bottom',
            distance: '30px',
            duration: 500,
            reset: true
        });

        sr.reveal(`.content__nosotros`, {
            interval: 100
        });

        sr.reveal(`.card__modulo`, {
            interval: 100
        });

        sr.reveal(`.img__turismo`, {
            interval: 100
        });

        sr.reveal(`.aparecer`, {
            interval: 100
        });

        sr.reveal(`.contactocto_content`, {
            interval: 100
        });
    }

    const sectionColaboradores = document.querySelector("#Colaboradores");
    var init = 1;
    function chanseBackground() {
        if (init == 1) {
            sectionColaboradores.classList.replace("background_1", "background_2");
            init = 2;
        }
        else {
            sectionColaboradores.classList.replace("background_2", "background_1");
            init = 1;
        }
    }

    setInterval(function () {
        chanseBackground();
    }, 6000);
}