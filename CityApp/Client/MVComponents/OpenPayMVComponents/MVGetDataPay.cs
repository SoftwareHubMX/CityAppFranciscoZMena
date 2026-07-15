namespace CityApp.Client.MVComponents.OpenPayMVComponents
{
    public class MVGetDataPay
    {
        public event EventHandler<(string, string)> metodoAlQueSeSuscrive;

        public async Task metodoQueEjecutaElMetodoAlQueSePuedeSuscribir(string idToken, string deviceName)
        {
            metodoAlQueSeSuscrive?.Invoke(this, (idToken, deviceName));
        }

        public async void ejecutar(string idToken, string deviceName)
        {
            metodoQueEjecutaElMetodoAlQueSePuedeSuscribir(idToken, deviceName);
        }
    }
}
