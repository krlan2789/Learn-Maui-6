using LearnMaui6.Models;

namespace LearnMaui6
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.PersonRepo.AddNewPerson(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Person> people = await App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }
    }

}
