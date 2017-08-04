// Copyright (c) 2017 Jan Pluskal
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8009
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Netfox.NBARDatabase
{
// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 


    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class parameter
    {

        private string helpstringField;

        private string idField;

        private string nameField;

        /// <remarks/>
        [XmlElement("help-string", Form = XmlSchemaForm.Unqualified)
        ]
        public string helpstring
        {
            get { return this.helpstringField; }
            set { this.helpstringField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("NBAR2-Taxonomy", Namespace = "", IsNullable = false)]
    public partial class NBAR2Taxonomy
    {

        private object[] itemsField;

        /// <remarks/>
        [XmlElement("info", typeof (NBAR2TaxonomyInfo),
            Form = XmlSchemaForm.Unqualified)]
        [XmlElement("parameter", typeof (parameter))]
        [XmlElement("protocol", typeof (NBAR2TaxonomyProtocol),
            Form = XmlSchemaForm.Unqualified)]
        public object[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NBAR2TaxonomyInfo
    {

        private string nameField;

        private string fileversionField;

        private string ppversionField;

        private string iosversionField;

        private string platformField;

        private string engineversionField;

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement("file-version", Form = XmlSchemaForm.Unqualified
            )]
        public string fileversion
        {
            get { return this.fileversionField; }
            set { this.fileversionField = value; }
        }

        /// <remarks/>
        [XmlElement("pp-version", Form = XmlSchemaForm.Unqualified)]
        public string ppversion
        {
            get { return this.ppversionField; }
            set { this.ppversionField = value; }
        }

        /// <remarks/>
        [XmlElement("ios-version", Form = XmlSchemaForm.Unqualified)
        ]
        public string iosversion
        {
            get { return this.iosversionField; }
            set { this.iosversionField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string platform
        {
            get { return this.platformField; }
            set { this.platformField = value; }
        }

        /// <remarks/>
        [XmlElement("engine-version",
            Form = XmlSchemaForm.Unqualified)]
        public string engineversion
        {
            get { return this.engineversionField; }
            set { this.engineversionField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NBAR2TaxonomyProtocol
    {

        private string commonnameField;

        private string enabledField;

        private string engineidField;

        private string globalidField;

        private string helpstringField;

        private string idField;

        private string longdescriptionField;

        private string nameField;

        private string pdlversionField;

        private string referencesField;

        private string selectoridField;

        private string staticField;

        private string underlyingprotocolsField;

        private string usesbundlingField;

        private NBAR2TaxonomyProtocolAttributes[] attributesField;

        private NBAR2TaxonomyProtocolIpversion[] ipversionField;

        private NBAR2TaxonomyProtocolParameters[] parametersField;

        private NBAR2TaxonomyProtocolPorts[] portsField;

        /// <remarks/>
        [XmlElement("common-name", Form = XmlSchemaForm.Unqualified)
        ]
        public string commonname
        {
            get { return this.commonnameField; }
            set { this.commonnameField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string enabled
        {
            get { return this.enabledField; }
            set { this.enabledField = value; }
        }

        /// <remarks/>
        [XmlElement("engine-id", Form = XmlSchemaForm.Unqualified)]
        public string engineid
        {
            get { return this.engineidField; }
            set { this.engineidField = value; }
        }

        /// <remarks/>
        [XmlElement("global-id", Form = XmlSchemaForm.Unqualified)]
        public string globalid
        {
            get { return this.globalidField; }
            set { this.globalidField = value; }
        }

        /// <remarks/>
        [XmlElement("help-string", Form = XmlSchemaForm.Unqualified)
        ]
        public string helpstring
        {
            get { return this.helpstringField; }
            set { this.helpstringField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [XmlElement("long-description",
            Form = XmlSchemaForm.Unqualified)]
        public string longdescription
        {
            get { return this.longdescriptionField; }
            set { this.longdescriptionField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlElement("pdl-version", Form = XmlSchemaForm.Unqualified)
        ]
        public string pdlversion
        {
            get { return this.pdlversionField; }
            set { this.pdlversionField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string references
        {
            get { return this.referencesField; }
            set { this.referencesField = value; }
        }

        /// <remarks/>
        [XmlElement("selector-id", Form = XmlSchemaForm.Unqualified)
        ]
        public string selectorid
        {
            get { return this.selectoridField; }
            set { this.selectoridField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string @static
        {
            get { return this.staticField; }
            set { this.staticField = value; }
        }

        /// <remarks/>
        [XmlElement("underlying-protocols",
            Form = XmlSchemaForm.Unqualified)]
        public string underlyingprotocols
        {
            get { return this.underlyingprotocolsField; }
            set { this.underlyingprotocolsField = value; }
        }

        /// <remarks/>
        [XmlElement("uses-bundling",
            Form = XmlSchemaForm.Unqualified)]
        public string usesbundling
        {
            get { return this.usesbundlingField; }
            set { this.usesbundlingField = value; }
        }

        /// <remarks/>
        [XmlElement("attributes", Form = XmlSchemaForm.Unqualified)]
        public NBAR2TaxonomyProtocolAttributes[] attributes
        {
            get { return this.attributesField; }
            set { this.attributesField = value; }
        }

        /// <remarks/>
        [XmlElement("ip-version", Form = XmlSchemaForm.Unqualified)]
        public NBAR2TaxonomyProtocolIpversion[] ipversion
        {
            get { return this.ipversionField; }
            set { this.ipversionField = value; }
        }

        /// <remarks/>
        [XmlElement("parameters", Form = XmlSchemaForm.Unqualified)]
        public NBAR2TaxonomyProtocolParameters[] parameters
        {
            get { return this.parametersField; }
            set { this.parametersField = value; }
        }

        /// <remarks/>
        [XmlElement("ports", Form = XmlSchemaForm.Unqualified)]
        public NBAR2TaxonomyProtocolPorts[] ports
        {
            get { return this.portsField; }
            set { this.portsField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NBAR2TaxonomyProtocolAttributes
    {

        private string applicationgroupField;

        private string categoryField;

        private string encryptedField;

        private string p2ptechnologyField;

        private string subcategoryField;

        private string tunnelField;

        /// <remarks/>
        [XmlElement("application-group",
            Form = XmlSchemaForm.Unqualified)]
        public string applicationgroup
        {
            get { return this.applicationgroupField; }
            set { this.applicationgroupField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string category
        {
            get { return this.categoryField; }
            set { this.categoryField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string encrypted
        {
            get { return this.encryptedField; }
            set { this.encryptedField = value; }
        }

        /// <remarks/>
        [XmlElement("p2p-technology",
            Form = XmlSchemaForm.Unqualified)]
        public string p2ptechnology
        {
            get { return this.p2ptechnologyField; }
            set { this.p2ptechnologyField = value; }
        }

        /// <remarks/>
        [XmlElement("sub-category", Form = XmlSchemaForm.Unqualified
            )]
        public string subcategory
        {
            get { return this.subcategoryField; }
            set { this.subcategoryField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string tunnel
        {
            get { return this.tunnelField; }
            set { this.tunnelField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NBAR2TaxonomyProtocolIpversion
    {

        private string ipv4Field;

        private string ipv6Field;

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ipv4
        {
            get { return this.ipv4Field; }
            set { this.ipv4Field = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ipv6
        {
            get { return this.ipv6Field; }
            set { this.ipv6Field = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NBAR2TaxonomyProtocolParameters
    {

        private parameter[] fieldextractionField;

        private parameter[] subclassificationField;

        /// <remarks/>
        [XmlArray("field-extraction",
            Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("parameter", typeof (parameter), IsNullable = false)]
        public parameter[] fieldextraction
        {
            get { return this.fieldextractionField; }
            set { this.fieldextractionField = value; }
        }

        /// <remarks/>
        [XmlArray("sub-classification",
            Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("parameter", typeof (parameter), IsNullable = false)]
        public parameter[] subclassification
        {
            get { return this.subclassificationField; }
            set { this.subclassificationField = value; }
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NBAR2TaxonomyProtocolPorts
    {

        private string ipField;

        private string tcpField;

        private string udpField;

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ip
        {
            get { return this.ipField; }
            set { this.ipField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string tcp
        {
            get { return this.tcpField; }
            set { this.tcpField = value; }
        }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string udp
        {
            get { return this.udpField; }
            set { this.udpField = value; }
        }
    }
}