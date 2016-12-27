using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure.Presenters;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Core.ViewModels
{
    public class MainViewModel : MultiViewModel
    {
        private readonly DynamicMultiViewModelPresenter _dynamicMultiViewModelPresenter;
        private readonly IViewModelPresenter _presenter;
        private int _number;

        public MainViewModel(IViewModelPresenter presenter)
        {
            _presenter = presenter;
            _dynamicMultiViewModelPresenter = new DynamicMultiViewModelPresenter(this);
            _presenter.DynamicPresenters.Add(_dynamicMultiViewModelPresenter);
            AddNewTabCommand = RelayCommandBase.FromAsyncHandler(AddNewTab);
        }

        public ICommand AddNewTabCommand { get; private set; }

        private async Task AddNewTab()
        {
            using (var vm = GetViewModel<ChildViewModel>())
            {
                vm.Init("#" + ++_number);
                var operation = vm.ShowAsync();

                await operation.NavigationCompletedTask;

                await operation;
            }
        }

        #region Overrides of ViewModelBase

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
                _presenter.DynamicPresenters.Remove(_dynamicMultiViewModelPresenter);
            base.OnDispose(disposing);
        }

        #endregion
    }
}
