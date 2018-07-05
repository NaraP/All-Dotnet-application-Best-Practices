using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utillity.ErrorLogs;
using WpfCustomerControlLibrary.CustomerRepository;
using WpfCustomerControlLibrary.Model;

namespace WpfCustomerControlLibrary.ViewModel
{
   public class CustomerViewModel : NotificationObject
    {
        public ICustomerRespository CustRepository = null;
        public IErrorLogger ErrorLog = null;

        public DelegateCommand SaveCommand;
        public DelegateCommand UpdateCommand;
        public DelegateCommand DeleteCommand;
        public DelegateCommand SelectCommand;
        ObservableCollection<Customers> _Customers;

        public CustomerViewModel(ICustomerRespository _CustRepository, IErrorLogger _ErrorLog)
        {
            CustRepository = _CustRepository;
            SaveCommand = new DelegateCommand(SaveCustomers);
            UpdateCommand = new DelegateCommand(UpdateCustomers);
            DeleteCommand = new DelegateCommand(DeleteCustomers);
            ErrorLog = _ErrorLog;
        }
        public ObservableCollection<Customers> Customers
        {
            get
            {
                _Customers = new ObservableCollection<Customers>(CustRepository.GetCustomerData());
                return _Customers;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteCustomers()
        {
            Customers cust = null;

            try
            {
                cust = new Model.Customers();
                cust.CustomerID = CustomerID;
                CustRepository.InsertCustomerData(cust);
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "DeleteCustomers", "Cusomer View Model");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateCustomers()
        {
            Customers cust = null;
            try
            {
                cust = new Model.Customers();

                cust.CustomerID = CustomerID;
                cust.Name = Name;
                cust.Address = Address;
                cust.Mobileno = Mobileno;
                cust.EmailID = EmailID;
                CustRepository.UpdateCustomerData(cust);
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "UpdateCustomers", "Cusomer View Model");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveCustomers()
        {
            Customers cust = null;
            try
            {
                cust = new Model.Customers();

                cust.CustomerID = CustomerID;
                cust.Name = Name;
                cust.Address = Address;
                cust.Mobileno = Mobileno;
                cust.EmailID = EmailID;
                CustRepository.InsertCustomerData(cust);
            }
            catch(Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "SaveCustomers", "Cusomer View Model");
            }
        }

        private string _CustomerID;
        private string _Name;
        private string _Address;
        private string _Mobileno;
        private string _EmailID;

        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                RaisePropertyChanged("Address");
            }
        }
        public string Mobileno
        {
            get { return _Mobileno; }
            set
            {
                _Mobileno = value;
                RaisePropertyChanged("Mobileno");
            }
        }
        public string EmailID
        {
            get { return _EmailID; }
            set
            {
                _EmailID = value;
                RaisePropertyChanged("EmailID");
            }
        }
    }
}
