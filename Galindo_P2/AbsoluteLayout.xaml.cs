using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2;

public partial class AbsoluteLayout : ContentPage
{
    public AbsoluteLayout()
    {
        InitializeComponent();
    }
    
    private async void OnGoToGridLayoutClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync(); 
    }
}