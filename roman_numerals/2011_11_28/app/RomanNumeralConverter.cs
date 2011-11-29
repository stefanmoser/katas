namespace app
{
    public class RomanNumeralConverter : IConvertRomanNumerals
    {
        IConvertSingleNumerals single_numeral_converter;

        public RomanNumeralConverter(IConvertSingleNumerals single_numeral_converter)
        {
            this.single_numeral_converter = single_numeral_converter;
        }

        public string convert_to_roman_numeral(int the_integer)
        {
            int remaining_integer = the_integer;
            string the_numeral = "";
            while (remaining_integer > 0)
            {
                RomanNumeral next_largest_numeral = single_numeral_converter.handle_integer(remaining_integer);

                remaining_integer -= next_largest_numeral.integer_value;
                the_numeral += next_largest_numeral.numeral_string;
            }

            return the_numeral;
        }
    }
}