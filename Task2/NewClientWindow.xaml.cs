using System.Windows;
using Task1;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        private Clients _clients = new Clients();
        public NewClientWindow()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            _clients = this.DataContext as Clients;

            Client client = new Client(FirstNameTextBox.Text,
                                       MidlleNameTextBox.Text,
                                       SecondNameTextBox.Text,
                                       TelefonTextBox.Text,
                                       SeriesAndPassportNumberTextBox.Text);

            //if (!IsValid(this)) return;

            _clients.Add(client);

            DialogResult = true;
        }
    }
}
