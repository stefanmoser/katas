﻿using System.Collections.Generic;

namespace app
{
    public class SingleNumeralConverterChain
    {
        private static SingleNumeralConverter chain_head;

        static SingleNumeralConverterChain()
        {
            List<RomanNumeral> numerals = new List<RomanNumeral>();
            numerals.Add(RomanNumeral.One);
            numerals.Add(RomanNumeral.Four);
            numerals.Add(RomanNumeral.Five);
            numerals.Add(RomanNumeral.Nine);
            numerals.Add(RomanNumeral.Ten);
            numerals.Add(RomanNumeral.Fourty);
            numerals.Add(RomanNumeral.Fifty);
            numerals.Add(RomanNumeral.Ninety);
            numerals.Add(RomanNumeral.OneHundred);

            chain_head = null;

            foreach (var numeral in numerals)
            {
                chain_head = new SingleNumeralConverter(numeral, chain_head);
            }
        }

        public static IConvertSingleNumerals first_converter
        {
            get { return chain_head; }
        }
    }
}