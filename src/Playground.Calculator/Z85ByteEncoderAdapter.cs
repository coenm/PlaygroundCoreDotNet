using System.Linq;
using CoenM.Encoding;

namespace Playground.Calculator
{
    public class Z85ByteEncoderAdapter : IByteEncoder
    {
        public static Z85ByteEncoderAdapter Instance { get; } = new Z85ByteEncoderAdapter();

        private Z85ByteEncoderAdapter()
        {
        }

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