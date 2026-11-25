namespace MyApp1.Services.Interfaces
{
    public interface IBarcodeService
    {
        public byte[] GenerateBarcode(string codice);
    }
}
