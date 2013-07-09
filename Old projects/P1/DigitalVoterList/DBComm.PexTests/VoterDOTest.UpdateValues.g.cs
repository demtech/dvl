// <copyright file="VoterDOTest.UpdateValues.g.cs">Copyright �  2011</copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>

namespace DBComm.PexTests
{
    using System;

    using Microsoft.Pex.Framework.Explorable;

    using System.Data.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Pex.Framework.Generated;
    using Microsoft.Pex.Engine.Exceptions;

    using global::DBComm.DBComm.DO;

    public partial class VoterDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void UpdateValues658()
{
    VoterDO voterDO;
    VoterDO voterDO1;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO);
    voterDO1 = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "primaryKey", new uint?(302394113u));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<Voted>k__BackingField", default(bool?));
    PexInvariant.CheckInvariant((object)voterDO1);
    this.UpdateValues(voterDO, (IDataObject)voterDO1);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNotNull((object)(voterDO.PrimaryKey));
    Assert.AreEqual<uint>(302394113u, (uint)((object)(voterDO.PrimaryKey)));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>((string)null, voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void UpdateValues617()
{
    VoterDO voterDO;
    VoterDO voterDO1;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>((object)voterDO, "<Address>k__BackingField", "");
    PexInvariant.SetField<string>
        ((object)voterDO, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO);
    voterDO1 = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "primaryKey", new uint?(302394113u));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<CardPrinted>k__BackingField", default(bool?));
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO1);
    this.UpdateValues(voterDO, (IDataObject)voterDO1);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNotNull((object)(voterDO.PrimaryKey));
    Assert.AreEqual<uint>(302394113u, (uint)((object)(voterDO.PrimaryKey)));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>("", voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UpdateValuesThrowsContractException987()
{
    try
    {
      VoterDO voterDO;
      VoterDO voterDO1;
      voterDO = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO);
      voterDO1 = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>
          ((object)voterDO1, "primaryKey", new uint?(3046785860u));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO1, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO1, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO1, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO1);
      this.UpdateValues(voterDO, (IDataObject)voterDO1);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void UpdateValues376()
{
    VoterDO voterDO;
    VoterDO voterDO1;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO);
    voterDO1 = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "primaryKey", new uint?(302394113u));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>((object)voterDO1, "<City>k__BackingField", "");
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO1);
    this.UpdateValues(voterDO, (IDataObject)voterDO1);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNotNull((object)(voterDO.PrimaryKey));
    Assert.AreEqual<uint>(302394113u, (uint)((object)(voterDO.PrimaryKey)));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>((string)null, voterDO.Address);
    Assert.AreEqual<string>("", voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void UpdateValues654()
{
    VoterDO voterDO;
    VoterDO voterDO1;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO);
    voterDO1 = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "primaryKey", new uint?(302394113u));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>((object)voterDO1, "<Name>k__BackingField", "");
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO1);
    this.UpdateValues(voterDO, (IDataObject)voterDO1);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNotNull((object)(voterDO.PrimaryKey));
    Assert.AreEqual<uint>(302394113u, (uint)((object)(voterDO.PrimaryKey)));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>("", voterDO.Name);
    Assert.AreEqual<string>((string)null, voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void UpdateValues741()
{
    VoterDO voterDO;
    VoterDO voterDO1;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO);
    voterDO1 = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "primaryKey", new uint?(302394113u));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>((object)voterDO1, "<Address>k__BackingField", "");
    PexInvariant.SetField<string>
        ((object)voterDO1, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO1);
    this.UpdateValues(voterDO, (IDataObject)voterDO1);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNotNull((object)(voterDO.PrimaryKey));
    Assert.AreEqual<uint>(302394113u, (uint)((object)(voterDO.PrimaryKey)));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>("", voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
public void UpdateValues889()
{
    VoterDO voterDO;
    VoterDO voterDO1;
    voterDO = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO);
    voterDO1 = PexInvariant.CreateInstance<VoterDO>();
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "primaryKey", new uint?(268780865u));
    PexInvariant.SetField<EntityRef<PollingStationDO>>
        ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
    PexInvariant.SetField<uint?>
        ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Name>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<Address>k__BackingField", (string)null);
    PexInvariant.SetField<string>
        ((object)voterDO1, "<City>k__BackingField", (string)null);
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
    PexInvariant.SetField<bool?>
        ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
    PexInvariant.CheckInvariant((object)voterDO1);
    this.UpdateValues(voterDO, (IDataObject)voterDO1);
    Assert.IsNotNull((object)voterDO);
    Assert.IsNotNull((object)(voterDO.PrimaryKey));
    Assert.AreEqual<uint>(268780865u, (uint)((object)(voterDO.PrimaryKey)));
    Assert.IsNull((object)(voterDO.PollingStationId));
    Assert.AreEqual<string>((string)null, voterDO.Name);
    Assert.AreEqual<string>((string)null, voterDO.Address);
    Assert.AreEqual<string>((string)null, voterDO.City);
    Assert.IsNotNull((object)(voterDO.CardPrinted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.CardPrinted)));
    Assert.IsNotNull((object)(voterDO.Voted));
    Assert.AreEqual<bool>(true, (bool)((object)(voterDO.Voted)));
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UpdateValuesThrowsContractException596()
{
    try
    {
      VoterDO voterDO;
      VoterDO voterDO1;
      voterDO = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>((object)voterDO, "<Address>k__BackingField", "");
      PexInvariant.SetField<string>
          ((object)voterDO, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO);
      voterDO1 = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO1, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO1, "<PollingStationId>k__BackingField", new uint?(2u));
      PexInvariant.SetField<string>
          ((object)voterDO1, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO1, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO1, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO1);
      this.UpdateValues(voterDO, (IDataObject)voterDO1);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UpdateValuesThrowsContractException327()
{
    try
    {
      VoterDO voterDO;
      PollingStationDO pollingStationDO;
      voterDO = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO);
      pollingStationDO = new PollingStationDO
                             (default(uint?), default(uint?), (string)null, (string)null);
      this.UpdateValues(voterDO, (IDataObject)pollingStationDO);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UpdateValuesThrowsContractException717()
{
    try
    {
      VoterDO voterDO;
      VoterDO voterDO1;
      voterDO = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO);
      voterDO1 = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO1, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO1, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO1, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO1, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO1, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO1, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO1, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO1, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO1);
      this.UpdateValues(voterDO, (IDataObject)voterDO1);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UpdateValuesThrowsContractException821()
{
    try
    {
      VoterDO voterDO;
      voterDO = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO);
      this.UpdateValues(voterDO, (IDataObject)voterDO);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(VoterDOTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void UpdateValuesThrowsContractException387()
{
    try
    {
      VoterDO voterDO;
      voterDO = PexInvariant.CreateInstance<VoterDO>();
      PexInvariant.SetField<uint?>((object)voterDO, "primaryKey", default(uint?));
      PexInvariant.SetField<EntityRef<PollingStationDO>>
          ((object)voterDO, "_pollingStation", default(EntityRef<PollingStationDO>));
      PexInvariant.SetField<uint?>
          ((object)voterDO, "<PollingStationId>k__BackingField", default(uint?));
      PexInvariant.SetField<string>
          ((object)voterDO, "<Name>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<Address>k__BackingField", (string)null);
      PexInvariant.SetField<string>
          ((object)voterDO, "<City>k__BackingField", (string)null);
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<CardPrinted>k__BackingField", new bool?(true));
      PexInvariant.SetField<bool?>
          ((object)voterDO, "<Voted>k__BackingField", new bool?(true));
      PexInvariant.CheckInvariant((object)voterDO);
      this.UpdateValues(voterDO, (IDataObject)null);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
    }
}