using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControlTutorial.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormEntry : Xamarin.Forms.Grid
    {
        public FormEntry()
        {
            InitializeComponent();
            entry.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(FormEntry), default(string), Xamarin.Forms.BindingMode.OneWay);
       
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }        

        //-------------------------------------------------//

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(FormEntry), default(string), BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        //-------------------------------------------------//

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TitleProperty.PropertyName)
            {
                title.Text = Title;
            }
            else if (propertyName == TextProperty.PropertyName)
            {
                entry.Text = Text;
            }
        }
    }
}