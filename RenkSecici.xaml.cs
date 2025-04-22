namespace odev_2;

public partial class RenkSecici : ContentPage
{
	public RenkSecici()
	{
		InitializeComponent();
        UpdateColor();
    }
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColor();
    }
    private void UpdateColor()
    {
        // Slider de�erlerini al
        int red = (int)redSlider.Value;
        int green = (int)greenSlider.Value;
        int blue = (int)blueSlider.Value;

        // Label'lar� g�ncelle
        redValueLabel.Text = red.ToString();
        greenValueLabel.Text = green.ToString();
        blueValueLabel.Text = blue.ToString();

        // Renk kodunu olu�tur
        string colorCode = $"#{red:X2}{green:X2}{blue:X2}";
        colorCodeLabel.Text = colorCode;

        // Arka plan rengini de�i�tir
        Color backgroundColor = Color.FromRgb(red, green, blue);
        this.border.BackgroundColor = backgroundColor;
    }
    private async void CopyButton_Clicked(object sender, EventArgs e)
    {
        string colorCode = colorCodeLabel.Text;
        await Clipboard.SetTextAsync(colorCode);
        await DisplayAlert("Kopyaland�", $"{colorCode} panoya kopyaland�.", "Tamam");
    }

    private void RandomColorButton_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();
        redSlider.Value = random.Next(0, 256);
        greenSlider.Value = random.Next(0, 256);
        blueSlider.Value = random.Next(0, 256);
    }
}
