namespace MultiMedia_MiniGame__Full_Edition_
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

  

        private void Form1_Load(object sender, EventArgs e) { 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MiniGame Game = new MiniGame();
            Hide();
            Game.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {

        }
    }
}