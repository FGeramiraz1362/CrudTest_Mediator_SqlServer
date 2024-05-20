using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneNumbers;
using System.Text;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Test
{
    [TestClass]
    public class MobileNoUtilTest
    {
        [DataTestMethod]
        [DataRow(98, 9122145696, true)]
        [DataRow(98, 40, false)]
        [DataRow(98, 44023173, false)]
        [DataRow(98, 874569874, false)]
        public void TestMobileNoUtil(int countryCode, long mobileNo, bool isValid)
        {
            bool actualResult = IsValidMobileNo((uint)countryCode, (ulong)mobileNo);
            Assert.AreEqual(isValid, actualResult);


        }

        public bool IsValidMobileNo(uint CountryCode, ulong MobileNo)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            var phoneNumber = phoneNumberUtil.Parse(string.Concat("+", CountryCode, " ", MobileNo), null);
            PhoneNumberType phoneNumberType = phoneNumberUtil.GetNumberType(phoneNumber);
            if (phoneNumberType != PhoneNumberType.MOBILE) return false;

            if (!phoneNumberUtil.IsPossibleNumber(phoneNumber))
                return false;

            return true;
        }

       
    }


}
