using System.Windows;
using Task1;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        //private Clients _clients = new Clients();
        public Client NewClient { get; private set; }

        public NewClientWindow()
        {
            InitializeComponent();

            NewClientPanel.DataContext = new Client();

           
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            NewClient = new Client(FirstNameTextBox.Text,
                                    MidlleNameTextBox.Text,
                                    SecondNameTextBox.Text,
                                    TelefonTextBox.Text,
                                    SeriesAndPassportNumberTextBox.Text);
            string b = FirstNameTextBox.Text;

            DialogResult = true;
        }
    }
}
