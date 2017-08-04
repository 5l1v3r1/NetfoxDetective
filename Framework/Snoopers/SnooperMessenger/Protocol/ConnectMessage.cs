// Copyright (c) 2017 Jan Pluskal, Viliam Letavay
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

/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace Netfox.SnooperMessenger.Protocol
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ConnectMessage : TBase
  {
    private string _ClientIdentifier;
    private string _WillTopic;
    private string _WillMessage;
    private ClientInfo _ClientInfo;
    private string _Password;
    private List<string> _GetDiffsRequests;

    public string ClientIdentifier
    {
      get
      {
        return _ClientIdentifier;
      }
      set
      {
        __isset.ClientIdentifier = true;
        this._ClientIdentifier = value;
      }
    }

    public string WillTopic
    {
      get
      {
        return _WillTopic;
      }
      set
      {
        __isset.WillTopic = true;
        this._WillTopic = value;
      }
    }

    public string WillMessage
    {
      get
      {
        return _WillMessage;
      }
      set
      {
        __isset.WillMessage = true;
        this._WillMessage = value;
      }
    }

    public ClientInfo ClientInfo
    {
      get
      {
        return _ClientInfo;
      }
      set
      {
        __isset.ClientInfo = true;
        this._ClientInfo = value;
      }
    }

    public string Password
    {
      get
      {
        return _Password;
      }
      set
      {
        __isset.Password = true;
        this._Password = value;
      }
    }

    public List<string> GetDiffsRequests
    {
      get
      {
        return _GetDiffsRequests;
      }
      set
      {
        __isset.GetDiffsRequests = true;
        this._GetDiffsRequests = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool ClientIdentifier;
      public bool WillTopic;
      public bool WillMessage;
      public bool ClientInfo;
      public bool Password;
      public bool GetDiffsRequests;
    }

    public ConnectMessage() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                ClientIdentifier = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                WillTopic = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                WillMessage = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Struct) {
                ClientInfo = new ClientInfo();
                ClientInfo.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                Password = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.List) {
                {
                  GetDiffsRequests = new List<string>();
                  TList _list18 = iprot.ReadListBegin();
                  for( int _i19 = 0; _i19 < _list18.Count; ++_i19)
                  {
                    string _elem20;
                    _elem20 = iprot.ReadString();
                    GetDiffsRequests.Add(_elem20);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("ConnectMessage");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (ClientIdentifier != null && __isset.ClientIdentifier) {
          field.Name = "ClientIdentifier";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ClientIdentifier);
          oprot.WriteFieldEnd();
        }
        if (WillTopic != null && __isset.WillTopic) {
          field.Name = "WillTopic";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(WillTopic);
          oprot.WriteFieldEnd();
        }
        if (WillMessage != null && __isset.WillMessage) {
          field.Name = "WillMessage";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(WillMessage);
          oprot.WriteFieldEnd();
        }
        if (ClientInfo != null && __isset.ClientInfo) {
          field.Name = "ClientInfo";
          field.Type = TType.Struct;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          ClientInfo.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Password != null && __isset.Password) {
          field.Name = "Password";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Password);
          oprot.WriteFieldEnd();
        }
        if (GetDiffsRequests != null && __isset.GetDiffsRequests) {
          field.Name = "GetDiffsRequests";
          field.Type = TType.List;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, GetDiffsRequests.Count));
            foreach (string _iter21 in GetDiffsRequests)
            {
              oprot.WriteString(_iter21);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("ConnectMessage(");
      bool __first = true;
      if (ClientIdentifier != null && __isset.ClientIdentifier) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ClientIdentifier: ");
        __sb.Append(ClientIdentifier);
      }
      if (WillTopic != null && __isset.WillTopic) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("WillTopic: ");
        __sb.Append(WillTopic);
      }
      if (WillMessage != null && __isset.WillMessage) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("WillMessage: ");
        __sb.Append(WillMessage);
      }
      if (ClientInfo != null && __isset.ClientInfo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ClientInfo: ");
        __sb.Append(ClientInfo== null ? "<null>" : ClientInfo.ToString());
      }
      if (Password != null && __isset.Password) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Password: ");
        __sb.Append(Password);
      }
      if (GetDiffsRequests != null && __isset.GetDiffsRequests) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("GetDiffsRequests: ");
        __sb.Append(GetDiffsRequests);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}