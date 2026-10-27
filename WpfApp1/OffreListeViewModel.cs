using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp1
{
    public class OffreListeViewModel : ViewModelBase
    {
        public ObservableCollection<OffreStage> Offres { get; }
            = new ObservableCollection<OffreStage>();

        private OffreStage? _offreSelectionnee;

        public OffreStage? OffreSelectionnee
        {
            get { return _offreSelectionnee; }
            set { Set(ref _offreSelectionnee, value); }
        }

        public ICommand AjouterCommand { get; }
        public ICommand SupprimerCommand { get; }

        public OffreListeViewModel()
        {
            // Exemples d'offres affichées au démarrage
            Offres.Add(new OffreStage
            {
                Titre = "Développeur WPF",
                Secteur = "Informatique",
                Statut = "Ouvert"
            });

            Offres.Add(new OffreStage
            {
                Titre = "Analyste de données",
                Secteur = "Finance",
                Statut = "Fermé"
            });

            Offres.Add(new OffreStage
            {
                Titre = "Designer UX",
                Secteur = "Design",
                Statut = "Ouvert"
            });

            AjouterCommand = new RelayCommand(
                _ => AjouterOffre()
            );

            SupprimerCommand = new RelayCommand(
                _ => SupprimerOffre(),
                _ => OffreSelectionnee != null
            );
        }

        private void AjouterOffre()
        {
            OffreStage nouvelleOffre = new OffreStage
            {
                Titre = "Nouvelle offre",
                Secteur = "",
                Statut = "Ouvert"
            };

            Offres.Add(nouvelleOffre);
            OffreSelectionnee = nouvelleOffre;
        }

        private void SupprimerOffre()
        {
            if (OffreSelectionnee != null)
            {
                Offres.Remove(OffreSelectionnee);
                OffreSelectionnee = null;
            }
        }
    }
}