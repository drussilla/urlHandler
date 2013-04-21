using System;
using System.Configuration;

namespace urlHandler.Common.Configuration
{
    public class RuleCollection : ConfigurationElementCollection
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
            return new RuleElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((RuleElement)element).Name;
        }

        public RuleElement this[int index]
        {
            get
            {
                return (RuleElement)BaseGet(index);
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

        new public RuleElement this[string name]
        {
            get
            {
                return (RuleElement)BaseGet(name);
            }
        }

        public int IndexOf(RuleElement rule)
        {
            return BaseIndexOf(rule);
        }

        public void Add(RuleElement rule)
        {
            BaseAdd(rule);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(RuleElement rule)
        {
            if (BaseIndexOf(rule) >= 0)
                BaseRemove(rule.Name);
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
