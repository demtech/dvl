﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace Aegis_DVL.Database
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Entities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities() : base("name=Entities", "Entities")
        {
            ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(string connectionString) : base(connectionString, "Entities")
        {
            ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(EntityConnection connection) : base(connection, "Entities")
        {
            ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Voter> Voters
        {
            get
            {
                if ((_Voters == null))
                {
                    _Voters = base.CreateObjectSet<Voter>("Voters");
                }
                return _Voters;
            }
        }
        private ObjectSet<Voter> _Voters;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Precinct> Precincts
        {
            get
            {
                if ((_Precincts == null))
                {
                    _Precincts = base.CreateObjectSet<Precinct>("Precincts");
                }
                return _Precincts;
            }
        }
        private ObjectSet<Precinct> _Precincts;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Voters EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVoters(Voter voter)
        {
            base.AddObject("Voters", voter);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Precincts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPrecincts(Precinct precinct)
        {
            base.AddObject("Precincts", precinct);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="VoterModel", Name="Precinct")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Precinct : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Precinct object.
        /// </summary>
        /// <param name="precinctSplitId">Initial value of the PrecinctSplitId property.</param>
        /// <param name="locationName">Initial value of the LocationName property.</param>
        /// <param name="address">Initial value of the Address property.</param>
        /// <param name="cityStateZIP">Initial value of the CityStateZIP property.</param>
        public static Precinct CreatePrecinct(global::System.String precinctSplitId, global::System.String locationName, global::System.String address, global::System.String cityStateZIP)
        {
            Precinct precinct = new Precinct();
            precinct.PrecinctSplitId = precinctSplitId;
            precinct.LocationName = locationName;
            precinct.Address = address;
            precinct.CityStateZIP = cityStateZIP;
            return precinct;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PrecinctSplitId
        {
            get
            {
                return _PrecinctSplitId;
            }
            set
            {
                if (_PrecinctSplitId != value)
                {
                    OnPrecinctSplitIdChanging(value);
                    ReportPropertyChanging("PrecinctSplitId");
                    _PrecinctSplitId = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("PrecinctSplitId");
                    OnPrecinctSplitIdChanged();
                }
            }
        }
        private global::System.String _PrecinctSplitId;
        partial void OnPrecinctSplitIdChanging(global::System.String value);
        partial void OnPrecinctSplitIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LocationName
        {
            get
            {
                return _LocationName;
            }
            set
            {
                OnLocationNameChanging(value);
                ReportPropertyChanging("LocationName");
                _LocationName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LocationName");
                OnLocationNameChanged();
            }
        }
        private global::System.String _LocationName;
        partial void OnLocationNameChanging(global::System.String value);
        partial void OnLocationNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CityStateZIP
        {
            get
            {
                return _CityStateZIP;
            }
            set
            {
                OnCityStateZIPChanging(value);
                ReportPropertyChanging("CityStateZIP");
                _CityStateZIP = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CityStateZIP");
                OnCityStateZIPChanged();
            }
        }
        private global::System.String _CityStateZIP;
        partial void OnCityStateZIPChanging(global::System.String value);
        partial void OnCityStateZIPChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="VoterModel", Name="Voter")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Voter : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Voter object.
        /// </summary>
        /// <param name="voterId">Initial value of the VoterId property.</param>
        /// <param name="status">Initial value of the Status property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="dateOfBirth">Initial value of the DateOfBirth property.</param>
        /// <param name="eligibleDate">Initial value of the EligibleDate property.</param>
        /// <param name="mustShowId">Initial value of the MustShowId property.</param>
        /// <param name="absentee">Initial value of the Absentee property.</param>
        /// <param name="protectedAddress">Initial value of the ProtectedAddress property.</param>
        /// <param name="voted">Initial value of the Voted property.</param>
        /// <param name="returnStatus">Initial value of the ReturnStatus property.</param>
        /// <param name="ballotStyle">Initial value of the BallotStyle property.</param>
        /// <param name="precinctSub">Initial value of the PrecinctSub property.</param>
        /// <param name="address">Initial value of the Address property.</param>
        /// <param name="municipality">Initial value of the Municipality property.</param>
        /// <param name="zipCode">Initial value of the ZipCode property.</param>
        /// <param name="pollbookStatus">Initial value of the PollbookStatus property.</param>
        public static Voter CreateVoter(global::System.Int32 voterId, global::System.String status, global::System.String lastName, global::System.String firstName, global::System.DateTime dateOfBirth, global::System.DateTime eligibleDate, global::System.Boolean mustShowId, global::System.Boolean absentee, global::System.Boolean protectedAddress, global::System.Boolean voted, global::System.String returnStatus, global::System.Int32 ballotStyle, global::System.String precinctSub, global::System.String address, global::System.String municipality, global::System.String zipCode, global::System.Int32 pollbookStatus)
        {
            Voter voter = new Voter();
            voter.VoterId = voterId;
            voter.Status = status;
            voter.LastName = lastName;
            voter.FirstName = firstName;
            voter.DateOfBirth = dateOfBirth;
            voter.EligibleDate = eligibleDate;
            voter.MustShowId = mustShowId;
            voter.Absentee = absentee;
            voter.ProtectedAddress = protectedAddress;
            voter.Voted = voted;
            voter.ReturnStatus = returnStatus;
            voter.BallotStyle = ballotStyle;
            voter.PrecinctSub = precinctSub;
            voter.Address = address;
            voter.Municipality = municipality;
            voter.ZipCode = zipCode;
            voter.PollbookStatus = pollbookStatus;
            return voter;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 VoterId
        {
            get
            {
                return _VoterId;
            }
            set
            {
                if (_VoterId != value)
                {
                    OnVoterIdChanging(value);
                    ReportPropertyChanging("VoterId");
                    _VoterId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("VoterId");
                    OnVoterIdChanged();
                }
            }
        }
        private global::System.Int32 _VoterId;
        partial void OnVoterIdChanging(global::System.Int32 value);
        partial void OnVoterIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                OnStatusChanging(value);
                ReportPropertyChanging("Status");
                _Status = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Status");
                OnStatusChanged();
            }
        }
        private global::System.String _Status;
        partial void OnStatusChanging(global::System.String value);
        partial void OnStatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                OnMiddleNameChanging(value);
                ReportPropertyChanging("MiddleName");
                _MiddleName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MiddleName");
                OnMiddleNameChanged();
            }
        }
        private global::System.String _MiddleName;
        partial void OnMiddleNameChanging(global::System.String value);
        partial void OnMiddleNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Suffix
        {
            get
            {
                return _Suffix;
            }
            set
            {
                OnSuffixChanging(value);
                ReportPropertyChanging("Suffix");
                _Suffix = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Suffix");
                OnSuffixChanged();
            }
        }
        private global::System.String _Suffix;
        partial void OnSuffixChanging(global::System.String value);
        partial void OnSuffixChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                OnDateOfBirthChanging(value);
                ReportPropertyChanging("DateOfBirth");
                _DateOfBirth = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateOfBirth");
                OnDateOfBirthChanged();
            }
        }
        private global::System.DateTime _DateOfBirth;
        partial void OnDateOfBirthChanging(global::System.DateTime value);
        partial void OnDateOfBirthChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EligibleDate
        {
            get
            {
                return _EligibleDate;
            }
            set
            {
                OnEligibleDateChanging(value);
                ReportPropertyChanging("EligibleDate");
                _EligibleDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EligibleDate");
                OnEligibleDateChanged();
            }
        }
        private global::System.DateTime _EligibleDate;
        partial void OnEligibleDateChanging(global::System.DateTime value);
        partial void OnEligibleDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean MustShowId
        {
            get
            {
                return _MustShowId;
            }
            set
            {
                OnMustShowIdChanging(value);
                ReportPropertyChanging("MustShowId");
                _MustShowId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MustShowId");
                OnMustShowIdChanged();
            }
        }
        private global::System.Boolean _MustShowId;
        partial void OnMustShowIdChanging(global::System.Boolean value);
        partial void OnMustShowIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Absentee
        {
            get
            {
                return _Absentee;
            }
            set
            {
                OnAbsenteeChanging(value);
                ReportPropertyChanging("Absentee");
                _Absentee = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Absentee");
                OnAbsenteeChanged();
            }
        }
        private global::System.Boolean _Absentee;
        partial void OnAbsenteeChanging(global::System.Boolean value);
        partial void OnAbsenteeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean ProtectedAddress
        {
            get
            {
                return _ProtectedAddress;
            }
            set
            {
                OnProtectedAddressChanging(value);
                ReportPropertyChanging("ProtectedAddress");
                _ProtectedAddress = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ProtectedAddress");
                OnProtectedAddressChanged();
            }
        }
        private global::System.Boolean _ProtectedAddress;
        partial void OnProtectedAddressChanging(global::System.Boolean value);
        partial void OnProtectedAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DriversLicense
        {
            get
            {
                return _DriversLicense;
            }
            set
            {
                OnDriversLicenseChanging(value);
                ReportPropertyChanging("DriversLicense");
                _DriversLicense = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DriversLicense");
                OnDriversLicenseChanged();
            }
        }
        private global::System.String _DriversLicense;
        partial void OnDriversLicenseChanging(global::System.String value);
        partial void OnDriversLicenseChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Voted
        {
            get
            {
                return _Voted;
            }
            set
            {
                OnVotedChanging(value);
                ReportPropertyChanging("Voted");
                _Voted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Voted");
                OnVotedChanged();
            }
        }
        private global::System.Boolean _Voted;
        partial void OnVotedChanging(global::System.Boolean value);
        partial void OnVotedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ReturnStatus
        {
            get
            {
                return _ReturnStatus;
            }
            set
            {
                OnReturnStatusChanging(value);
                ReportPropertyChanging("ReturnStatus");
                _ReturnStatus = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ReturnStatus");
                OnReturnStatusChanged();
            }
        }
        private global::System.String _ReturnStatus;
        partial void OnReturnStatusChanging(global::System.String value);
        partial void OnReturnStatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 BallotStyle
        {
            get
            {
                return _BallotStyle;
            }
            set
            {
                OnBallotStyleChanging(value);
                ReportPropertyChanging("BallotStyle");
                _BallotStyle = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BallotStyle");
                OnBallotStyleChanged();
            }
        }
        private global::System.Int32 _BallotStyle;
        partial void OnBallotStyleChanging(global::System.Int32 value);
        partial void OnBallotStyleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PrecinctSub
        {
            get
            {
                return _PrecinctSub;
            }
            set
            {
                OnPrecinctSubChanging(value);
                ReportPropertyChanging("PrecinctSub");
                _PrecinctSub = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PrecinctSub");
                OnPrecinctSubChanged();
            }
        }
        private global::System.String _PrecinctSub;
        partial void OnPrecinctSubChanging(global::System.String value);
        partial void OnPrecinctSubChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Municipality
        {
            get
            {
                return _Municipality;
            }
            set
            {
                OnMunicipalityChanging(value);
                ReportPropertyChanging("Municipality");
                _Municipality = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Municipality");
                OnMunicipalityChanged();
            }
        }
        private global::System.String _Municipality;
        partial void OnMunicipalityChanging(global::System.String value);
        partial void OnMunicipalityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                OnZipCodeChanging(value);
                ReportPropertyChanging("ZipCode");
                _ZipCode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ZipCode");
                OnZipCodeChanged();
            }
        }
        private global::System.String _ZipCode;
        partial void OnZipCodeChanging(global::System.String value);
        partial void OnZipCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> StateId
        {
            get
            {
                return _StateId;
            }
            set
            {
                OnStateIdChanging(value);
                ReportPropertyChanging("StateId");
                _StateId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StateId");
                OnStateIdChanged();
            }
        }
        private Nullable<global::System.Int64> _StateId;
        partial void OnStateIdChanging(Nullable<global::System.Int64> value);
        partial void OnStateIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PollbookStatus
        {
            get
            {
                return _PollbookStatus;
            }
            set
            {
                OnPollbookStatusChanging(value);
                ReportPropertyChanging("PollbookStatus");
                _PollbookStatus = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PollbookStatus");
                OnPollbookStatusChanged();
            }
        }
        private global::System.Int32 _PollbookStatus;
        partial void OnPollbookStatusChanging(global::System.Int32 value);
        partial void OnPollbookStatusChanged();

        #endregion

    
    }

    #endregion

    
}
