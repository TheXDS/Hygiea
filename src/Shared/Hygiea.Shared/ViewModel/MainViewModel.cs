using System;
using System.Collections.Generic;
using System.Linq;
using TheXDS.Hygiea.Component;
using TheXDS.Hygiea.Models;

namespace TheXDS.Hygiea.ViewModel
{
    public abstract class MainViewModelBase<TView> : ViewModelBase , ISetupManager<MinimalSetupState> where TView : notnull, new()
    {
        private struct PageEntry
        {
            public ISetSetupPageViewModel ViewModel { get; }
            public TView View { get; }
            public PageEntry(ISetSetupPageViewModel viewModel, MainViewModelBase<TView> viewFactory)
            {
                (ViewModel = viewModel).SetSetup(viewFactory);
                View = viewFactory.GetView(viewModel);
            }
        }

        private readonly List<PageEntry> _pages = new List<PageEntry>();
        private int _pgindex;
        private string _title = "Setup";
        private bool _isVisible = true;

        public string Title
        {
            get => _title;
            set => Change(ref _title, value);
        }
        public bool IsVisible
        {
            get => _isVisible;
            set => Change(ref _isVisible, value);
        }

        public ICloseable Host { get; }
        public MinimalSetupState Settings { get; }
        public SimpleCommand BackCommand { get; }
        public SimpleCommand NextCommand { get; }
        public SimpleCommand CancelCommand { get; }

        public TView ActivePage => _pages.ElementAtOrDefault(_pgindex).View;

        public MainViewModelBase(ICloseable host, MinimalSetupState settings)
        {
            BackCommand = new SimpleCommand("Back", OnBack);
            NextCommand = new SimpleCommand("Next", OnNext);
            CancelCommand = new SimpleCommand("Cancel", OnCancel);

            Host = host;
            Settings = settings;
        }

        private void OnBack()
        {
            if (_pgindex > 0) _pgindex--;
            Navigate();
        }

        private void OnNext()
        {
            if (_pgindex < _pages.Count) _pgindex++;
            Navigate();
        }

        private void OnCancel()
        {
            Host.Close();
        }

        public void Fail(Exception ex)
        {
            _pages.Clear();
            _pgindex = 0;
            _pages.Add(new PageEntry(new ErrorViewModel() { Exception = ex }, this));
            Navigate();
        }

        public void Navigate()
        {
            var p = _pages[_pgindex];
            BackCommand.SetCanExecute(_pgindex > 0);
            NextCommand.SetCanExecute(_pgindex < _pages.Count - 1);
            Change(nameof(ActivePage));
            p.ViewModel.OnNavigated();
        }

        protected abstract TView GetView(ISetupPageViewModel viewModel);
    }
}
