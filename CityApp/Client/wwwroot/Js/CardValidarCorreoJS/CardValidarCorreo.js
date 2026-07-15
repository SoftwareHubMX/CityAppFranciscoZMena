export function AnimacionCargaMail() {
    const anim = document.querySelector(".anim_carga_mail")

    var animation = bodymovin.loadAnimation({
        container: anim, // Required
        path: '/Json/CardValidarCorreoJson/CargaMail.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "CargaMail", // Name for future reference. Optional.
    })
}