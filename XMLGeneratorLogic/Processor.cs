using System.Collections.Generic;
using XMLGeneratorLogic.DataProvider;
using XMLGeneratorLogic.Mapper;
using XMLGeneratorLogic.Storage;


namespace XMLGeneratorLogic
{
    public class Processor<TSource, TResult>
    {
        private IDataProvider<ICollection<TSource>> dataProvider;
        private IMapper<TSource, TResult> mapper;
        private IStorage<ICollection<TResult>> storage;

        private ICollection<TSource> dataFromProvider;
        private ICollection<TResult> convertedData;

        public Processor(IDataProvider<ICollection<TSource>> dataProvider, IMapper<TSource, TResult> mapper, IStorage<ICollection<TResult>> storage)
        {
            this.dataProvider = dataProvider;
            this.mapper = mapper;
            this.storage = storage;
            convertedData = new List<TResult>();
        }

        public void ConvertData()
        {
            dataFromProvider = dataProvider.Provide();

            foreach (TSource data in dataFromProvider)
            {
                TResult uri = mapper.Map(data);

                if (uri != null)
                {
                    convertedData.Add(uri);
                }
            }

            storage.Save(convertedData);
        }
    }
}
