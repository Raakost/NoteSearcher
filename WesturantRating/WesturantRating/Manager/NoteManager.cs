using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WesturantRating.Model;
using Xamarin.Forms;

namespace WesturantRating.Manager
{
    public class NoteManager
    {
        List<Note> notes = new List<Note>();

        public NoteManager()
        {
            Note r1 = new Note { Name = "Running", Description = "Run and do a roundabout after 5 km.", IsDone = false };
            Note r2 = new Note { Name = "Dinner with moom", Description = "Husk blomster! og rødvin, hun elsker rødvin..", IsDone = true };
            Note r3 = new Note { Name = "Vape Nation!", Description = "Vape is life!", IsDone = false };
            notes.Add(r1);
            notes.Add(r2);
            notes.Add(r3);
        }

        public List<Note> GetnotesByName(string input)
        {
            return new List<Note>(notes.Where(x => x.Name.ToLower().Contains(input.ToLower())));
        }

        public List<Note> Getnotes()
        {
            return notes;
        }
    }
}
