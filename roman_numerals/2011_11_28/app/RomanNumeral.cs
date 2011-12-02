namespace app
{
    public class RomanNumeral
    {
        public static RomanNumeral One = new RomanNumeral(1, "I");
        public static RomanNumeral Four = new RomanNumeral(4, "IV");
        public static RomanNumeral Five = new RomanNumeral(5, "V");
        public static RomanNumeral Nine = new RomanNumeral(9, "IX");
        public static RomanNumeral Ten = new RomanNumeral(10, "X");
        public static RomanNumeral Fourty = new RomanNumeral(40, "XL");
        public static RomanNumeral Fifty = new RomanNumeral(50, "L");
        public static RomanNumeral Ninety = new RomanNumeral(90, "XC");
        public static RomanNumeral OneHundred = new RomanNumeral(100, "C");

        private int _integer_value;
        private string _numeral_string;

        private RomanNumeral(int integer_value, string numeral_string)
        {
            _integer_value = integer_value;
            _numeral_string = numeral_string;
        }

        public int integer_value
        {
            get { return _integer_value; }
        }

        public string numeral_string
        {
            get { return _numeral_string; }
        }
    }
}