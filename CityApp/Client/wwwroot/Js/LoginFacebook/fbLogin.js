window.fbLogin = function () {
    window.FB.login(function (response) {

        console.log(response);

        DotNet.invokeMethodAsync('CityApp.Client', 'FbLoginProcessCallback', response);

    }, { scope: 'public_profile, email, pages_show_list, pages_manage_engagement, pages_read_user_content, pages_manage_posts, pages_read_engagement, pages_manage_metadata' });
}