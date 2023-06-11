using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDC03_Final_Exam.Model;
using PDC03_Final_Exam.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC03_Final_Exam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowAnimalPage : ContentPage
    {
        AnimalViewModel viewModel;

        public ShowAnimalPage()
        {
            InitializeComponent();
            viewModel = new AnimalViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            showAnimal();
        }
        private void showAnimal()
        {
            var res = viewModel.GetAllAnimals().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAnimal());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                AnimalModel obj = (AnimalModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await Navigation.PushAsync(new AddAnimal(obj));

                        break;
                    case "Delete":
                        viewModel.DeleteAnimal(obj);
                        showAnimal();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}