namespace XMLGeneratorLogic.XMLGenerator
{
    public interface IXMLGenerator<in TInput, out TOutput>
    {
        TOutput GenerateXML(TInput value);
    }
}
