export function AnimacionNosotros() {
    const anim = document.querySelector(".anim_nosotros")
    const anim2 = document.querySelector("anim_nosotros_2");

    var animation = bodymovin.loadAnimation({
        container: anim, // Required
        path: '/Json/Index/city-app.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "CityApp", // Name for future reference. Optional.
    });

    var animation2 = bodymovin.loadAnimation({
        container: anim2, // Required
        path: '/Json/Index/city-app.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "CityApp", // Name for future reference. Optional.
    });
}