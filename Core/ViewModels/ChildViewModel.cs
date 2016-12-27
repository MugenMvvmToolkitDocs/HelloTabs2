using MugenMvvmToolkit.ViewModels;

namespace Core.ViewModels
{
    internal class ChildViewModel : ViewModelBase
    {
        public string Number { get; private set; }

        public void Init(string number)
        {
            Number = number;
        }
    }
}
