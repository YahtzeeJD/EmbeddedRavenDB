using Raven.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbeddedRavenDB472
{
    class Program
    {
        public class User
        {
            public string Name;
        }

        static void Main(string[] args)
        {
            EmbeddedServer.Instance.StartServer();
            var store = EmbeddedServer.Instance.GetDocumentStore("Northwind");

            using (var s = store.OpenSession())
            {
                s.Store(new User { Name = "John" });
                s.SaveChanges();
            }
            EmbeddedServer.Instance.OpenStudioInBrowser();

            Console.WriteLine("Press ENTER to quit this program (and close RavenDB)");
            Console.ReadLine();
        }
    }
}
