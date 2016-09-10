﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistence
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NCD")]
	public partial class NCDDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCriminal(Criminal instance);
    partial void UpdateCriminal(Criminal instance);
    partial void DeleteCriminal(Criminal instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertNationality(Nationality instance);
    partial void UpdateNationality(Nationality instance);
    partial void DeleteNationality(Nationality instance);
    partial void InsertRole(Role instance);
    partial void UpdateRole(Role instance);
    partial void DeleteRole(Role instance);
    #endregion
		
		public NCDDataContext() : 
				base(global::Persistence.Properties.Settings.Default.NCDConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NCDDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NCDDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NCDDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NCDDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Criminal> Criminals
		{
			get
			{
				return this.GetTable<Criminal>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Nationality> Nationalities
		{
			get
			{
				return this.GetTable<Nationality>();
			}
		}
		
		public System.Data.Linq.Table<Role> Roles
		{
			get
			{
				return this.GetTable<Role>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Criminals")]
	public partial class Criminal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private string _Name;
		
		private char _Sex;
		
		private byte _NationalityID;
		
		private System.Nullable<float> _HieghtMin;
		
		private System.Nullable<float> _HieghtMax;
		
		private System.Nullable<int> _WeightMin;
		
		private System.Nullable<int> _WeightMax;
		
		private System.Nullable<int> _AgeMin;
		
		private System.Nullable<int> _AgeMax;
		
		private EntitySet<Nationality> _Nationalities;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSexChanging(char value);
    partial void OnSexChanged();
    partial void OnNationalityIDChanging(byte value);
    partial void OnNationalityIDChanged();
    partial void OnHieghtMinChanging(System.Nullable<float> value);
    partial void OnHieghtMinChanged();
    partial void OnHieghtMaxChanging(System.Nullable<float> value);
    partial void OnHieghtMaxChanged();
    partial void OnWeightMinChanging(System.Nullable<int> value);
    partial void OnWeightMinChanged();
    partial void OnWeightMaxChanging(System.Nullable<int> value);
    partial void OnWeightMaxChanged();
    partial void OnAgeMinChanging(System.Nullable<int> value);
    partial void OnAgeMinChanged();
    partial void OnAgeMaxChanging(System.Nullable<int> value);
    partial void OnAgeMaxChanged();
    #endregion
		
		public Criminal()
		{
			this._Nationalities = new EntitySet<Nationality>(new Action<Nationality>(this.attach_Nationalities), new Action<Nationality>(this.detach_Nationalities));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Char(1) NOT NULL")]
		public char Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NationalityID", DbType="TinyInt NOT NULL")]
		public byte NationalityID
		{
			get
			{
				return this._NationalityID;
			}
			set
			{
				if ((this._NationalityID != value))
				{
					this.OnNationalityIDChanging(value);
					this.SendPropertyChanging();
					this._NationalityID = value;
					this.SendPropertyChanged("NationalityID");
					this.OnNationalityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HieghtMin", DbType="Real")]
		public System.Nullable<float> HieghtMin
		{
			get
			{
				return this._HieghtMin;
			}
			set
			{
				if ((this._HieghtMin != value))
				{
					this.OnHieghtMinChanging(value);
					this.SendPropertyChanging();
					this._HieghtMin = value;
					this.SendPropertyChanged("HieghtMin");
					this.OnHieghtMinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HieghtMax", DbType="Real")]
		public System.Nullable<float> HieghtMax
		{
			get
			{
				return this._HieghtMax;
			}
			set
			{
				if ((this._HieghtMax != value))
				{
					this.OnHieghtMaxChanging(value);
					this.SendPropertyChanging();
					this._HieghtMax = value;
					this.SendPropertyChanged("HieghtMax");
					this.OnHieghtMaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WeightMin", DbType="Int")]
		public System.Nullable<int> WeightMin
		{
			get
			{
				return this._WeightMin;
			}
			set
			{
				if ((this._WeightMin != value))
				{
					this.OnWeightMinChanging(value);
					this.SendPropertyChanging();
					this._WeightMin = value;
					this.SendPropertyChanged("WeightMin");
					this.OnWeightMinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WeightMax", DbType="Int")]
		public System.Nullable<int> WeightMax
		{
			get
			{
				return this._WeightMax;
			}
			set
			{
				if ((this._WeightMax != value))
				{
					this.OnWeightMaxChanging(value);
					this.SendPropertyChanging();
					this._WeightMax = value;
					this.SendPropertyChanged("WeightMax");
					this.OnWeightMaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AgeMin", DbType="Int")]
		public System.Nullable<int> AgeMin
		{
			get
			{
				return this._AgeMin;
			}
			set
			{
				if ((this._AgeMin != value))
				{
					this.OnAgeMinChanging(value);
					this.SendPropertyChanging();
					this._AgeMin = value;
					this.SendPropertyChanged("AgeMin");
					this.OnAgeMinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AgeMax", DbType="Int")]
		public System.Nullable<int> AgeMax
		{
			get
			{
				return this._AgeMax;
			}
			set
			{
				if ((this._AgeMax != value))
				{
					this.OnAgeMaxChanging(value);
					this.SendPropertyChanging();
					this._AgeMax = value;
					this.SendPropertyChanged("AgeMax");
					this.OnAgeMaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Criminal_Nationality", Storage="_Nationalities", ThisKey="NationalityID", OtherKey="Id")]
		public EntitySet<Nationality> Nationalities
		{
			get
			{
				return this._Nationalities;
			}
			set
			{
				this._Nationalities.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Nationalities(Nationality entity)
		{
			this.SendPropertyChanging();
			entity.Criminal = this;
		}
		
		private void detach_Nationalities(Nationality entity)
		{
			this.SendPropertyChanging();
			entity.Criminal = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private string _Username;
		
		private string _Email;
		
		private string _Password;
		
		private System.DateTime _LastLogin;
		
		private byte _RoleID;
		
		private EntitySet<Role> _Roles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnLastLoginChanging(System.DateTime value);
    partial void OnLastLoginChanged();
    partial void OnRoleIDChanging(byte value);
    partial void OnRoleIDChanged();
    #endregion
		
		public User()
		{
			this._Roles = new EntitySet<Role>(new Action<Role>(this.attach_Roles), new Action<Role>(this.detach_Roles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastLogin", DbType="DateTime NOT NULL")]
		public System.DateTime LastLogin
		{
			get
			{
				return this._LastLogin;
			}
			set
			{
				if ((this._LastLogin != value))
				{
					this.OnLastLoginChanging(value);
					this.SendPropertyChanging();
					this._LastLogin = value;
					this.SendPropertyChanged("LastLogin");
					this.OnLastLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="TinyInt NOT NULL")]
		public byte RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					this.OnRoleIDChanging(value);
					this.SendPropertyChanging();
					this._RoleID = value;
					this.SendPropertyChanged("RoleID");
					this.OnRoleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Role", Storage="_Roles", ThisKey="RoleID", OtherKey="Id")]
		public EntitySet<Role> Roles
		{
			get
			{
				return this._Roles;
			}
			set
			{
				this._Roles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Roles(Role entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Roles(Role entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Nationalities")]
	public partial class Nationality : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private byte _Id;
		
		private string _NationalityName;
		
		private EntityRef<Criminal> _Criminal;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(byte value);
    partial void OnIdChanged();
    partial void OnNationalityNameChanging(string value);
    partial void OnNationalityNameChanged();
    #endregion
		
		public Nationality()
		{
			this._Criminal = default(EntityRef<Criminal>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="TinyInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public byte Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._Criminal.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NationalityName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string NationalityName
		{
			get
			{
				return this._NationalityName;
			}
			set
			{
				if ((this._NationalityName != value))
				{
					this.OnNationalityNameChanging(value);
					this.SendPropertyChanging();
					this._NationalityName = value;
					this.SendPropertyChanged("NationalityName");
					this.OnNationalityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Criminal_Nationality", Storage="_Criminal", ThisKey="Id", OtherKey="NationalityID", IsForeignKey=true)]
		public Criminal Criminal
		{
			get
			{
				return this._Criminal.Entity;
			}
			set
			{
				Criminal previousValue = this._Criminal.Entity;
				if (((previousValue != value) 
							|| (this._Criminal.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Criminal.Entity = null;
						previousValue.Nationalities.Remove(this);
					}
					this._Criminal.Entity = value;
					if ((value != null))
					{
						value.Nationalities.Add(this);
						this._Id = value.NationalityID;
					}
					else
					{
						this._Id = default(byte);
					}
					this.SendPropertyChanged("Criminal");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Roles")]
	public partial class Role : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private byte _Id;
		
		private string _RoleName;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(byte value);
    partial void OnIdChanged();
    partial void OnRoleNameChanging(string value);
    partial void OnRoleNameChanged();
    #endregion
		
		public Role()
		{
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="TinyInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public byte Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string RoleName
		{
			get
			{
				return this._RoleName;
			}
			set
			{
				if ((this._RoleName != value))
				{
					this.OnRoleNameChanging(value);
					this.SendPropertyChanging();
					this._RoleName = value;
					this.SendPropertyChanged("RoleName");
					this.OnRoleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Role", Storage="_User", ThisKey="Id", OtherKey="RoleID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Roles.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Roles.Add(this);
						this._Id = value.RoleID;
					}
					else
					{
						this._Id = default(byte);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591