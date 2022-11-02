using Pawnshop.AdoApp;
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
    /// Логика взаимодействия для Contracts.xaml
    /// </summary>
    public partial class Contracts : Page
    {
        public Contracts()
        {
            InitializeComponent();
            createContract.NavigationService.Navigate(new CreateContract());
        }

        private void ListView_Initialized(object sender, EventArgs e)
        {
            UpdateContracts();
        }

        private void UpdateContracts()
        {
            var pledge_Agreements = DbConnection.Connection.Pledge_Agreement.ToList();
            var clients = DbConnection.Connection.Client.ToList();
            var products = DbConnection.Connection.Product.ToList();

            var contracts = pledge_Agreements.Join(clients, p => p.Id_client, c => c.Id,
                (p, c) => new {
                    Name = c.Name,
                    Product_id = p.Product_id,
                    Date_contract = p.Date_contract,
                    Date_return = p.Date_return,
                    Commision = p.Commision
                });

            var final = contracts.ToList().Join(products, p => p.Product_id, c => c.Id,
                (p, c) => new {
                    Name = p.Name,
                    Product = c.Name,
                    Date_contract = p.Date_contract,
                    Date_return = p.Date_return,
                    Commision = p.Commision
                });

            ContractsListBox.ItemsSource = final;
        }

        private void CreateContractBtn_Click(object sender, RoutedEventArgs e)
        {
            ContractsListBox.Visibility = Visibility.Hidden;
            CreateContractBtn.Visibility = Visibility.Hidden;
            CancelContractBtn.Visibility = Visibility.Visible;
            createContract.NavigationService.Navigate(new CreateContract());
        }

        private void CancelContractBtn_Click(object sender, RoutedEventArgs e)
        {

            ContractsListBox.Visibility = Visibility.Visible;
            CreateContractBtn.Visibility = Visibility.Visible;
            CancelContractBtn.Visibility = Visibility.Hidden;
            createContract.NavigationService.GoBack();
        }
    }
}
