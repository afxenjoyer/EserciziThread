namespace Es._2_16
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        static async Task DoWorkAsync(CancellationToken token)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(200);
                }
            }
            catch (OperationCanceledException exception)
            {
                MessageBox.Show("Operazione annullata");
            }
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            await DoWorkAsync(_cts.Token);
            MessageBox.Show("Terminato");
        }

        private void btnFerma_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
    }
}
