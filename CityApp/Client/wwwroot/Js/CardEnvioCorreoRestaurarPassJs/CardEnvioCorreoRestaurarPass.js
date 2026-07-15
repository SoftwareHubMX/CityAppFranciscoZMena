export function AnimacionEnvioMail() {
    const anim = document.querySelector(".anim_envio_mail")

    var animation = bodymovin.loadAnimation({
        container: anim, // Required
        path: '/Json/CardEnvioCorreoRestaurarPassJson/EnvioMail.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "EnvioMail", // Name for future reference. Optional.
    })
}