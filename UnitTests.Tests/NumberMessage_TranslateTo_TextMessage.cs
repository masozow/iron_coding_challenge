using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using old_phone.Services;

namespace UnitTests.Tests
{
    public class NumberMessage_TranslateTo_TextMessage
    {
        [Theory]
        [MemberData(nameof(OldPhonePadTestData))]
        public void OldPhonePad_DecodesInput(string input, string expectedOutput)
        {
            // Act
            string actualOutput = DecipheredMessage.OldPhonePad(Validation.ValidateMessage, input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        //Write everything uppercase, and don't forget the # symbol at the end of the message
        public static IEnumerable<object[]> OldPhonePadTestData =>
        [
            ["33#", "E"],
            ["227*#", "B"],
            ["4433555 555666#", "HELLO"],
            ["*6 666 6#", "MOM"],
            ["6 666 6*#", "MO"],
            ["22222*****5555444********#",""],
            ["22222*****5555444***#","J"],
            ["22222****5555444***#","AJ"],
            ["****22222#","B"]
        ];
    }
}