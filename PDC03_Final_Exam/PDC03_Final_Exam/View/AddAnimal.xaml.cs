using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PDC03_Final_Exam.ViewModel;
using PDC03_Final_Exam.Model;

namespace PDC03_Final_Exam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnimal : ContentPage
    {
        AnimalViewModel _viewModel;
        bool _isUpdate;
        int animalId;

        public AddAnimal()
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            _isUpdate = false;
        }
        public AddAnimal(AnimalModel obj)
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            if (obj != null)
            {
                animalId = obj.Id;
                txtAnimalCode.Text = obj.AnimalCode;
                txtCharacteristics.Text = obj.Characteristics;
                txtSpecies.Text = obj.Species;
                txtHabitat.SelectedItem = obj.Habitat;
                txtThreat.SelectedItem = obj.Threat;
                _isUpdate = true;
            }
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            AnimalModel obj = new AnimalModel();
            //var animal = (AnimalModel)BindingContext;
            //obj.Habitat = (string)txtHabitat.SelectedItem;
            obj.AnimalCode = txtAnimalCode.Text;
            obj.Characteristics = txtCharacteristics.Text;
            obj.Species = txtSpecies.Text;
            obj.Habitat = txtHabitat.SelectedItem.ToString();
            obj.Threat = txtThreat.SelectedItem.ToString();
            if (_isUpdate)
            {
                obj.Id = animalId;
                await _viewModel.UpdateAnimal(obj);
            }
            else
            {
                _viewModel.InsertAnimal(obj);
            }
            await Navigation.PopAsync();
        }
    }
}