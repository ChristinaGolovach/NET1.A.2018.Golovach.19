using System;
using Ninject;

namespace XMLGeneratorLogic.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new Bindings());

            Processor<string, Uri> processor2 = kernel.Get<Processor<string, Uri>>();

            processor2.ConvertData();
        }
    }
}
