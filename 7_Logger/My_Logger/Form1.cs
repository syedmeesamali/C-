namespace My_Logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLog_Click(object sender, EventArgs e)
        {
            var logger = new Logger();
            logger.Log("Action 1");
            logger.Log("Action 2");
            logger.ExportToHtml(".\report.html");
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}