using DddInPractice.Logic.Atms;
using DddInPractice.UI.Atms;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            Atm atm = new AtmRepository().GetById(1);
            var viewModel = new AtmViewModel(atm);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
