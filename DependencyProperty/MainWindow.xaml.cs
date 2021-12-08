using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DependencyPropertyExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] sources = { "Number1", "Number2", "Number3" };
        public string[] Sources => sources;

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                nameof(MainWindow.Source),
                typeof(string),
                typeof(MainWindow),
                new PropertyMetadata(SourcePropertyChanged)
            );
            

        public string Source 
        { 
            get => (string)this.GetValue(MainWindow.SourceProperty);
            set => this.SetValue(MainWindow.SourceProperty, value);
        }

        private static void SourcePropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            if ((string)e.OldValue == "Number1" && (string)e.NewValue == "Number3")
            {
                MessageBox.Show("Your skipped the Number2");
            }

        }

        public MainWindow()
        {
            this.DataContext = this;

            InitializeComponent();
        }
    }
}
