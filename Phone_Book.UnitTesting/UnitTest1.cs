
namespace Phone_Book.UnitTesting
{
    public class Tests
    {
        [TestCase("david.sills100@gmail.com", true)]
        [TestCase("david.sills100@gmail", false)]
        [TestCase("david.sills100.@gmail.com", false)]
        [TestCase("golfiscool@golf.gov", true)]
        [TestCase("david sills@gmail.new", false)]
        [TestCase("ChiropractorSchool@chiro.edu", true)]
        [TestCase("baseball; cardinals-baseball@gmail.com", false)]
        [TestCase("@AOL.com", false)]
        [TestCase("david.sills100@aol.com", true)]
        [TestCase("david.sills100", false)]
        [TestCase("Golf.com.@gmail.com", false)]

        public void Check_IsTheEmailValid_ReturnsCorrectly(string input, bool expect)
        {
            bool result;

            result = Validation.Validation.IsTheEmailValid(input);

            Assert.That(result, Is.EqualTo(expect));
        }

        [TestCase("(309)846-5675", true)]
        [TestCase("309-846-5675", false)]
        [TestCase("3098465675", false)]
        [TestCase("(812)340-2355)", true)]
        [TestCase("(812)340-235", false)]
        [TestCase("(812)444-5555", true)]
        [TestCase("(213)-445-4432", false)]
        [TestCase("846-5675", false)] 
        [TestCase("(309)830-8801", true)]
        [TestCase("+1 (309)846-5675", false)]
        [TestCase("(8I2)234-5678", false)]
        public void Check_IsThePhoneNumberValid_ReturnsCorrectly(string input, bool expect)
        {
            bool result;

            result = Validation.Validation.IsThePhoneNumberValid(input);

            Assert.That(result, Is.EqualTo(expect));
        }
    }
}
