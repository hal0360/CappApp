using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Android.Media.TV;
using CatApp.Models;
using Newtonsoft.Json;

namespace CatApp;

public partial class MainPage : ContentPage
{

    CatViewModel catVM;

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    public MainPage()
	{
		InitializeComponent();

        catVM = new CatViewModel();
        BindingContext = catVM;
       
    }

    private async void Refresh_Clicked(object sender, EventArgs e)
    {
        
        catVM.refreshCollection();
    
    }


}

