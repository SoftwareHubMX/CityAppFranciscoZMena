export function AnimacionReset() {
    const anim = document.querySelector(".anim_reset")

    var animation = bodymovin.loadAnimation({
        container: anim, // Required
        path: '/Json/CardResetInicioSesionJson/Reset.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "Reset", // Name for future reference. Optional.
    })
}