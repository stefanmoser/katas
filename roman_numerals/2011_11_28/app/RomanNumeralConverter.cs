namespace app
{
    public class RomanNumeralConverter : IConvertRomanNumerals
    {
        public string convert_to_roman_numeral(int the_integer)
        {
            int remaining_integer = the_integer;
            string the_numeral = "";
            while (remaining_integer > 0)
            {
                RomanNumeral next_largest_numeral = get_next_largest_numeral(remaining_integer);
                remaining_integer -= next_largest_numeral.integer_value;
                the_numeral += next_largest_numeral.numeral_string;
            }

            return the_numeral;
        }

        private RomanNumeral get_next_largest_numeral(int the_integer)
        {
            if (the_integer >= 5)
            {
                return RomanNumeral.Five;
            }
            else
            {
                return RomanNumeral.One;
            }
        }
    }

    public class RomanNumeral
    {
        public static RomanNumeral One = new RomanNumeral(1, "I");
        public static RomanNumeral Five = new RomanNumeral(5, "V");

        private int _integer_value;
        private string _numeral_string;

        private RomanNumeral(int integer_value, string numeral_string)
        {
            _integer_value = integer_value;
            _numeral_string = numeral_string;
        }

        public int integer_value
        {
            get { return integer_value; }
        }

        public string numeral_string
        {
            get { return _numeral_string; }
        }
    }
}