using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using urlHandler.Common.Configuration;
using urlHandler.Configurator.Windows.Messages;

namespace urlHandler.Configurator.Windows.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ICommand addNewRuleCommand;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            var configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename =
                @"C:\Users\Ivan\Documents\GitHub\urlHandler\trunk\urlHandler\bin\Debug Windows\urlHandler.exe.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var rules = config.GetSection("RulesSection") as RulesSection;

            Messenger.Default.Register<DeleteRuleMessage>(this, DeleteRule);

            RuleList = new ObservableCollection<RuleViewModel>
                {
                    new RuleViewModel(new RuleElement("http://test.ru")),
                    new RuleViewModel(new RuleElement("https://test2.ru"))
                };
        }

        public ObservableCollection<RuleViewModel> RuleList { get; set; }

        public ICommand AddNewRuleCommand
        {
            get { return addNewRuleCommand ?? (addNewRuleCommand = new RelayCommand(AddRule)); }
        }

        private void AddRule()
        {
            RuleList.Add(new RuleViewModel(new RuleElement("")));
        }

        private void DeleteRule(DeleteRuleMessage message)
        {
            if (RuleList.Contains(message.Rule))
            {
                RuleList.Remove(message.Rule);
            }
        }
    }
}