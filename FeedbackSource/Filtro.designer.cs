﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FeedbackSource
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
    using System.Configuration;


    
    public partial class FiltroDataContext : System.Data.Linq.DataContext
	{
        
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();

        #endregion
      

        public FiltroDataContext() : 
               
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Server1"].ConnectionString, mappingSource)
		{
            OnCreated();
        }


        public FiltroDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FiltroDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FiltroDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FiltroDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<v_proveedor> v_proveedor
		{
			get
			{
				return this.GetTable<v_proveedor>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="inve.v_proveedor")]
	public partial class v_proveedor
	{
		
		private string _id_proveedor;
		
		private string _nombre;
		
		public v_proveedor()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_proveedor", DbType="varchar(10)", CanBeNull=false)]
		public string id
		{
			get
			{
				return this._id_proveedor;
			}
			set
			{
				if ((this._id_proveedor != value))
				{
					this._id_proveedor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="varchar(200)", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this._nombre = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
