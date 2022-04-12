namespace Final643450328_8
{
    public partial class Form1 : Form
    {
        private int inQu;
        private int inPri;
        public Form1()
        {
            InitializeComponent();
        }
        private void opToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV(*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                this.dataGridView1.Text = readAllLine[0];
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBoxProduct.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBoxQuantity.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBoxPrice.Text;

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string listRAW = readAllLine[i];
                    string[] productSplited = listRAW.Split(',');
                    QuantityAndPrice list = new QuantityAndPrice(productSplited[0], productSplited[1], productSplited[2]);
                }
            }
        }
        private void addDataToGridView(string product, string quantity, string price)
        {
            this.dataGridView1.Rows.Add(new string[] { product, quantity, price });
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strData = string.Empty;
            string filepath = String.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " CSV(*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != String.Empty)
                {
                    int row = this.dataGridView1.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j < column; j++)
                        {
                            if (this.dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    File.WriteAllText(saveFileDialog.FileName, this.dataGridView1.Text, System.Text.Encoding.UTF8);
                }
            }
        }
        int sumqu = 0, sumpri = 0, inqu = 0, inpri = 0;

        private void button17_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxProduct.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxQuantity.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxPrice.Text;

            sumqu = inQu + sumqu;
            sumpri = inPri + sumpri;

            textBoxAmount.Text = sumqu.ToString();
            textBoxChange.Text = sumpri.ToString();
        }
    }
}