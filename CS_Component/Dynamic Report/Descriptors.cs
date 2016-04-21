// 

using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Reflection;


namespace GlobalizedPropertyGrid
{
	#region GlobalizedPropertyDescriptor

	/// <summary>
	/// GlobalizedPropertyDescriptor enhances the base class bay obtaining the display name for a property
	/// from the resource.
	/// </summary>
	public class GlobalizedPropertyDescriptor : PropertyDescriptor
	{
		private PropertyDescriptor basePropertyDescriptor; 
		private String localizedName = null;
		private String localizedDescription = null;
		private String localizedCategory = null;

		private ResourceManager m_rm= null;
		private string m_displayname= "";
		private string m_categoryname= "";
		private string m_descriptionname= "";

		public GlobalizedPropertyDescriptor(PropertyDescriptor basePropertyDescriptor) : base(basePropertyDescriptor)
		{
			this.basePropertyDescriptor = basePropertyDescriptor;
            string tablename = basePropertyDescriptor.ComponentType.Namespace + ".Framwork." + basePropertyDescriptor.ComponentType.Name;
			// Now use table name and display name id to access the resources.  
			this.m_rm= new ResourceManager( tablename,basePropertyDescriptor.ComponentType.Assembly);

			this.m_displayname= this.basePropertyDescriptor.DisplayName;
			this.m_categoryname= this.basePropertyDescriptor.DisplayName + "Category";
			this.m_descriptionname= this.basePropertyDescriptor.DisplayName + "Description";
		}

		public override bool CanResetValue(object component)
		{
			return basePropertyDescriptor.CanResetValue(component);
		}

		public override Type ComponentType
		{
			get { return basePropertyDescriptor.ComponentType; }
		}

		public override string DisplayName
		{
			get 
			{
				if( this.localizedName== null)
				{
					string s = this.m_rm.GetString( this.m_displayname);
					this.localizedName = (s!=null)? s : this.m_displayname; 
				}

				return this.localizedName;
			}
		}

		public override string Description
		{
			get
			{
				if( this.localizedDescription== null)
				{
					string s = this.m_rm.GetString( this.m_descriptionname);
					this.localizedDescription = (s!=null)? s : ""; 
				}

				return this.localizedDescription;
			}
		}

		public override string Category
		{
			get
			{
				if( this.localizedCategory== null)
				{
					string s = this.m_rm.GetString( this.m_categoryname);
					this.localizedCategory = (s!=null)? s : ""; 
				}

				return this.localizedCategory;
			}
		}

		public override object GetValue(object component)
		{
			return this.basePropertyDescriptor.GetValue(component);
		}

		public override bool IsReadOnly
		{
			get { return this.basePropertyDescriptor.IsReadOnly; }
		}

		public override string Name
		{
			get { return this.basePropertyDescriptor.Name; }
		}

		public override Type PropertyType
		{
			get { return this.basePropertyDescriptor.PropertyType; }
		}

		public override void ResetValue(object component)
		{
			this.basePropertyDescriptor.ResetValue(component);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return this.basePropertyDescriptor.ShouldSerializeValue(component);
		}

		public override void SetValue(object component, object value)
		{
			this.basePropertyDescriptor.SetValue(component, value);
		}
	}
	#endregion

	#region GlobalizedObject

	/// <summary>
	/// GlobalizedObject implements ICustomTypeDescriptor to enable 
	/// required functionality to describe a type (class).<br></br>
	/// The main task of this class is to instantiate our own property descriptor 
	/// of type GlobalizedPropertyDescriptor.  
	/// </summary>
	public class GlobalizedObject : ICustomTypeDescriptor
	{
		private PropertyDescriptorCollection globalizedProps;

		public String GetClassName()
		{
			return TypeDescriptor.GetClassName(this,true);
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this,true);
		}

		public String GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent() 
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public PropertyDescriptor GetDefaultProperty() 
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public object GetEditor(Type editorBaseType) 
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes) 
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		/// <summary>
		/// Called to get the properties of a type.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			if ( globalizedProps == null) 
			{
				// Get the collection of properties
				PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, attributes, true);

				globalizedProps = new PropertyDescriptorCollection(null);

				// For each property use a property descriptor of our own that is able to be globalized
				for( int i= 0; i< baseProps.Count; i++ )
				{
					globalizedProps.Add(new GlobalizedPropertyDescriptor( ( PropertyDescriptor)baseProps[i]));
				}
			}
			return globalizedProps;
		}

		public PropertyDescriptorCollection GetProperties()
		{
			// Only do once
			if ( globalizedProps == null) 
			{
				// Get the collection of properties
				PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);
				globalizedProps = new PropertyDescriptorCollection(null);

				// For each property use a property descriptor of our own that is able to be globalized
				for( int i= 0; i< baseProps.Count; i++ )
				{
					globalizedProps.Add(new GlobalizedPropertyDescriptor( ( PropertyDescriptor)baseProps[i]));
				}
			}
			return globalizedProps;
		}

		public object GetPropertyOwner(PropertyDescriptor pd) 
		{
			return this;
		}
	}

	#endregion
}
