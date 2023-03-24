namespace My_Logger
{
    public partial class Form1 : Form
    {

        string filePath = @"D:\Logs\report.html"; // specify your desired file path here
        Loggy logger = new Loggy();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void cmdLog_Click(object sender, EventArgs e)
        {
            logger.ExportToHtml(filePath); //Use default path
            MessageBox.Show("Export done!");
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            logger.Log("Action 0!");
            logger.Log("Action 1");
        }
    }
}