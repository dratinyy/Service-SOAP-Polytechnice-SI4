﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Soap_Velib.WS_Soap_Velib_Reference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Composite_City", Namespace="http://schemas.datacontract.org/2004/07/WS_Soap_Velib")]
    [System.SerializableAttribute()]
    public partial class Composite_City : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] CitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Commercial_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Country_codeField;
        
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
        public string[] Cities {
            get {
                return this.CitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.CitiesField, value) != true)) {
                    this.CitiesField = value;
                    this.RaisePropertyChanged("Cities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Commercial_name {
            get {
                return this.Commercial_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.Commercial_nameField, value) != true)) {
                    this.Commercial_nameField = value;
                    this.RaisePropertyChanged("Commercial_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country_code {
            get {
                return this.Country_codeField;
            }
            set {
                if ((object.ReferenceEquals(this.Country_codeField, value) != true)) {
                    this.Country_codeField = value;
                    this.RaisePropertyChanged("Country_code");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Composite_StationVelib", Namespace="http://schemas.datacontract.org/2004/07/WS_Soap_Velib")]
    [System.SerializableAttribute()]
    public partial class Composite_StationVelib : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Available_bike_standsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Available_bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BankingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Bike_standsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BonusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Contract_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Last_updateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WS_Soap_Velib.WS_Soap_Velib_Reference.Position PositionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
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
        public int Available_bike_stands {
            get {
                return this.Available_bike_standsField;
            }
            set {
                if ((this.Available_bike_standsField.Equals(value) != true)) {
                    this.Available_bike_standsField = value;
                    this.RaisePropertyChanged("Available_bike_stands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Available_bikes {
            get {
                return this.Available_bikesField;
            }
            set {
                if ((this.Available_bikesField.Equals(value) != true)) {
                    this.Available_bikesField = value;
                    this.RaisePropertyChanged("Available_bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Banking {
            get {
                return this.BankingField;
            }
            set {
                if ((this.BankingField.Equals(value) != true)) {
                    this.BankingField = value;
                    this.RaisePropertyChanged("Banking");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Bike_stands {
            get {
                return this.Bike_standsField;
            }
            set {
                if ((this.Bike_standsField.Equals(value) != true)) {
                    this.Bike_standsField = value;
                    this.RaisePropertyChanged("Bike_stands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Bonus {
            get {
                return this.BonusField;
            }
            set {
                if ((this.BonusField.Equals(value) != true)) {
                    this.BonusField = value;
                    this.RaisePropertyChanged("Bonus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contract_name {
            get {
                return this.Contract_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.Contract_nameField, value) != true)) {
                    this.Contract_nameField = value;
                    this.RaisePropertyChanged("Contract_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Last_update {
            get {
                return this.Last_updateField;
            }
            set {
                if ((object.ReferenceEquals(this.Last_updateField, value) != true)) {
                    this.Last_updateField = value;
                    this.RaisePropertyChanged("Last_update");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Number {
            get {
                return this.NumberField;
            }
            set {
                if ((this.NumberField.Equals(value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WS_Soap_Velib.WS_Soap_Velib_Reference.Position Position {
            get {
                return this.PositionField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionField, value) != true)) {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/WS_Soap_Velib")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LngField;
        
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
        public double Lat {
            get {
                return this.LatField;
            }
            set {
                if ((this.LatField.Equals(value) != true)) {
                    this.LatField = value;
                    this.RaisePropertyChanged("Lat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lng {
            get {
                return this.LngField;
            }
            set {
                if ((this.LngField.Equals(value) != true)) {
                    this.LngField = value;
                    this.RaisePropertyChanged("Lng");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WS_Soap_Velib_Reference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetContracts", ReplyAction="http://tempuri.org/IService/GetContractsResponse")]
        WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_City[] GetContracts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetContracts", ReplyAction="http://tempuri.org/IService/GetContractsResponse")]
        System.Threading.Tasks.Task<WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_City[]> GetContractsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllInformationForContract", ReplyAction="http://tempuri.org/IService/GetAllInformationForContractResponse")]
        WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib[] GetAllInformationForContract(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllInformationForContract", ReplyAction="http://tempuri.org/IService/GetAllInformationForContractResponse")]
        System.Threading.Tasks.Task<WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib[]> GetAllInformationForContractAsync(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStationInformationForContract", ReplyAction="http://tempuri.org/IService/GetStationInformationForContractResponse")]
        WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib GetStationInformationForContract(string contract, int station_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStationInformationForContract", ReplyAction="http://tempuri.org/IService/GetStationInformationForContractResponse")]
        System.Threading.Tasks.Task<WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib> GetStationInformationForContractAsync(string contract, int station_id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WS_Soap_Velib.WS_Soap_Velib_Reference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WS_Soap_Velib.WS_Soap_Velib_Reference.IService>, WS_Soap_Velib.WS_Soap_Velib_Reference.IService {
        
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
        
        public WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_City[] GetContracts() {
            return base.Channel.GetContracts();
        }
        
        public System.Threading.Tasks.Task<WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_City[]> GetContractsAsync() {
            return base.Channel.GetContractsAsync();
        }
        
        public WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib[] GetAllInformationForContract(string contract) {
            return base.Channel.GetAllInformationForContract(contract);
        }
        
        public System.Threading.Tasks.Task<WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib[]> GetAllInformationForContractAsync(string contract) {
            return base.Channel.GetAllInformationForContractAsync(contract);
        }
        
        public WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib GetStationInformationForContract(string contract, int station_id) {
            return base.Channel.GetStationInformationForContract(contract, station_id);
        }
        
        public System.Threading.Tasks.Task<WS_Soap_Velib.WS_Soap_Velib_Reference.Composite_StationVelib> GetStationInformationForContractAsync(string contract, int station_id) {
            return base.Channel.GetStationInformationForContractAsync(contract, station_id);
        }
    }
}
