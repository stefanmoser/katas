using System;

namespace app
{
    public class SingleNumeralConverter : IConvertSingleNumerals
    {
        RomanNumeral the_numeral;

        public SingleNumeralConverter(RomanNumeral theNumeral)
        {
            the_numeral = theNumeral;
        }

        public RomanNumeral handle_integer(int the_interger)
        {
            if (the_interger >= the_numeral.integer_value)
            {
                return the_numeral;
            }

            throw new NotImplementedException();
        }
    }
}