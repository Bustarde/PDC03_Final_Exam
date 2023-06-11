using PDC03_Final_Exam.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC03_Final_Exam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnViewRecord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowAnimalPage());
        }

        //AssetManager assets = this.Assets;
        //Typeface font = Typeface.CreateFromAsset(assets, "TestGeograph-Bold.otf");
    }
}
