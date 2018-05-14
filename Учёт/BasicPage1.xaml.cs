using Account.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Account
{
    public sealed partial class BasicPage1 : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        
        static DateTime date = DateTime.Now;
        int today = Convert.ToInt32(date.DayOfWeek);
        public string Item_name;

        public BasicPage1()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            
            

        }
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int parameter;
            this.navigationHelper.OnNavigatedTo(e);


            parameter = Convert.ToInt32(e.Parameter as string);
            parameter = parameter + 5000;
            parameter = TaxOfParametr(parameter);
            counting(parameter);
            if (parameter < 5100)
                AddToParametr(parameter, date.DayOfWeek);
            IterateThroughList(parameter);
            base.OnNavigatedTo(e);
        }

        private void AddToParametr( int parametr , int value)
        {
            int temp = parametr * value;
            tbl1.Text = temp.ToString();
            temp = parametr + 768;
            tbl2.Text = temp.ToString();
            temp = parametr + 1368;
            tbl3.Text = temp.ToString();
            temp = parametr + 1962;
            tbl4.Text = temp.ToString();
        }

        private int TaxOfParametr(int value)
        {
            if(value > 5846 && value < 5917)
            {
                value = value + 485;
            }
            if (value > 5917)
            {
                value = value + 381;
            }
            return value;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
        private void IterateThroughList(int parametr)
        {
            var Tables = new List<TableItem>
        {
            new TableItem() { day_numb=1, value=310, volume=15.5, value2=372, volume2=18.6},
            new TableItem() { day_numb=2, value=204, volume=10.2, value2=126, volume2=6.3},
            new TableItem() { day_numb=3, value=252, volume=12.6, value2=792, volume2=39.6},
            new TableItem() { day_numb=4, value=204, volume=10.2, value2=192, volume2=9.6},
            new TableItem() { day_numb=5, value=186, volume=9.3, value2=562, volume2=28.1},
            new TableItem() { day_numb=6, value=176, volume=8.8, value2=284, volume2=14.2},
            new TableItem() { day_numb=0, value=434, volume=21.7, value2=438, volume2=21.9}
        };

            

            foreach (TableItem Table in Tables)
            {
                if(Table.day_numb ==today && parametr>7000 && Table.volume == 21.7 &&Table.value==434  )
                {
                    parameter = parameter - 900;
                    LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. текущ. уб.", value = 900, p_value = parameter, volume = 45 });
                    parameter = parameter - Table.value;
                    LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. Ген. уб.", Table.value, p_value = parameter, Table.volume });
                    parameter = parameter - 2200;
                    LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. текущ. уб.", value = 2200, p_value = parameter, volume = 110 });
                    parameter = parameter - Table.value2;
                    LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. Ген. уб.", value=Table.value2, p_value = parameter, volume=Table.volume2 });
                }
            }
           

        }
        private void counting(int value)
        {
            tbl1.Text += value.ToString();
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgbox = new MessageDialog("", "Выберите помещение");
            msgbox.Commands.Add(new UICommand("рз №1",
            new UICommandInvokedHandler((args) =>
        {

    
        })));

            
            await msgbox.ShowAsync();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (CB1.SelectedItem == null)
            {
                Error_message();
            }
             else

            {
                Item_name = ((ComboBoxItem)CB1.SelectedItem).Content.ToString();
                var Second_tables = new List<Second_table>
        {
            new Second_table() { room="рз №1", value=382, volume=15.5},
            new Second_table() { room="рз №2", value=382, volume=10.2},
            new Second_table() { room="рз №3", value=236, volume=12.6},
            new Second_table() { room="рз №4", value=532, volume=10.2},
            new Second_table() { room="П1", value=184, volume=9.3},
            new Second_table() { room="П3", value=168, volume=8.8},
            new Second_table() { room="П5", value=434, volume=21.7}
        };
                CB1.SelectedItem = null;
            }

        }

        private async void Error_message()
        {
            {
                MessageDialog msgbox = new MessageDialog("Выберите значение", "Ошибка");
                await msgbox.ShowAsync();
            }
        }
    }
    public class TableItem
    {
        public int day_numb { get; set; }
        public int value { get; set; }
        public double volume { get; set; }
        public int value2 { get; set; }
        public double volume2 { get; set; }
    }

    public class Second_table
    {
        public string room { get; set; }
        public int value { get; set; }
        public double volume { get; set; }
    }

}





//

///////////////////////************************//////////////////////////////******************************//////////////////////////////////////

    //встраивание временной переменной
        protected override void OnNavigatedTo(NavigationEventArgs e)///встраивание временной переменной
        {
            this.navigationHelper.OnNavigatedTo(e);

            counting(Convert.ToInt32(e.Parameter as string) + 5000);
            IterateThroughList(Convert.ToInt32(e.Parameter as string) + 5000);
            base.OnNavigatedTo(e);
        }
///////////////////////********************////////////////////****************///////////      
// замена временной переменной вызовом метода
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    
    this.navigationHelper.OnNavigatedTo(e);


    const parameter = CountOfParametr(e.Parameter as string);
    counting(parameter);
    IterateThroughList(parameter);
    base.OnNavigatedTo(e);
}
/**//**/


protected int CountOfParametr(string value)
{
    return Convert.ToInt32(e.Parameter as string) + 5000;
}
///////////////////////********************////////////////////****************///////////
//введение поясняющей переменной
private void IterateThroughList(int parametr)
{
    var Tables = new List<TableItem>
        {
            new TableItem() { day_numb=1, value=310, volume=15.5, value2=372, volume2=18.6},
            new TableItem() { day_numb=2, value=204, volume=10.2, value2=126, volume2=6.3},
            new TableItem() { day_numb=3, value=252, volume=12.6, value2=792, volume2=39.6},
            new TableItem() { day_numb=4, value=204, volume=10.2, value2=192, volume2=9.6},
            new TableItem() { day_numb=5, value=186, volume=9.3, value2=562, volume2=28.1},
            new TableItem() { day_numb=6, value=176, volume=8.8, value2=284, volume2=14.2},
            new TableItem() { day_numb=0, value=434, volume=21.7, value2=438, volume2=21.9}
        };



    foreach (TableItem Table in Tables)
    {
        bool IsParametrMoMin = (parametr > 7000);
        bool IsVolumeMax = (Table.volume == 21.7);
        bool IsValueMax = (Table.value == 434);
        bool IsToday = (Table.day_numb == today);
        if (IsToday && IsParametrMoMin && IsVolumeMax && IsValueMax)
        {
            parameter = parameter - 900;
            LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. текущ. уб.", value = 900, p_value = parameter, volume = 45 });
            parameter = parameter - Table.value;
            LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. Ген. уб.", Table.value, p_value = parameter, Table.volume });
            parameter = parameter - 2200;
            LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. текущ. уб.", value = 2200, p_value = parameter, volume = 110 });
            parameter = parameter - Table.value2;
            LV.Items.Add(new { WorkName = "0,03 Аквалайт П.П. Ген. уб.", value = Table.value2, p_value = parameter, volume = Table.volume2 });
        }
    }


}
/////////////////***************//////////////////********************/////////////////
//удаление присвоений параметрам
private int TaxOfParametr(int parameter)
{
    int temp = parameter;
    if (temp > 846 && temp < 917)
    {
        temp = temp + 485;
    }
    if (temp > 917)
    {
        temp = temp + 381;
    }
    return temp;
}
/////////////////***************//////////////////********************/////////////////
//расщепление временной переменной
private void AddToParametr(int parametr, int value)
{
    readonly int FirstValue = parametr * value;
    tbl1.Text = FirstValue.ToString();
    readonly int SecondValue = parametr + 768;
    tbl2.Text = SecondValue.ToString();
    readonly int ThirdValue = parametr + 1368;
    tbl3.Text = ThirdValue.ToString();
    readonly int FourthValue = parametr + 1962;
    tbl4.Text = FourthValue.ToString();
}