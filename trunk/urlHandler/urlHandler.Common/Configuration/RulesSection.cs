using System.Configuration;

namespace urlHandler.Common.Configuration
{
    public class RulesSection : ConfigurationSection
    {
        [ConfigurationProperty("rules", 
            IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(RuleCollection),
            AddItemName = "add",
            RemoveItemName = "remove",
            ClearItemsName = "clear")]
        public RuleCollection Rules
        {
            get
            {
                return this["rules"] as RuleCollection;
            }
        }
        
    }
}
