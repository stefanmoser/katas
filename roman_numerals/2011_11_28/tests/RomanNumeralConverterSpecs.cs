using Machine.Specifications;
using app;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof(RomanNumeralConverter))]
    public class RomanNumeralConverterSpecs
    {
         public class concern : Observes<IConvertRomanNumerals,
                                    RomanNumeralConverter>
         {
             public class when_converting_an_additive_numeral : concern
             {
                 Establish context = () =>
                    {
                        the_integer = 5;
                        single_numeral_converter = depends.on<IConvertSingleNumerals>();
                        single_numeral_converter.setup((x => x.handle_integer(the_integer))).Return(RomanNumeral.Five);
                    };

                 Because of = () =>
                     sut.convert_to_roman_numeral(the_integer);

                 It should_delegate_the_interger_to_the_largest_handler = () =>
                     single_numeral_converter.received(x => x.handle_integer(the_integer));

                 static int the_integer;
                 static IConvertSingleNumerals single_numeral_converter;
             }
         }
    }
}