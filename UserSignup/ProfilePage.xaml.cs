using Microsoft.Maui.Controls;

namespace UserSignup;

[QueryProperty(nameof(Username), "username")]
[QueryProperty(nameof(Email), "email")]
public partial class ProfilePage : ContentPage
{
    public string Username
    {
        set
        {
            UsernameLabel.Text = value;
        }
    }

    public string Email
    {
        set
        {
            EmailLabel.Text = value;
        }
    }

    public ProfilePage()
    {
        InitializeComponent();
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}