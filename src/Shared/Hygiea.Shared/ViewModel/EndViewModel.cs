namespace TheXDS.Hygiea.ViewModel
{
    public abstract class EndViewModel : SetupPageViewModel
    {
        private readonly string _exitLabel;
        public EndViewModel() : this("Exit")
        {
        }

        protected EndViewModel(string exitLabel)
        {
            _exitLabel = exitLabel;
        }

        public override sealed void OnNavigated()
        {
            Setup.NextCommand.SetCanExecute(false);
            Setup.BackCommand.SetCanExecute(false);
            Setup.CancelCommand.SetCanExecute(true);
            Setup.CancelCommand.Label = _exitLabel;
        }
    }
}
