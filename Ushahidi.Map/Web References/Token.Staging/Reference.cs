﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.3082.
// 
namespace Ushahidi.Map.Token.Staging {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CommonServiceSoap", Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class CommonService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private CustomerInfoHeader customerInfoHeaderValueField;
        
        private UserInfoHeader userInfoHeaderValueField;
        
        /// <remarks/>
        public CommonService() {
            this.Url = "http://staging.common.virtualearth.net/find-30/common.asmx";
        }
        
        public CustomerInfoHeader CustomerInfoHeaderValue {
            get {
                return this.customerInfoHeaderValueField;
            }
            set {
                this.customerInfoHeaderValueField = value;
            }
        }
        
        public UserInfoHeader UserInfoHeaderValue {
            get {
                return this.userInfoHeaderValueField;
            }
            set {
                this.userInfoHeaderValueField = value;
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CustomerInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("UserInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://s.mappoint.net/mappoint-30/GetVersionInfo", RequestNamespace="http://s.mappoint.net/mappoint-30/", ResponseNamespace="http://s.mappoint.net/mappoint-30/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VersionInfo[] GetVersionInfo() {
            object[] results = this.Invoke("GetVersionInfo", new object[0]);
            return ((VersionInfo[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetVersionInfo(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetVersionInfo", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public VersionInfo[] EndGetVersionInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VersionInfo[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CustomerInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("UserInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://s.mappoint.net/mappoint-30/GetCountryRegionInfo", RequestNamespace="http://s.mappoint.net/mappoint-30/", ResponseNamespace="http://s.mappoint.net/mappoint-30/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CountryRegionInfo[] GetCountryRegionInfo(int[] entityIDs) {
            object[] results = this.Invoke("GetCountryRegionInfo", new object[] {
                        entityIDs});
            return ((CountryRegionInfo[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCountryRegionInfo(int[] entityIDs, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCountryRegionInfo", new object[] {
                        entityIDs}, callback, asyncState);
        }
        
        /// <remarks/>
        public CountryRegionInfo[] EndGetCountryRegionInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((CountryRegionInfo[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CustomerInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("UserInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://s.mappoint.net/mappoint-30/GetEntityTypes", RequestNamespace="http://s.mappoint.net/mappoint-30/", ResponseNamespace="http://s.mappoint.net/mappoint-30/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EntityType[] GetEntityTypes(string dataSourceName) {
            object[] results = this.Invoke("GetEntityTypes", new object[] {
                        dataSourceName});
            return ((EntityType[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetEntityTypes(string dataSourceName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetEntityTypes", new object[] {
                        dataSourceName}, callback, asyncState);
        }
        
        /// <remarks/>
        public EntityType[] EndGetEntityTypes(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((EntityType[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CustomerInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("UserInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://s.mappoint.net/mappoint-30/GetDataSourceInfo", RequestNamespace="http://s.mappoint.net/mappoint-30/", ResponseNamespace="http://s.mappoint.net/mappoint-30/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DataSource[] GetDataSourceInfo(string[] dataSourceNames) {
            object[] results = this.Invoke("GetDataSourceInfo", new object[] {
                        dataSourceNames});
            return ((DataSource[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDataSourceInfo(string[] dataSourceNames, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDataSourceInfo", new object[] {
                        dataSourceNames}, callback, asyncState);
        }
        
        /// <remarks/>
        public DataSource[] EndGetDataSourceInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((DataSource[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CustomerInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("UserInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://s.mappoint.net/mappoint-30/GetGreatCircleDistances", RequestNamespace="http://s.mappoint.net/mappoint-30/", ResponseNamespace="http://s.mappoint.net/mappoint-30/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double[] GetGreatCircleDistances(LatLong[] latLongs) {
            object[] results = this.Invoke("GetGreatCircleDistances", new object[] {
                        latLongs});
            return ((double[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetGreatCircleDistances(LatLong[] latLongs, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetGreatCircleDistances", new object[] {
                        latLongs}, callback, asyncState);
        }
        
        /// <remarks/>
        public double[] EndGetGreatCircleDistances(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((double[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CustomerInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("UserInfoHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://s.mappoint.net/mappoint-30/GetClientToken", RequestNamespace="http://s.mappoint.net/mappoint-30/", ResponseNamespace="http://s.mappoint.net/mappoint-30/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetClientToken(TokenSpecification specification) {
            object[] results = this.Invoke("GetClientToken", new object[] {
                        specification});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetClientToken(TokenSpecification specification, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetClientToken", new object[] {
                        specification}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetClientToken(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://s.mappoint.net/mappoint-30/", IsNullable=false)]
    public partial class CustomerInfoHeader : System.Web.Services.Protocols.SoapHeader {
        
        private short customLogEntryField;
        
        /// <remarks/>
        public short CustomLogEntry {
            get {
                return this.customLogEntryField;
            }
            set {
                this.customLogEntryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class TokenSpecification {
        
        private string clientIPAddressField;
        
        private int tokenValidityDurationMinutesField;
        
        /// <remarks/>
        public string ClientIPAddress {
            get {
                return this.clientIPAddressField;
            }
            set {
                this.clientIPAddressField = value;
            }
        }
        
        /// <remarks/>
        public int TokenValidityDurationMinutes {
            get {
                return this.tokenValidityDurationMinutesField;
            }
            set {
                this.tokenValidityDurationMinutesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class DataSource {
        
        private string nameField;
        
        private string versionField;
        
        private string descriptionField;
        
        private DataSourceCapability capabilityField;
        
        private int[] entityExtentField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public DataSourceCapability Capability {
            get {
                return this.capabilityField;
            }
            set {
                this.capabilityField = value;
            }
        }
        
        /// <remarks/>
        public int[] EntityExtent {
            get {
                return this.entityExtentField;
            }
            set {
                this.entityExtentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.FlagsAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public enum DataSourceCapability {
        
        /// <remarks/>
        CanDrawMaps = 1,
        
        /// <remarks/>
        CanFindPlaces = 2,
        
        /// <remarks/>
        CanFindNearby = 4,
        
        /// <remarks/>
        CanRoute = 8,
        
        /// <remarks/>
        CanFindAddress = 16,
        
        /// <remarks/>
        HasIcons = 32,
        
        /// <remarks/>
        DataServiceQuery = 64,
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class EntityProperty {
        
        private string nameField;
        
        private string displayNameField;
        
        private string dataTypeField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string DisplayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
        
        /// <remarks/>
        public string DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class EntityType {
        
        private string nameField;
        
        private string displayNameField;
        
        private string parentNameField;
        
        private string definitionField;
        
        private EntityProperty[] propertiesField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string DisplayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
        
        /// <remarks/>
        public string ParentName {
            get {
                return this.parentNameField;
            }
            set {
                this.parentNameField = value;
            }
        }
        
        /// <remarks/>
        public string Definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Property")]
        public EntityProperty[] Properties {
            get {
                return this.propertiesField;
            }
            set {
                this.propertiesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class LatLong {
        
        private double latitudeField;
        
        private double longitudeField;
        
        public LatLong() {
            this.latitudeField = 0;
            this.longitudeField = 0;
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(0)]
        public double Latitude {
            get {
                return this.latitudeField;
            }
            set {
                this.latitudeField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(0)]
        public double Longitude {
            get {
                return this.longitudeField;
            }
            set {
                this.longitudeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class CountryRegionInfo {
        
        private int entityIDField;
        
        private LatLong latLongField;
        
        private string iso2Field;
        
        private string iso3Field;
        
        private string friendlyNameField;
        
        private string officialNameField;
        
        /// <remarks/>
        public int EntityID {
            get {
                return this.entityIDField;
            }
            set {
                this.entityIDField = value;
            }
        }
        
        /// <remarks/>
        public LatLong LatLong {
            get {
                return this.latLongField;
            }
            set {
                this.latLongField = value;
            }
        }
        
        /// <remarks/>
        public string Iso2 {
            get {
                return this.iso2Field;
            }
            set {
                this.iso2Field = value;
            }
        }
        
        /// <remarks/>
        public string Iso3 {
            get {
                return this.iso3Field;
            }
            set {
                this.iso3Field = value;
            }
        }
        
        /// <remarks/>
        public string FriendlyName {
            get {
                return this.friendlyNameField;
            }
            set {
                this.friendlyNameField = value;
            }
        }
        
        /// <remarks/>
        public string OfficialName {
            get {
                return this.officialNameField;
            }
            set {
                this.officialNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class VersionInfo {
        
        private string componentField;
        
        private string versionField;
        
        /// <remarks/>
        public string Component {
            get {
                return this.componentField;
            }
            set {
                this.componentField = value;
            }
        }
        
        /// <remarks/>
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class CountryRegionContext {
        
        private int entityIDField;
        
        private string iso2Field;
        
        public CountryRegionContext() {
            this.entityIDField = 0;
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int EntityID {
            get {
                return this.entityIDField;
            }
            set {
                this.entityIDField = value;
            }
        }
        
        /// <remarks/>
        public string Iso2 {
            get {
                return this.iso2Field;
            }
            set {
                this.iso2Field = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public partial class CultureInfo {
        
        private string nameField;
        
        private int lcidField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public int Lcid {
            get {
                return this.lcidField;
            }
            set {
                this.lcidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://s.mappoint.net/mappoint-30/", IsNullable=false)]
    public partial class UserInfoHeader : System.Web.Services.Protocols.SoapHeader {
        
        private CultureInfo cultureField;
        
        private DistanceUnit defaultDistanceUnitField;
        
        private CountryRegionContext contextField;
        
        /// <remarks/>
        public CultureInfo Culture {
            get {
                return this.cultureField;
            }
            set {
                this.cultureField = value;
            }
        }
        
        /// <remarks/>
        public DistanceUnit DefaultDistanceUnit {
            get {
                return this.defaultDistanceUnitField;
            }
            set {
                this.defaultDistanceUnitField = value;
            }
        }
        
        /// <remarks/>
        public CountryRegionContext Context {
            get {
                return this.contextField;
            }
            set {
                this.contextField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://s.mappoint.net/mappoint-30/")]
    public enum DistanceUnit {
        
        /// <remarks/>
        Kilometer,
        
        /// <remarks/>
        Mile,
    }
}
