using System;

namespace Memento
{
    public static class Program
    {
        public static void Main()
        {
            var noteBook = new NoteBook();
            
            noteBook.Write("mfk");
            noteBook.ShowNote();

            var noteMemento = noteBook.Save();
            var caretaker = new Caretaker(noteMemento);
            
            noteBook.Write("ark");
            noteBook.ShowNote();
            
            noteBook.Rollback(caretaker.GetMemento());
            noteBook.ShowNote();
        }
    }

    public class NoteBook
    {
        private string _note;

        public void Write(string note)
        {
            _note = note;
        }

        public void ShowNote()
        {
            Console.WriteLine($"Showing note on the notebook: {_note}");
        }

        public NoteMemento Save()
        {
            Console.WriteLine($"Saving note: {_note}");
            return new NoteMemento()
            {
                Note = _note
            };
        }

        public void Rollback(NoteMemento noteMemento)
        {
            Console.WriteLine($"Bringing back note: {noteMemento.Note}");
            _note = noteMemento.Note;
        }
        
    }

    public class NoteMemento
    {
        public string Note { get; set; }
    }

    public class Caretaker
    {
        private readonly NoteMemento _noteMemento;

        public Caretaker(NoteMemento noteMemento)
        {
            _noteMemento = noteMemento;
        }

        public NoteMemento GetMemento()
        {
            return _noteMemento;
        }
    }
}