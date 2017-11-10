using Xunit;

namespace Playground.Calculator.Test
{
    public class Z85ByteEncoderAdapterTest
    {
        [Fact]
        public void EncodeDecodeTest()
        {
            // arrange
            var data = new byte[] {12, 34, 201};

            // act
            var encoded = Z85ByteEncoderAdapter.Instance.Encode(data);
            var decoded = Z85ByteEncoderAdapter.Instance.Decode(encoded);

            // assert
            Assert.Equal(data, decoded);
        }
    }
}