using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IFillWithDefaultValues
{
    List<Reader> GenerateReaderCollection();
    List<Author> GenerateAuthorCollection();
    Dictionary<int, Book> GenerateBookCollection();
    ObservableCollection<Copy> GenerateCopyCollection();
    ObservableCollection<Event> GenerateEventCollection();
}

