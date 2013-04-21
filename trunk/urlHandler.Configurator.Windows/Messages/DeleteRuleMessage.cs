using System;
using GalaSoft.MvvmLight.Messaging;
using urlHandler.Configurator.Windows.ViewModel;

namespace urlHandler.Configurator.Windows.Messages
{
    public class DeleteRuleMessage : MessageBase 
    {
        public DeleteRuleMessage(RuleViewModel rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            Rule = rule;
        }

        public RuleViewModel Rule { get; private set; }
    }
}