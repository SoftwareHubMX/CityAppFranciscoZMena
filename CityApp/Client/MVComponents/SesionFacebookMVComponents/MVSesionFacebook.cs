namespace CityApp.Client.MVComponents.SesionFacebookMVComponents
{
    public class MVSesionFacebook
    {
        public event EventHandler<string> metodoAlQueSeSuscrive;

        public async Task metodoQueEjecutaElMetodoAlQueSePuedeSuscribir(string data)
        {
            metodoAlQueSeSuscrive?.Invoke(this, data);
        }

        public async void ejecutar(string token)
        {
            metodoQueEjecutaElMetodoAlQueSePuedeSuscribir(token);
        }
    }
}
