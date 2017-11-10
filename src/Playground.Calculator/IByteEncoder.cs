namespace Playground.Calculator
{
    public interface IByteEncoder
    {
        byte[] Decode(string input);
        string Encode(byte[] input);
    }
}