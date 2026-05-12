namespace Es._2_22
{
    public partial class Form1 : Form
    {
        public List<Persona> Persone = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persone.Add(new Persona("Andrea", "Di Mingo", "1"));
            Persone.Add(new Persona("Giovanni", "Di Mingo", "1"));
            Persone.Add(new Persona("Aurora", "Di Mingo", "1"));
            Persone.Add(new Persona("Biagio", "Di Mingo", "1"));
            Persone.Add(new Persona("Annamaria", "Limongi", "1"));
            Persone.Add(new Persona("Giuseppe", "Carlomagno", "1"));
            Persone.Add(new Persona("Francesca", "Carlomagno", "1"));
            Persone.Add(new Persona("Alessandro", "Barani", "1"));
            Persone.Add(new Persona("Ernesto", "Lupicino", "1"));
            Persone.Add(new Persona("Luca", "Burgarello", "1"));

            lstResults.DataSource = Persone;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            tmrDebounce.Stop();
            tmrDebounce.Start();
        }

        private void tmrDebounce_Tick(object sender, EventArgs e)
        {
            tmrDebounce.Stop();
            lstResults.DataSource = RicercaCognome(txtSearch.Text);
        }

        public List<Persona> RicercaCognome(string cognome)
        {
            var personeTrovate = new List<Persona>();

            foreach (var persona in Persone)
            {
                if (persona.Cognome.StartsWith(cognome))
                {
                    personeTrovate.Add(persona);
                }
            }
            return personeTrovate;
        }
    }
}
