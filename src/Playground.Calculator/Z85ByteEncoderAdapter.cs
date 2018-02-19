namespace Playground.Calculator
{
    using System.Linq;
    using CoenM.Encoding;

    public class Z85ByteEncoderAdapter : IByteEncoder
    {
        private Z85ByteEncoderAdapter()
        {
        }

        public static Z85ByteEncoderAdapter Instance { get; } = new Z85ByteEncoderAdapter();

        public byte[] Decode(string input)
        {
            return Z85Extended.Decode(input).ToArray();
        }

        public string Encode(byte[] input)
        {
            return Z85Extended.Encode(input);
        }
    }
}