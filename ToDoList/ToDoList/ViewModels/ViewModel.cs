using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    class TViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TModel> TaskCollection { get; }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public TViewModel()
        {
            AddCommand = new Command(AddTask);
            DeleteCommand = new Command(DeleteTask);
            TaskCollection = new ObservableCollection<TModel>();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddTask(object text)
        {
            if(text.ToString() != "")
            {
                TaskCollection.Add(new TModel(text.ToString()));
                OnPropertyChanged();
            }
        }

        private void DeleteTask(object obj)
        {
            if (obj is TModel task)
            {
                TaskCollection.Remove(task);
            }
            OnPropertyChanged();
        }
    }
}
