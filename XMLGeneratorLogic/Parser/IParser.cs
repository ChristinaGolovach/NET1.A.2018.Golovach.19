namespace XMLGeneratorLogic.Parser
{
    public interface IParser<in TInput, out TOutput>
    {
        TOutput Parse(TInput value);
    }
}
