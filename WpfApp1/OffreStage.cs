using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class OffreStage : INotifyPropertyChanged
    {
        private string _titre = "";
        private string _secteur = "";
        private string _statut = "";

        public string Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                OnPropertyChanged();
            }
        }

        public string Secteur
        {
            get { return _secteur; }
            set
            {
                _secteur = value;
                OnPropertyChanged();
            }
        }

        public string Statut
        {
            get { return _statut; }
            set
            {
                _statut = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string? nomPropriete = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nomPropriete));
        }
    }
}