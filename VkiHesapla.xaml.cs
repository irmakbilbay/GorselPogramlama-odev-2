namespace odev_2;

public partial class VkiHesapla : ContentPage
{
    //kilogram slider'ý
    private double _sliderValue;
    //boy slider'ý
    private int _sliderValue2;

    public VkiHesapla()
	{
		InitializeComponent();
        BindingContext = this;
    }
    // slider deðerinin alýnmasý ve güncellenmesi
    public double SliderValue
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
    // slider deðerinin alýnmasý ve güncellenmesi
    public int SliderValue2
    {
        get { return _sliderValue2; }
        set
        {
            if (_sliderValue2 != value)
            {
                _sliderValue2 = value;
                OnPropertyChanged(); // Binding'in güncellenmesi için
            }
        }
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //kilogram için girilen deðerin virgülden sonra iki basamaðý alýndý
        double kilo = Math.Round(slider.Value, 2); // Virgülden sonra 2 basamak
        // boy cm'den m'ye dönüþtürüldü
        double boy = slider2.Value / 100;

        //vki hesaplama
        double vki = kilo / (boy * boy);
        // hesaplanan vki string'e çevrilip virgülden sonra iki basamaðý alýndý
        string vkiFormat = vki.ToString("F2");

        if (vki < 16)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\nÝleri Düzeyde Zayýf";
        }
        else if (vki >= 16 && vki <= 16.99)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\nOrta Düzeyde Zayýf";
        }
        else if (vki >= 17 && vki <= 18.49)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\nHafif Düzeyde Zayýf";
        }
        else if (vki >= 18.50 && vki <= 24.9)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\nNormal Kilolu";
        }
        else if (vki >= 25 && vki <= 29.99)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\nHafif Þiþman/Fazla Kilolu";
        }
        else if (vki >= 30 && vki <= 34.99)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\n1. Derecede Obez";
        }
        else if (vki >= 35 && vki <= 39.99)
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\n2. Derecede Obez";
        }
        else
        {
            sonucLabel.Text = $"VKÝ: {vkiFormat}\n\n3. Derecede Obez (Morbid Obez)";
        }
    }
}

