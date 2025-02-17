using interface_oefening.Models.Interfaces;

namespace interface_oefening.Models
{
    public class Car : ISellableItem
    {
        private string _make;
        private string _model;
        private string _vin;
        private string _color;

        public Car(string make, string model, string vin, string color)
        {
            _make = make;
            _model = model;
            _vin = vin;
            _color = color;
        }

        public string Identifier() => _vin;
        public string ProductInfo() => $"Make {_make}, model {_model}, vin {_vin} and color is {_color}";
    }
}
