using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using urlHandler.Common.Configuration;
using urlHandler.Configurator.Windows.Messages;

namespace urlHandler.Configurator.Windows.ViewModel
{
    public class RuleViewModel : ViewModelBase
    {
        private RuleElement ruleElement;

        private ICommand removeItemCommand;

        public RuleViewModel(RuleElement rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            ruleElement = rule;
        }

        #region Commands

        public ICommand RemoveItemCommand
        {
            get { return removeItemCommand ?? (removeItemCommand = new RelayCommand(RemoveItemCommandExecute)); }
        }

        #endregion

        public string Rule 
        {
            get
            {
                return ruleElement.ToUrlString();
            }

            set
            {
                var newRule = new RuleElement(value);
                ruleElement.Protocol = newRule.Protocol;
                ruleElement.Pattern = newRule.Pattern;
                RaisePropertyChanged("Rule");
            }
        }

        public string Application
        {
            get
            {
                return ruleElement.Application;
            }

            set
            { 
                ruleElement.Application = value;
                RaisePropertyChanged("Application");
            }
        }

        private void RemoveItemCommandExecute()
        {
            Messenger.Default.Send(new DeleteRuleMessage(this));
        }
    }
}