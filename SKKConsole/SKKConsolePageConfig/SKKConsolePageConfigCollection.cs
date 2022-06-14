﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    [Serializable]
    [TypeConverter(typeof(ConsolePageConfigCollectionTypeConverter))]
    public class ConsolePageConfigCollection : CollectionBase, ICustomTypeDescriptor
    {
        #region COLLECTION IMPLEMENTATION

        public ConsolePageConfigCollection() { }
        public ConsolePageConfigCollection(List<ConsolePageConfig> _list) { foreach (ConsolePageConfig config in _list) List.Add(config); }

        public override string ToString() => "ConsolePageConfigCollection";

        public ConsolePageConfig this[int i] { get => (ConsolePageConfig)List[i]; }

        public void Add(ConsolePageConfig item) { if (item != null) List.Add(item); } //{ if(item != null) List.Add(item); }

        public void Remove(ConsolePageConfig item) => List.Remove(item);
        #endregion

        #region ICUSTOMTYPEDESCRIPTOR IMPLEMENTATION
        public String GetClassName() => TypeDescriptor.GetClassName(this, true);

        public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(this, true);

        public String GetComponentName() => TypeDescriptor.GetComponentName(this, true);

        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);

        public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(this, true);

        public PropertyDescriptor GetDefaultProperty() => TypeDescriptor.GetDefaultProperty(this, true);

        public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(this, editorBaseType, true);

        public EventDescriptorCollection GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents(this, attributes, true);

        public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(this, true);

        public object GetPropertyOwner(PropertyDescriptor pd) => this;

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) => GetProperties();

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(null);
            for (int i = 0; i < List.Count; i++) pdc.Add(new ConsolePageConfiCollectiongPropertyDescriptor(this, i));
            return pdc;
        }
        #endregion
    }

    public class ConsolePageConfiCollectiongPropertyDescriptor : PropertyDescriptor
    {
        private ConsolePageConfigCollection collection = null;
        private int index = -1;

        public ConsolePageConfiCollectiongPropertyDescriptor(ConsolePageConfigCollection coll, int i) : base("#" + i.ToString(), null)
        {
            collection = coll;
            index = i;
        }

        public override AttributeCollection Attributes { get => new AttributeCollection(null); }

        public override bool CanResetValue(object component) { return true; }

        public override Type ComponentType { get => collection.GetType(); }

        public override string DisplayName { get => "(collection)"; /*$"Page: {collection[index].PageName}";*/ }

        public override string ToString() => "Collection";

        public override string Description
        {
            get
            {
                ConsolePageConfig cpc = collection[index];
                StringBuilder sb = new StringBuilder();
                sb.Append("Page Name: " + cpc.PageName);
                sb.Append(", ");
                sb.Append("Color: " + cpc.PageColor.ToString());
                sb.Append(", ");
                sb.Append("Font: " + cpc.PageFont?.ToString());
                return sb.ToString();
            }
        }

        public override object GetValue(object component) => collection[index];

        public override bool IsReadOnly { get => false; }

        public override string Name { get => "#" + index.ToString(); }

        public override Type PropertyType { get => collection[index].GetType(); }

        public override void ResetValue(object component) { }

        public override bool ShouldSerializeValue(object component) => true;

        public override void SetValue(object component, object value) { }// => collection[index] = (ConsolePageConfig)value;
    }
}
