using System;
using System.Threading.Tasks;

namespace Module_4_Task_5
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).TaskOne();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).TaskTwo();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).TaskThree();
            }
        }
    }
}
