export function AnimacionOops() {
    const anim = document.querySelector(".anim_oops")

    var animation = bodymovin.loadAnimation({
        container: anim, // Required
        path: '/Json/PageNoFoundJson/Oops.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "CargaMail", // Name for future reference. Optional.
    })
}