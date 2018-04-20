// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CarProto.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from CarProto.proto</summary>
public static partial class CarProtoReflection {

  #region Descriptor
  /// <summary>File descriptor for CarProto.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static CarProtoReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg5DYXJQcm90by5wcm90byIZCghDYXJTdGF0cxINCgVzcGVlZBgBIAEoBWIG",
          "cHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::CarStats), global::CarStats.Parser, new[]{ "Speed" }, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class CarStats : pb::IMessage<CarStats> {
  private static readonly pb::MessageParser<CarStats> _parser = new pb::MessageParser<CarStats>(() => new CarStats());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<CarStats> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::CarProtoReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public CarStats() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public CarStats(CarStats other) : this() {
    speed_ = other.speed_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public CarStats Clone() {
    return new CarStats(this);
  }

  /// <summary>Field number for the "speed" field.</summary>
  public const int SpeedFieldNumber = 1;
  private int speed_;
  /// <summary>
  /// remember to use 1-15 for most common
  /// </summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Speed {
    get { return speed_; }
    set {
      speed_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as CarStats);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(CarStats other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Speed != other.Speed) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Speed != 0) hash ^= Speed.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Speed != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Speed);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Speed != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Speed);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(CarStats other) {
    if (other == null) {
      return;
    }
    if (other.Speed != 0) {
      Speed = other.Speed;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          Speed = input.ReadInt32();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
