using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Bank Bank { get; set; }

        public Consultant Consultant { get; set; }

        public Meneger Meneger { get; set; }     

        private ObservableCollection<ClientForBank> _clients = new ObservableCollection<ClientForBank>();

        public MainWindow()
        {
            Bank = new Bank();

            InitializeComponent();

            Consultant = new Consultant();

            Meneger = new Meneger();

            //DataClients.ItemsSource = Bank.clients;
            DataClients.ItemsSource = Bank.GetData(AccessLevel.Consultant);
        }

        /// <summary>
        /// Метод редактирования номера телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTelefon_Button(object sender, RoutedEventArgs e)
        {
            var client = DataClients.SelectedItem as Client;

            if (client != null) Consultant.EditeClient(client, EditTelefon_TextBox.Text);

            else ShowStatusBarText("Выберите клиента");

        }

        /// <summary>
        /// Метод удаляющий текст сообщения в StatusBar
        /// </summary>
        /// <param name="message">Текст информационного сообщения</param>
        private void ShowStatusBarText(string message)
        {
            StatusBarText.Text = message;

            var timer = new System.Timers.Timer();

            timer.Interval = 2000;

            timer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
            {
                timer.Stop();
                //удалите текст сообщения о состоянии с помощью диспетчера, поскольку таймер работает в другом потоке
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    StatusBarText.Text = "";
                }));
            };
            timer.Start();
        }

        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = true;
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog { Filter = "Text files|*.csv" };

            if (true == saveDlg.ShowDialog())
            {
                string fileName = saveDlg.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
                {
                    foreach (var emp in _clients)
                    {
                        sw.WriteLine(emp.ToString());
                    }
                }
            }
        }

        private void CloseWindows(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

       
        private void AccessLevel_ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (AccessLevel_ComboBox.SelectedIndex)
            {
                case 0: //консультант

                    NewClient_Button.IsEnabled = false;

                    DataClients.ItemsSource = Bank.GetData(AccessLevel.Consultant);


                    break;

                case 1: //менждер

                    NewClient_Button.IsEnabled = true;

                    DataClients.ItemsSource = Bank.GetData(AccessLevel.Menager);

                    break;

                default:
                    break;

            }
        }

        private void EditName_Button_Clik(object sender, RoutedEventArgs e)
        {
            var client = DataClients.SelectedItem as Client;

            //if (client != null)
            //{
            //    Client changedClient = Menager.EditNameClient(client, EditName_TextBox.Text);

            //    _clients.EditClient(_clients.IndexOf(client), changedClient);
            //}

            //else ShowStatusBarText("Выберите клиента");
        }

        private void ClientViewSelection(object sender, SelectionChangedEventArgs e)
        {
            Client currentClient = DataClients.SelectedItem as ClientForBank;

            if (currentClient != null)
            {
                switch (AccessLevel_ComboBox.SelectedIndex)
                {
                    case 0:
                        PanelInfo.DataContext = Consultant.ViewClientData(currentClient);
                        break;
                    case 1:
                        PanelInfo.DataContext = Meneger.ViewClientData(currentClient);
                        break;
                }
            }
        }

        /// <summary>
        /// Метод добавления нового клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void NewClient_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    NewClientWindow _windowNewClient = new NewClientWindow();

        //    _windowNewClient.DataContext = _clients;

        //    _windowNewClient.Owner = this;

        //    _windowNewClient.ShowDialog();
        //}
    }
}
