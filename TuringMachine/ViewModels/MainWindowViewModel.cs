using TuringMachine.ViewModels.Base;

namespace TuringMachine.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Window Title
        /// <summary>
        /// Main Window Title
        /// </summary>
        private string _Title = "Машина Тьюринга";
        public string Title
        {
            get => _Title;
            //set => Set(ref _Title, value);
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    OnPropertyChanged();
                }

            }
        }
        #endregion

    }
}
