using Machine.Specifications;
using app;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof(SingleNumeralConverter))]
    public class SingleNumeralConverterSpecs
    {
         public class concern : Observes<IConvertSingleNumerals,
                                    SingleNumeralConverter>
         {
             public class when_handling_an_integer_that_is_greater_than_the_expected_numeral : concern
             {
                 Establish context = () =>
                     {
                         the_integer = 5;
                         depends.on(RomanNumeral.Five);
                     };

                 Because of = () =>
                     result = sut.handle_integer(the_integer);

                 It should_return_the_associated_roman_numeral = () =>
                     result.ShouldEqual(RomanNumeral.Five);

                 static int the_integer;
                 static RomanNumeral result;
             }
             
             public class when_handling_an_integer_that_is_smaller_than_the_expected_numeral : concern
             {

                 Establish context = () =>
                 {
                     the_integer = 1;
                     depends.on(RomanNumeral.Five);
                     next_handler = depends.on<IConvertSingleNumerals>();
                 };

                 Because of = () =>
                     result = sut.handle_integer(the_integer);

                 It should_pass_the_integer_to_the_next_handler = () =>
                     next_handler.received(x => x.handle_integer(the_integer));

                 static int the_integer;
                 static RomanNumeral result;
                 static IConvertSingleNumerals next_handler;
             }
         }
    }
}