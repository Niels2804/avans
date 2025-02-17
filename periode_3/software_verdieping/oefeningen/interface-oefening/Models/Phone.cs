using interface_oefening.Models.Interfaces;

namespace interface_oefening.Models
{
    public class Phone : ISellableItem
    {
        private string _manufacturer;
        private string _model;
        private long _imeiNumber;

        public Phone(string manufacturer, string model, long imeiNumber)
        {
            _manufacturer = manufacturer;
            _model = model;
            _imeiNumber = imeiNumber;
        }

        private bool CheckValidIMEI() => _imeiNumber > 0;
        public string Identifier() => _imeiNumber.ToString();
        public string ProductInfo()
        {
            string validIMEI = CheckValidIMEI() ? "valid" : "invalid";
            return $"Manufacturer is {_manufacturer}, Model: {_model} and IMEI number: {_imeiNumber} (is {validIMEI})";
        }
    }
}
