using TuringMachine.ViewModels.Base;

namespace TuringMachine.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Title : string – Window  Title
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

        #region Status : string – App status
        /// <summary>
        /// App status
        /// </summary>
        private string _Status = "Готов";
        public string Status
        {
            get => _Status;
            //set => Set(ref _Status, value);
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    OnPropertyChanged();
                }

            }
        }
        #endregion
    }
}
