using Cyotek.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;

namespace yt_dlp_gui
{

    // TODO: Save loaded file between sessions
    public partial class Form1 : Form
    {
        private DataSource ds;
        private BindingSource bs;
        private System.Windows.Forms.Timer timer;
        string filePath = "";
        public Form1()
        {
            InitializeComponent();
            ds = new DataSource();
            bs = new BindingSource();
            bs.DataSource = ds;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);

        }

        private int count = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            count++;
            // Update the label's text
            statusText.Text = "Counter value saved!";

            // Optional: Stop the timer after a certain number of ticks
            if (count >= 3)
            {
                timer.Stop(); // or timer1.Enabled = false;
                statusText.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.DataBindings.Add("Text", bs, "CounterVal", true, DataSourceUpdateMode.OnPropertyChanged);

            try
            {
                string fileContent = File.ReadAllText(Properties.Settings.Default.LoadedFile);
                if (fileContent == "")
                {
                    ds.CounterVal = 0;
                    label1.Text = ds.CounterVal.ToString();
                    label2.Text = $"{Properties.Settings.Default.LoadedFile} loaded!";
                }
                else
                {
                    int number;
                    if (int.TryParse(fileContent, out number))
                    {
                        ds.CounterVal = int.Parse(fileContent);
                        label1.Text = ds.CounterVal.ToString();
                        label2.Text = $"{Properties.Settings.Default.SafeLoadedFile} loaded!";
                    }
                    else
                    {
                        throw new Exception($"Error: {Properties.Settings.Default.SafeLoadedFile} does not only consist of a number!");

                    }
                }
            }
            catch (Exception ex)
            {
                label2.Text = "No file loaded!";
            }
            
            if (Properties.Settings.Default.backgroundColour != 0)
            {
                panel1.BackColor = Color.FromArgb(Properties.Settings.Default.backgroundColour);
            } else
            {
                panel1.BackColor = Color.Green;
            }

            if (Properties.Settings.Default.fontColour != 0)
            {
                label1.ForeColor = Color.FromArgb(Properties.Settings.Default.fontColour);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (sender is ContextMenuStrip cms)
            {
                ColorPickerDialog cD = new ColorPickerDialog();

                switch (e.ClickedItem.Text)
                {
                    case "Change background colour":
                        cms.Close();
                        cD.Color = panel1.BackColor;
                        if (cD.ShowDialog() == DialogResult.OK)
                        {
                            panel1.BackColor = cD.Color;
                            Properties.Settings.Default.backgroundColour = cD.Color.ToArgb();
                            Properties.Settings.Default.Save();
                        }
                        break;
                    case "Change text colour":
                        cms.Close();
                        if (cD.ShowDialog() == DialogResult.OK)
                        {
                            label1.ForeColor = cD.Color;
                            Properties.Settings.Default.fontColour = cD.Color.ToArgb();
                            Properties.Settings.Default.Save();
                        }
                        break;
                }


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
                    else
                    {
                        int number;
                        if (int.TryParse(fileContent, out number))
                        {
                            ds.CounterVal = int.Parse(fileContent);
                            label1.Text = ds.CounterVal.ToString();
                            label2.Text = $"{openFileDialog.SafeFileName} loaded!";
                            Debug.WriteLine($"Saving file {openFileDialog.SafeFileName} to variable loadedFile");
                            Properties.Settings.Default.LoadedFile = openFileDialog.FileName;
                            Properties.Settings.Default.SafeLoadedFile = openFileDialog.SafeFileName;
                            Properties.Settings.Default.Save();
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

        private async void addButton_MouseDown(object sender, MouseEventArgs e)
        {
            ds.CounterVal++;
            if (filePath != "")
            {
                try
                {
                    File.WriteAllText(filePath, ds.CounterVal.ToString());
                    statusText.Text = "";
                    count = 0;
                    timer.Start();
                }
                catch
                {
                    statusText.Text = "Write failed.";
                }
            }
        }

        private async void subtractButton_MouseDown(object sender, MouseEventArgs e)
        {
            ds.CounterVal--;
            if (filePath != "")
            {
                try
                {
                    File.WriteAllText(filePath, ds.CounterVal.ToString());
                    statusText.Text = "";
                    count = 0;
                    timer.Start();
                }
                catch
                {
                    statusText.Text = "Write failed.";
                }
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            //Debug.WriteLine($"Remembering {Properties.Settings.Default.LoadedFile} for next session");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            panel1.BackColor = Color.Green;
            label1.ForeColor = Color.Black;
            label1.Text = "0";
            label2.Text = "No file loaded!";
            filePath = "";
            Properties.Settings.Default.LoadedFile = "";
            Properties.Settings.Default.SafeLoadedFile = "";
            Properties.Settings.Default.backgroundColour = panel1.BackColor.ToArgb();
            Properties.Settings.Default.fontColour = label1.ForeColor.ToArgb();
            Properties.Settings.Default.Save();

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