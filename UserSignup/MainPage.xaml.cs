using System.Text.RegularExpressions;

namespace UserSignup;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;

        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
        {
            ErrorLabel.Text = "Please fill out all fields.";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (!Regex.IsMatch(EmailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            ErrorLabel.Text = "Please enter a valid email.";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            ErrorLabel.Text = "Passwords do not match.";
            ErrorLabel.IsVisible = true;
            return;
        }

        await Shell.Current.GoToAsync(
            $"{nameof(ProfilePage)}?username={UsernameEntry.Text}&email={EmailEntry.Text}");
    }
}