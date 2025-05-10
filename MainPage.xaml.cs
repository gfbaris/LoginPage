namespace LoginPage
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text?.Trim();
            string surname = surnameEntry.Text?.Trim();
            string email = emailEntry.Text?.Trim();
            string password = passwordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Hata", "Lütfen tüm alanları doldurunuz.", "Tamam");
                return;
            }

            if (!IsValidEmail(email))
            {
                await DisplayAlert("Hata", "Geçerli bir e-posta adresi giriniz.", "Tamam");
                return;
            }

            if (password.Length < 6)
            {
                await DisplayAlert("Hata", "Şifreniz en az 6 karakter olmalıdır.", "Tamam");
                return;
            }

            await DisplayAlert("Kayıt Başarılı", "Kaydınız başarıyla tamamlanmıştır.", "Tamam");

            nameEntry.Text = surnameEntry.Text = emailEntry.Text = passwordEntry.Text = string.Empty;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}

