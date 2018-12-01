namespace XMLGeneratorLogic.Storage
{
    public interface IStorage<in TInput>
    {
        void Save(TInput dataForStore);
    }
}
