using Android.Systems;
using CatApp.Models;
using Java.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Google.Crypto.Tink.Mac;
namespace CatApp;

public class CatViewModel : INotifyPropertyChanged
{

    // IList<Cat> source;

    public ObservableCollection<Cat> Cats { get; private set; }

    public CatViewModel()
    {
       // source = new List<Cat>();
        // CreateMonkeyCollection();
        Cats = new ObservableCollection<Cat>(fetchData());

    }

    public void refreshCollection()
    {
        
        Cats.Clear();

        IList<Cat> cats = fetchData();

        foreach (var cat in cats) Cats.Add(cat);

    }

     List<Cat> fetchData()
    {
        var webRequest = WebRequest.Create("https://api.thecatapi.com/v1/images/search?limit=10") as HttpWebRequest;
        if (webRequest == null)
        {
            return new List<Cat>();
        }

        webRequest.ContentType = "application/json";
        webRequest.UserAgent = "Nothing";
        var sr = new StreamReader(webRequest.GetResponse().GetResponseStream());
        return JsonConvert.DeserializeObject<List<Cat>>(sr.ReadToEnd());

    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}