using NUnit.Framework;
using Qowaiv;

namespace TelephoneNumber_pattern_specs
{
    public class International_Numbers
    {
        [Test]
        public void Can_start_with_00()
        {
            var number = TelephoneNumber.Parse("0031 123456789");
            Assert.AreEqual(TelephoneNumberType.International, number);
        }

        [Test]
        public void Can_start_with_a_plus()
        {
            var number = TelephoneNumber.Parse("+31 123456789");
            Assert.AreEqual(TelephoneNumberType.International, number);
        }
    }
}
