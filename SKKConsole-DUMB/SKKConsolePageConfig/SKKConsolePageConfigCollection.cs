#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Collections;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    //[Serializable]
    //[TypeConverter(typeof(ConsolePageConfigCollectionTypeConverter))]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ConsolePageConfigCollection : CollectionBase, ICustomTypeDescriptor
    {
        #region CollectionBase Implementation
        public ConsolePageConfigCollection() { }

        public ConsolePageConfigCollection(List<ConsolePageConfig> items)
        {
            foreach (ConsolePageConfig item in items) List.Add(item);
        }

        public override string ToString() { return "ConsolePageConfigCollection"; }

        public ConsolePageConfig this[int i] { get => (ConsolePageConfig)this.List[i]; }

        public void Add(ConsolePageConfig? item) { this.List.Add(item); }
        
        public void Remove(ConsolePageConfig item) { this.List.Remove(item); }
        #endregion

        #region ICustomTypeDescriptor Implementation
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
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

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(null);
            for (int i = 0; i < this.List.Count; i++) pdc.Add(new ConsolePageConfigPropertyDescriptor(this, i));
            return pdc;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }

    public class ConsolePageConfigPropertyDescriptor : PropertyDescriptor
    {
        private ConsolePageConfigCollection? collection = null;
        private int index = -1;

        public ConsolePageConfigPropertyDescriptor(ConsolePageConfigCollection? coll, int i) : base("#"+i.ToString(), null)
        {
            this.collection = coll;
            this.index = i;
        }

        public override AttributeCollection Attributes { get => new AttributeCollection(null); }

        public override bool CanResetValue(object component) { return true; }

        public override Type? ComponentType { get => this.collection?.GetType(); }

        public override string? DisplayName { get => "Page " + this.collection?[index].PageName; }

        public override string Description
        {
            get
            { 
                ConsolePageConfig cpc = this.collection![index];
                return "Page Name: " + cpc.PageName + ", Color: " + cpc.PageColor.ToString() + ", Font:" + cpc.PageFont?.ToString();
            }
        }

        public override object GetValue(object component) { return this.collection![index]; }

        public override bool IsReadOnly { get => false; }

        public override string Name { get => "#"+this.index.ToString(); }

        public override Type PropertyType { get => this.collection![index].GetType(); }

        public override void ResetValue(object component) { }

        public override bool ShouldSerializeValue(object component) { return true; }

        public override void SetValue(object component, object value) { }
    }
}
