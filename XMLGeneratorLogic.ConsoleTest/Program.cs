using System;
using DependencyResolving;
using Ninject;

namespace XMLGeneratorLogic.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new Bindings());

            Processor<string, Uri> processor = kernel.Get<Processor<string, Uri>>();

            processor.ConvertData();
        }
    }
}
