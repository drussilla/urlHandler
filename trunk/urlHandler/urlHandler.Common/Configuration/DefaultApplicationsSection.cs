using System.Configuration;

namespace urlHandler.Common.Configuration
{
    public class DefaultApplicationsSection : ConfigurationSection
    {
        [ConfigurationProperty("apps", 
            IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DefaultApplicationCollection),
            AddItemName = "add",
            RemoveItemName = "remove",
            ClearItemsName = "clear")]
        public DefaultApplicationCollection Applications
        {
            get
            {
                return this["apps"] as DefaultApplicationCollection;
            }
        }
        
    }
}
