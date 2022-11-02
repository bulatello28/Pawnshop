using Pawnshop.ClassApp;
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

namespace Pawnshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();

            createClient.NavigationService.Navigate(new CreateContract()); // need edit!
        }

        private void ClientsListBox_Initialized(object sender, EventArgs e)
        {
            UpdateContracts();
        }

        private void UpdateContracts()
        {
            var passportes = DbConnection.Connection.Passport.ToList();
            var clients = DbConnection.Connection.Client.ToList();

            var final = clients.Join(passportes, p => p.Id, c => c.Id,
                (p, c) => new { NameClient = p.Name, Series = c.Series, Number = c.Number,
                                GivenDate = c.Given_date, Birthdate = c.Birthdate, Residence = c.Residence });

            ClientsListBox.ItemsSource = final;
        }

        private void CreateClientBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelClientBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
