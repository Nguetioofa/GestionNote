namespace GestionNote.NameSpaceParametre
{
    internal class Parametre
    {
        private int _IdParamettre;
        private string _NomParamettre;
        private string _ValeurParamettre;

        public Parametre()
        {
            _IdParamettre = 0;
            _NomParamettre = string.Empty;
            _ValeurParamettre = string.Empty;
        }



        public int IdParamettre { get => _IdParamettre; set => _IdParamettre = value; }
        public string NomParamettre { get => _NomParamettre; set => _NomParamettre = value; }
        public string ValeurParamettre { get => _ValeurParamettre; set => _ValeurParamettre = value; }
    }
}
