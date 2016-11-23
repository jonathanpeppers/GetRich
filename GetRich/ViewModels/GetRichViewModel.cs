using System;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GetRich
{
    public class GetRichViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly GetRichClient _client = new GetRichClient();

        public GetRichViewModel()
        {
        }

        public Picture[] Pictures
        {
            get;
            private set;
        }

        public async Task Load()
        {
            Pictures = await _client.GetPictures();
            OnPropertyChanged(nameof(Pictures));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
