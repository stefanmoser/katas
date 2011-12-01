using System;

namespace app
{
    public class SingleNumeralConverter : IConvertSingleNumerals
    {
        RomanNumeral the_numeral;
        IConvertSingleNumerals next_converter;

        public SingleNumeralConverter(RomanNumeral the_numeral, IConvertSingleNumerals next_converter)
        {
            this.the_numeral = the_numeral;
            this.next_converter = next_converter;
        }

        public RomanNumeral handle_integer(int the_interger)
        {
            if (the_interger >= the_numeral.integer_value)
            {
                return the_numeral;
            }

            return next_converter.handle_integer(the_interger);
        }
    }
}