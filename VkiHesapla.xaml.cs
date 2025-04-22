namespace odev_2;

public partial class VkiHesapla : ContentPage
{
    //kilogram slider'�
    private double _sliderValue;
    //boy slider'�
    private int _sliderValue2;

    public VkiHesapla()
	{
		InitializeComponent();
        BindingContext = this;
    }
    // slider de�erinin al�nmas� ve g�ncellenmesi
    public double SliderValue
    {
        get { return _sliderValue; }
        set
        {
            if (_sliderValue != value)
            {
                _sliderValue = value;
                OnPropertyChanged(); // Binding'in g�ncellenmesi i�in
            }
        }
    }
    // slider de�erinin al�nmas� ve g�ncellenmesi
    public int SliderValue2
    {
        get { return _sliderValue2; }
        set
        {
            if (_sliderValue2 != value)
            {
                _sliderValue2 = value;
                OnPropertyChanged(); // Binding'in g�ncellenmesi i�in
            }
        }
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //kilogram i�in girilen de�erin virg�lden sonra iki basama�� al�nd�
        double kilo = Math.Round(slider.Value, 2); // Virg�lden sonra 2 basamak
        // boy cm'den m'ye d�n��t�r�ld�
        double boy = slider2.Value / 100;

        //vki hesaplama
        double vki = kilo / (boy * boy);
        // hesaplanan vki string'e �evrilip virg�lden sonra iki basama�� al�nd�
        string vkiFormat = vki.ToString("F2");

        if (vki < 16)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\n�leri D�zeyde Zay�f";
        }
        else if (vki >= 16 && vki <= 16.99)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\nOrta D�zeyde Zay�f";
        }
        else if (vki >= 17 && vki <= 18.49)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\nHafif D�zeyde Zay�f";
        }
        else if (vki >= 18.50 && vki <= 24.9)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\nNormal Kilolu";
        }
        else if (vki >= 25 && vki <= 29.99)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\nHafif �i�man/Fazla Kilolu";
        }
        else if (vki >= 30 && vki <= 34.99)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\n1. Derecede Obez";
        }
        else if (vki >= 35 && vki <= 39.99)
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\n2. Derecede Obez";
        }
        else
        {
            sonucLabel.Text = $"VK�: {vkiFormat}\n\n3. Derecede Obez (Morbid Obez)";
        }
    }
}

