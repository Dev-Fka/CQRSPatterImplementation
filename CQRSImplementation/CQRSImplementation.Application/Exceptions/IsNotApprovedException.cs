namespace CQRSImplementation.Application.Exceptions
{
    public class IsNotApprovedException : Exception
    {

        public IsNotApprovedException() : base("Firma Onaylı değil , işlem başarısız!")
        {

        }

    }
}
