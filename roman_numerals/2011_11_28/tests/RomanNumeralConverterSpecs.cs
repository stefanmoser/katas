using Machine.Specifications;
using app;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof(RomanNumeralConverter))]
    public class RomanNumeralConverterSpecs
    {
         public class concern : Observes<IConvertRomanNumerals,
                                    RomanNumeralConverter>
         {
             public class when_converting_a_base_roman_numeral : concern
             {
                 Establish context = () =>
                     the_integer = 1;
                 
                 Because of = () =>
                     result = sut.convert_to_roman_numeral(the_integer);

                 It should_convert_into_an_integer = () =>
                     result.ShouldEqual("I");

                 static string result;
                 static int the_integer;
             }

             public class when_converting_an_additive_numeral : concern
             {
                 Establish context = () =>
                     the_integer = 2;

                 Because of = () =>
                     result = sut.convert_to_roman_numeral(the_integer);

                 It should_convert_into_an_integer = () =>
                     result.ShouldEqual("II");

                 static string result;
                 static int the_integer;
             }
         }
    }
}