// <copyright file="PollingStationDOTest.FullyInitialized.g.cs">Copyright �  2011</copyright>
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Pex.Framework.Generated;

    using global::DBComm.DBComm.DO;

    public partial class PollingStationDOTest
    {
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void FullyInitialized98003()
{
    PollingStationDO pollingStationDO;
    bool b;
    pollingStationDO =
      new PollingStationDO(new uint?(1u), new uint?(1u), (string)null, "");
    b = this.FullyInitialized(pollingStationDO);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNotNull((object)(pollingStationDO.PrimaryKey));
    Assert.AreEqual<uint>(1u, (uint)((object)(pollingStationDO.PrimaryKey)));
    Assert.IsNotNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<uint>(1u, (uint)((object)(pollingStationDO.MunicipalityId)));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>("", pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void FullyInitialized98002()
{
    PollingStationDO pollingStationDO;
    bool b;
    pollingStationDO =
      new PollingStationDO(default(uint?), new uint?(1u), (string)null, "");
    b = this.FullyInitialized(pollingStationDO);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNotNull((object)(pollingStationDO.PrimaryKey));
    Assert.AreEqual<uint>(1u, (uint)((object)(pollingStationDO.PrimaryKey)));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>("", pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void FullyInitialized98001()
{
    PollingStationDO pollingStationDO;
    bool b;
    pollingStationDO =
      new PollingStationDO(default(uint?), default(uint?), (string)null, "");
    b = this.FullyInitialized(pollingStationDO);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>("", pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
[TestMethod]
[PexGeneratedBy(typeof(PollingStationDOTest))]
public void FullyInitialized980()
{
    PollingStationDO pollingStationDO;
    bool b;
    pollingStationDO = new PollingStationDO
                           (default(uint?), default(uint?), (string)null, (string)null);
    b = this.FullyInitialized(pollingStationDO);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)pollingStationDO);
    Assert.IsNull((object)(pollingStationDO.PrimaryKey));
    Assert.IsNull((object)(pollingStationDO.MunicipalityId));
    Assert.AreEqual<string>((string)null, pollingStationDO.Name);
    Assert.AreEqual<string>((string)null, pollingStationDO.Address);
    Assert.IsNotNull(pollingStationDO.Voters);
}
    }
}