namespace CQRSImplementation.Application.Exceptions
{
    public class TimesNotAvaibleException : Exception
    {

        public TimesNotAvaibleException(string companyName) : base($"{companyName} firması girilen saatler arasında sipariş almamaktadır , işlem başarısız.")
        {

        }

    }
}
