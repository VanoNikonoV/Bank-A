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

namespace Task1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Bank Bank { get; set; }

        public Consultant Consultant { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Bank = new Bank();

            Consultant = new Consultant();

            DataClients.ItemsSource = Bank.GetData(AccessLevel.Consultant);

            #region Сокрытие не функциональных кнопок
            
            EditName_Button.IsEnabled = false;
            EditMiddleName_Button.IsEnabled =false;
            EditSecondName_Button.IsEnabled = false;
            EditSeriesAndPassportNumber_Button.IsEnabled=false;
            NewClient_Button.IsEnabled = false;
            #endregion

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

            //string result = Consultant.ViewClientData(client);
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
        private void CloseWindows(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }
    }
}
