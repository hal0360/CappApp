namespace CatApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private  void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            Password.IsEnabled = false;
          
             Shell.Current.GoToAsync("/main");
        }
        else
        {
             DisplayAlert("Login Failed!!", "Wrong Uusername or password", "OK");
        }
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "demo" && Password.Text == "happy123";
    }
}