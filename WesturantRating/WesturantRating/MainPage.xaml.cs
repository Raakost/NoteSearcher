using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WesturantRating.Manager;
using WesturantRating.Model;
using Xamarin.Forms;

namespace WesturantRating
{
    public partial class MainPage : ContentPage
    {
        private SearchBar mySearchBar;
        private ListView noteListView;
        private NoteManager noteManager;

        public MainPage()
        {
            InitializeComponent();
            noteListView = new ListView();
            noteManager = new NoteManager();
            InitData();
        }

        
        public void InitData()
        {
            StackLayout outerStack = new StackLayout() { Orientation = StackOrientation.Vertical };

            // Sets the itemSourse to be all the notes as default
            noteListView.ItemsSource = noteManager.Getnotes();
            noteListView.ItemSelected += NavigateToNoteDetails;
            // Instantiate a SearchBar
            mySearchBar = new SearchBar()
            {
                Placeholder = "Search",
                // For eksemplets skyld : 
                SearchCommand = new Command(() =>
                {
                    // Sets the itemSource to the notes that contains the search
                    noteListView.ItemsSource = SearchForContainingNotes(mySearchBar.Text);
                })
            };
            
            mySearchBar.TextChanged += MySearchBar_OnTextChanged;

            outerStack.Children.Add(mySearchBar);
            outerStack.Children.Add(noteListView);
            Content = outerStack;
        }

        private async void NavigateToNoteDetails(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            await Navigation.PushAsync(new NoteDetails((Note)selectedItemChangedEventArgs.SelectedItem));
        }

        private void MySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = mySearchBar.Text;
            noteListView.ItemsSource = SearchForContainingNotes(keyword);
        }

        public List<Note> SearchForContainingNotes(string searchBarResult)
        {
            return noteManager.GetnotesByName(searchBarResult);
        }
    }
}
