export function AnimacionPassword() {
    const anim = document.querySelector(".anim_password")

    var animation = bodymovin.loadAnimation({
        container: anim, // Required
        path: '/Json/CardRestaurarPassJson/Password.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "Password", // Name for future reference. Optional.
    })
}