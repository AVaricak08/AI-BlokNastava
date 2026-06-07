using System.Xml.Linq;

namespace BlokAI
{
    public partial class Form1 : Form
    {
        private readonly string datasetPath = "miami_heat_ML_dataset.csv";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            string[] parts = txtUtakmica.Text.Trim().Split(',');

            if (parts.Length != 4)
            {
                MessageBox.Show("Format unosa: Tim, Lokacija, Sezona, BrojUtakmice\nPrimer: BOS, Home, 2012-13, 40",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string protivnik = parts[0].Trim();
            string lokacija = parts[1].Trim().ToLower();
            string sezona = parts[2].Trim();
            int brojUtakmice = int.Parse(parts[3].Trim());

            var validniTimovi = new List<string> { "BOS", "NYK", "PHI", "TOR", "ATL", "CHI", "CLE", "DET", "IND",
    "MIL", "GSW", "LAC", "LAL", "PHX", "SAC", "DEN", "MIN", "OKC",
    "POR", "UTA", "DAL", "HOU", "MEM", "NOP", "SAS", "CHA", "ORL",
    "WAS", "BKN", "NJN" };

            var validneSezone = File.ReadAllLines("miami_heat_ML_dataset.csv")
                .Skip(1)
                .Select(l => l.Split(',')[1].Trim())
                .Distinct()
                .ToList();

            if (!validniTimovi.Contains(protivnik.ToUpper()))
            {
                MessageBox.Show("Nevalidan tim. Primer: BOS, LAL, GSW...",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validneSezone.Contains(sezona))
            {
                MessageBox.Show($"Nevalidna sezona. Dostupne sezone: {string.Join(", ", validneSezone)}",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (brojUtakmice < 1 || brojUtakmice > 82)
            {
                MessageBox.Show("Broj utakmice mora biti između 1 i 82.",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lokacija != "home" && lokacija != "away")
            {
                MessageBox.Show("Lokacija mora biti 'Home' ili 'Away'.",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (forma5, forma10, oppForma5, oppForma10) = IzracunajFormu(protivnik,sezona,brojUtakmice);

            var data = new MLModel1.ModelInput()
            {
                Je_domacin = lokacija == "home" ? 1f : 0f,
                Forma_5 = forma5,
                Forma_10 = forma10,
                Forma_opp_5 = oppForma5,
                Forma_opp_10 = oppForma10,
            };

            var result = MLModel1.Predict(data);
            string predicted = result.Score >= 0.5f ? "✅ POBEDA" : "❌ PORAZ";

            lblRezultat.Text =
                $"Protivnik: {protivnik}\n" +
                $"Lokacija: {parts[1].Trim()}\n" +
                $"Sezona: {sezona}\n" +
                $"Forma MIA  (5):  {forma5}/5\n" +
                $"Forma MIA  (10): {forma10}/10\n" +
                $"──────────────────────\n" +
                $"Predikcija:          {predicted}\n" +
                $"Verovatnoća pobede:  {result.Score:0.000}\n" +
                $"Verovatnoća poraza:  {(1 - result.Score):0.000}";
        }
        private (float forma5, float forma10, float oppForma5, float oppForma10) IzracunajFormu(string protivnik, string sezona, int brojUtakmice)
        {
            var lines = File.ReadAllLines("miami_heat_ML_dataset.csv").Skip(1).ToArray();

            var mijamiUtakmice = lines
                .Select(l => l.Split(','))
                .Where(c => c.Length > 9 && c[1].Trim() == sezona)
                .Take(brojUtakmice - 1)
                .TakeLast(10)
                .OrderBy(c => c[2])
                .Select(c => int.Parse(c[9]))
                .ToList();

            float forma10 = (float)mijamiUtakmice.Sum();
            float forma5 = (float)mijamiUtakmice.TakeLast(5).Sum();

            var oppUtakmice = lines
                .Select(l => l.Split(','))
                .Where(c => c.Length > 9 && c[3].Trim().Equals(protivnik, StringComparison.OrdinalIgnoreCase))
                .Take(brojUtakmice - 1)
                .TakeLast(10)
                .Select(c => int.Parse(c[9]))
                .ToList();

            float oppForma10 = oppUtakmice.Count > 0 ? (float)oppUtakmice.Count(x => x == 0) : 5f;
            float oppForma5 = (float)oppUtakmice.TakeLast(5).Count(x => x == 0);

            return (forma5, forma10, oppForma5, oppForma10);
        }
    }
    }

