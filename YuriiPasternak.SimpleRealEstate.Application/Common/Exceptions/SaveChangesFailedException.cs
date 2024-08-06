namespace YuriiPasternak.SimpleRealEstate.Application.Common.Exceptions
{
    public class SaveChangesFailedException : Exception
    {
        public SaveChangesFailedException(string message) : base(message)
        {
        }
    }
}
