using System;
using System.Configuration;

namespace urlHandler.Common.Configuration
{
    public class DefaultApplicationCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DefaultApplicationElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((DefaultApplicationElement)element).Protocol;
        }

        public DefaultApplicationElement this[int index]
        {
            get
            {
                return (DefaultApplicationElement)BaseGet(index);
            }

            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public DefaultApplicationElement this[string name]
        {
            get
            {
                return (DefaultApplicationElement)BaseGet(name);
            }
        }

        public int IndexOf(DefaultApplicationElement defApp)
        {
            return BaseIndexOf(defApp);
        }

        public void Add(DefaultApplicationElement defApp)
        {
            BaseAdd(defApp);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(DefaultApplicationElement defApp)
        {
            if (BaseIndexOf(defApp) >= 0)
                BaseRemove(defApp.Protocol);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
