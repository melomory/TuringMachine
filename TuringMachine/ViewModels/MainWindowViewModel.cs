using System.Windows;
using System.Windows.Input;
using TuringMachine.Infrastructure.Commands;
using TuringMachine.ViewModels.Base;
using System;

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

        #region Commands

        #region CloseAppCommand : ICommand – Command to close the app
        /// <summary>
        /// Commmand to close the app
        /// </summary>
        public ICommand CloseAppCommand { get; }
         
        private void OnCloseAppCommandExecuted(object p) => Application.Current.Shutdown();

        private bool CanCloseAppCommandExecute(object p) => true;
        #endregion


        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);

            #endregion

        }
    }
}
