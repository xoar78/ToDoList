using Xamarin.Forms;

namespace ToDoList.Model
{
    class TModel : BindableObject
    {
        private string _text;

        public TModel(string text)
        {
            Text = text;
        }

        public string Text
        {
            get => _text;
            set
            {
                if (_text == value) return;

                _text = value;
                OnPropertyChanged();
            }
        }

        private bool _done;

        public bool Done
        {
            get => _done;
            set
            {
                if (_done == value) return;

                _done = value;
                OnPropertyChanged();
            }
        }
    }
}
