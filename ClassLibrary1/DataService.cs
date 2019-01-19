using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Event;

namespace test
{
    class DataService
    {
        public DataRepository repo { get; set; }

        public DataService(DataRepository newRepo) { //wstrzykiwanie danych z wykorzystaniem DataRepository
            repo = newRepo;
        }

        public void printRepo() {  //nie są tutaj przekazywane dane bezpośrednio z DataRepository, ponieważ zostały przekazane wcześniej w parametrze
            Console.WriteLine("Books:");
            foreach (var entry in repo.GetAllBook())
                Console.WriteLine(entry.ToString());
            Console.WriteLine("Readers:");
            foreach (var entry in repo.GetAllReader())
                Console.WriteLine(entry.ToString());
            Console.WriteLine("Authors:");
            foreach (var entry in repo.GetAllAuthor())
                Console.WriteLine(entry.ToString());
            Console.WriteLine("Copies:");
            foreach (var entry in repo.GetAllCopy())
                Console.WriteLine(entry.ToString());
            Console.WriteLine("Events:");
            foreach (var entry in repo.GetAllEvent())
                Console.WriteLine(entry.ToString());
        }

        public void printDetailedInfo() {
            foreach (var reader in repo.GetAllReader()) { //pętla, która iteruje po wszystkich czytelnikach
                Console.WriteLine(reader.ToString());
                foreach(var eventObj in repo.GetAllEvent().Where(x => x.ReaderId == reader.Id)){ //wyświetla dla każdego eventu(wypożyczenia), gdzie readerID z evetu będzie taki sam jak obecnie przetważany
                    Console.WriteLine("\t" + eventObj.ToString());
                    Console.WriteLine("\t\t" + repo.GetCopy(eventObj.CopyId).ToString());
                
                }
            }
        }

        public void addEvent(int readerId, int copyId, EventType type) {
            repo.AddEvent(new Event(copyId, readerId, DateTime.Now, type));
        }

        public List<Event> getEventsForReader(int readerId) {
            return repo.GetAllEvent().Where(x => x.ReaderId == readerId).ToList();//GetAllEvent- zwraca kolekcję, kiedy znajdzie to zamienia wynik zapytania (kilka elementów) na listę
        }

        
    }
}
