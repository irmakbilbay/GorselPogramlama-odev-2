namespace odev_2;

public partial class KrediHesapla : ContentPage
{
    private int _sliderValue;


    public KrediHesapla()
	{
		InitializeComponent();
        BindingContext = this; // BindingContext'i ayarlýyoruz
    }
    public int SliderValue
    {
        get { return _sliderValue; }
        set
        {
            if (_sliderValue != value)
            {
                _sliderValue = value;
                OnPropertyChanged(); // Binding'in güncellenmesi için
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(tutarEntry.Text) || string.IsNullOrWhiteSpace(faizEntry.Text))
        {
            sonucLabel.Text = "";
            return;
        }
        try
        {
            double tutar = double.Parse(tutarEntry.Text);
            double oran = double.Parse(faizEntry.Text);
            int vade = (int)Math.Round(slider.Value);

            double aylikOran = oran / 12;
            double bsmw = 0, kkdf = 0;
            switch (krediPicker.SelectedItem?.ToString())
            {
                case "Ýhtiyaç Kredisi":
                    bsmw = 0.10;
                    kkdf = 0.15;
                    break;
                case "Taþýt Kredisi":
                    bsmw = 0.05;
                    kkdf = 0.15;
                    break;
                case "Konut Kredisi":
                    bsmw = 0.0;
                    kkdf = 0.0;
                    break;
                case "Ticari Kredisi":
                    bsmw = 0.05;
                    kkdf = 0.0;
                    break;
                default:
                    sonucLabel.Text = "";
                    return;

            }
            double brutFaiz = ((aylikOran + (aylikOran * bsmw) + (aylikOran * kkdf)) / 100);
            double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * tutar;

            double toplamOdeme = taksit * vade;

            double toplamFaiz = toplamOdeme - tutar;

            sonucLabel.Text = $"Aylýk Taksit: {taksit:F2}TL\nToplam Geri Ödeme: {toplamOdeme:F2}TL\nToplam Faiz: {toplamFaiz:F2}TL";
        }
        catch
        {
            sonucLabel.Text = "";
            DisplayAlert("Hata", "Lütfen geçerli sayýlar giriniz.", "Tamam");
        }

    }
}

