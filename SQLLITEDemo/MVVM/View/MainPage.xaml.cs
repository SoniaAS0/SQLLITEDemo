using SQLLITEDemo.MVVM.ViewModel;

namespace SQLLITEDemo.MVVM.View;

public partial class MainPage : ContentPage
{
	private MainPageViewModel _vm= new MainPageViewModel();
	public MainPage()
	{
		InitializeComponent();
		BindingContext = _vm;
	}
}