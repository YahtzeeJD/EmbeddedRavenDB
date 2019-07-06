using Raven.Client.ServerWide;
using Raven.Embedded;
using System;
using System.Threading.Tasks;

namespace EmbeddedRavenDB
{
    class Program
    {
        public class User
        {
            public string Name;
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the user name:");
            var user = Console.ReadLine();

            EmbeddedServer.Instance.StartServer(new ServerOptions
            {
                DataDirectory = "D:\\RavenData",
                ServerUrl = "http://127.0.0.1:8080"
            });

            var databaseOptions = new DatabaseOptions(new DatabaseRecord
            {
                DatabaseName = "Embedded"
            });

            using (var store = await EmbeddedServer.Instance.GetDocumentStoreAsync(databaseOptions))
            {
                using (var session = store.OpenAsyncSession())
                {
                    await session.StoreAsync(new User { Name = user });
                    await session.SaveChangesAsync();
                }
            }

            EmbeddedServer.Instance.OpenStudioInBrowser();

            Console.WriteLine("Press ENTER to quit this program (and close RavenDB)");
            Console.ReadLine();
        }
    }
}
