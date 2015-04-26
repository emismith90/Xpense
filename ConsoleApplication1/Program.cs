using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpense.ElasticSearch;
using Xpense.Model.Entities;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ElasticService service = new ElasticService();

            try
            {
                service.DeleteIndex();
            }
            catch { }

            service.CreateIndex();

            service.IndexData(new SampleDataModel
            {
                Id = 0,
                SampleText = "Hanoi City"
            });
            service.IndexData(new SampleDataModel
            {
                Id = 1,
                SampleText = "Ho Chi Minh City"
            });
            service.IndexData(new SampleDataModel
            {
                Id = 2,
                SampleText = "Danang City"
            });
            service.IndexData(new SampleDataModel
            {
                Id = 3,
                SampleText = "Nhatrang City"
            });
            service.IndexData(new SampleDataModel
            {
                Id = 4,
                SampleText = "Hai phong City"
            });
            service.IndexData(new SampleDataModel
            {
                Id = 5,
                SampleText = "Hue City"
            });
            service.IndexData(new SampleDataModel
            {
                Id = 6,
                SampleText = "Can tho City"
            });

            var r1 = service.Search("city");
            var r2 = service.Search("Ci");
            var r3 = service.Search("cit");
            var r4 = service.Search("ho");
            var r5 = service.Search("ho chi");

        }
    }
}
