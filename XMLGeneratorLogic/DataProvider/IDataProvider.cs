namespace XMLGeneratorLogic.DataProvider
{
    public interface IDataProvider <out TOutput>
    {
        TOutput Provide();
    }
}
