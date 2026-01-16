using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace yt_dlp_gui
{
    public partial class Form1 : Form
    {
                private DataSource ds;
        private BindingSource bs;
        string filePath = "";
        public Form1()
        {
            InitializeComponent();
            ds = new DataSource();
            bs = new BindingSource();
            bs.DataSource = ds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Green;
            label1.DataBindings.Add("Text", bs, "CounterVal", true, DataSourceUpdateMode.OnPropertyChanged);
            label2.Text = "No file loaded!";
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Change background colour":
                    colorDialog1.ShowDialog();
                    panel1.BackColor = colorDialog1.Color;
                    break;
                case "Change text colour":
                    colorDialog1.ShowDialog();
                    label1.ForeColor = colorDialog1.Color;
                    break;
            }
        }

        private void loadFileButton_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select text file";
            openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "counters");
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                //Debug.WriteLine(filePath);
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    if (fileContent == "")
                    {
                        ds.CounterVal = 0;
                        label1.Text = ds.CounterVal.ToString();
                        label2.Text = $"{openFileDialog.SafeFileName} loaded!";
                    }
                    else { 
                    int number;
                        if (int.TryParse(fileContent, out number))
                        {
                            ds.CounterVal = int.Parse(fileContent);
                            label1.Text = ds.CounterVal.ToString();
                            label2.Text = $"{openFileDialog.SafeFileName} loaded!";
                        }
                        else
                        {
                            throw new Exception($"Error: {openFileDialog.SafeFileName} does not only consist of a number!");

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addButton_MouseDown(object sender, MouseEventArgs e)
        {
            ds.CounterVal++;
            if (filePath != "")
            {
                File.WriteAllText(filePath, ds.CounterVal.ToString());
            }
        }

        private void subtractButton_MouseDown(object sender, MouseEventArgs e)
        {
            ds.CounterVal--;
            if (filePath != "")
            {
                File.WriteAllText(filePath, ds.CounterVal.ToString());
            }
        }
    }
}

public class DataSource : INotifyPropertyChanged
{
    private int _counterVal;
    public int CounterVal
    {
        get { return _counterVal; }
        set
        {
            if (_counterVal != value)
            {
                _counterVal = value;
                OnPropertyChanged("CounterVal");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}