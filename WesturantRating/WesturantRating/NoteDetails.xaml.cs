using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WesturantRating.Model;
using Xamarin.Forms;

namespace WesturantRating
{
    public partial class NoteDetails : ContentPage
    {
        private Note chosenNote;

        public NoteDetails(Note note)
        {
            chosenNote = note;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            //var layout = new StackLayout();
            var table = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot()
                {
                    new TableSection()
                    {
                        new TextCell() {Text = chosenNote.Name, Detail = chosenNote.Description},
                        new SwitchCell() {Text = "Done", On = chosenNote.IsDone},
                        //new ViewCell() {View = layout}
                    }
                }
            };
            Content = table;
        }
    }
}
