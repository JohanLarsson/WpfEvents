namespace WpfEvents
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Vm _vm = new Vm();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }
    }
}
