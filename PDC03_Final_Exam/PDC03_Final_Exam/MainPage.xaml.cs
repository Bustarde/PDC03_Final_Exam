using PDC03_Final_Exam.Model;
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

            List<AnimalModel> images = new List<AnimalModel>()
            {
                new AnimalModel(){Title="Image 1",Url="https://cdn.pixabay.com/photo/2015/12/01/20/28/road-1072823_1280.jpg"},
                new AnimalModel(){Title="Image 2",Url="https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg"},
                new AnimalModel(){Title="Image 3",Url="https://cdn.pixabay.com/photo/2018/05/17/09/18/away-3408119_1280.jpg"}
            };

            Carousel.ItemsSource = images;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                Carousel.Position = (Carousel.Position + 1) % images.Count;
                return true;
            }));

        }

        private async void btnViewRecord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowAnimalPage());
        }

        //AssetManager assets = this.Assets;
        //Typeface font = Typeface.CreateFromAsset(assets, "TestGeograph-Bold.otf");



    }
}
