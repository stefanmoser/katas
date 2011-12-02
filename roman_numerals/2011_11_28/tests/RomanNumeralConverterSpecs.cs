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

             public class when_converting_a_large_additive_numeral : concern
             {
                 Establish context = () =>
                    {
                        the_integer = 77;
                        depends.on(SingleNumeralConverterChain.first_converter);
                    };

                 Because of = () =>
                     result = sut.convert_to_roman_numeral(the_integer);

                 It should_convert_the_numeral_correctly = () =>
                     result.ShouldEqual("LXXVII");

                 static int the_integer;
                 static string result;
             }

             public class when_converting_a_large_numeral_with_subtractive_elements : concern
             {
                 Establish context = () =>
                    {
                        the_interger = 99;
                        depends.on(SingleNumeralConverterChain.first_converter);
                    };

                 Because of = () =>
                     result = sut.convert_to_roman_numeral(the_interger);

                 It should_convert_the_numeral_correctly = () =>
                     result.ShouldEqual("XCIX");

                 static string result;
                 static int the_interger;
             }
         }
    }
}