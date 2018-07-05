﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFClientWebApplication.CustomerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customers", Namespace="http://schemas.datacontract.org/2004/07/BusinessEntities.Customer")]
    [System.SerializableAttribute()]
    public partial class Customers : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MobilenoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerID {
            get {
                return this.CustomerIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerIDField, value) != true)) {
                    this.CustomerIDField = value;
                    this.RaisePropertyChanged("CustomerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmailID {
            get {
                return this.EmailIDField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailIDField, value) != true)) {
                    this.EmailIDField = value;
                    this.RaisePropertyChanged("EmailID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mobileno {
            get {
                return this.MobilenoField;
            }
            set {
                if ((object.ReferenceEquals(this.MobilenoField, value) != true)) {
                    this.MobilenoField = value;
                    this.RaisePropertyChanged("Mobileno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceExceptions", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class ServiceExceptions : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorDetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorDetails {
            get {
                return this.ErrorDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorDetailsField, value) != true)) {
                    this.ErrorDetailsField = value;
                    this.RaisePropertyChanged("ErrorDetails");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveCustomerData", ReplyAction="http://tempuri.org/IService/SaveCustomerDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCFClientWebApplication.CustomerService.ServiceExceptions), Action="http://tempuri.org/IService/SaveCustomerDataServiceExceptionsFault", Name="ServiceExceptions", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
        string SaveCustomerData(WCFClientWebApplication.CustomerService.Customers Customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveCustomerData", ReplyAction="http://tempuri.org/IService/SaveCustomerDataResponse")]
        System.Threading.Tasks.Task<string> SaveCustomerDataAsync(WCFClientWebApplication.CustomerService.Customers Customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateCustomerData", ReplyAction="http://tempuri.org/IService/UpdateCustomerDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCFClientWebApplication.CustomerService.ServiceExceptions), Action="http://tempuri.org/IService/UpdateCustomerDataServiceExceptionsFault", Name="ServiceExceptions", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
        string UpdateCustomerData(WCFClientWebApplication.CustomerService.Customers Customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateCustomerData", ReplyAction="http://tempuri.org/IService/UpdateCustomerDataResponse")]
        System.Threading.Tasks.Task<string> UpdateCustomerDataAsync(WCFClientWebApplication.CustomerService.Customers Customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeletCustomerData", ReplyAction="http://tempuri.org/IService/DeletCustomerDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCFClientWebApplication.CustomerService.ServiceExceptions), Action="http://tempuri.org/IService/DeletCustomerDataServiceExceptionsFault", Name="ServiceExceptions", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
        string DeletCustomerData(WCFClientWebApplication.CustomerService.Customers Customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeletCustomerData", ReplyAction="http://tempuri.org/IService/DeletCustomerDataResponse")]
        System.Threading.Tasks.Task<string> DeletCustomerDataAsync(WCFClientWebApplication.CustomerService.Customers Customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCustomerData", ReplyAction="http://tempuri.org/IService/GetCustomerDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCFClientWebApplication.CustomerService.ServiceExceptions), Action="http://tempuri.org/IService/GetCustomerDataServiceExceptionsFault", Name="ServiceExceptions", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
        System.Data.DataTable GetCustomerData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCustomerData", ReplyAction="http://tempuri.org/IService/GetCustomerDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetCustomerDataAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WCFClientWebApplication.CustomerService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WCFClientWebApplication.CustomerService.IService>, WCFClientWebApplication.CustomerService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SaveCustomerData(WCFClientWebApplication.CustomerService.Customers Customer) {
            return base.Channel.SaveCustomerData(Customer);
        }
        
        public System.Threading.Tasks.Task<string> SaveCustomerDataAsync(WCFClientWebApplication.CustomerService.Customers Customer) {
            return base.Channel.SaveCustomerDataAsync(Customer);
        }
        
        public string UpdateCustomerData(WCFClientWebApplication.CustomerService.Customers Customer) {
            return base.Channel.UpdateCustomerData(Customer);
        }
        
        public System.Threading.Tasks.Task<string> UpdateCustomerDataAsync(WCFClientWebApplication.CustomerService.Customers Customer) {
            return base.Channel.UpdateCustomerDataAsync(Customer);
        }
        
        public string DeletCustomerData(WCFClientWebApplication.CustomerService.Customers Customer) {
            return base.Channel.DeletCustomerData(Customer);
        }
        
        public System.Threading.Tasks.Task<string> DeletCustomerDataAsync(WCFClientWebApplication.CustomerService.Customers Customer) {
            return base.Channel.DeletCustomerDataAsync(Customer);
        }
        
        public System.Data.DataTable GetCustomerData() {
            return base.Channel.GetCustomerData();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetCustomerDataAsync() {
            return base.Channel.GetCustomerDataAsync();
        }
    }
}