namespace Ex05.BullsAndCowsUI
{
    using System;
    using System.Windows.Forms;
    using Ex05.BullsAndCows;
    using Ex05.BullsAndCowsLogic;

    public partial class StartGameUI : Form
    {
        public StartGameUI()
        {
            InitializeComponent();
        }

        private void buttonNumberOfGuesses_Click(object sender, EventArgs e)
        {
            buttonNumberOfGuesses.Text = GameLogic.SetNumberOfGuesses();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            BoardGameUI board = new BoardGameUI();

            board.ShowDialog();
        }

        private void StartGameUI_Load(object sender, EventArgs e)
        {
        }
    }
}
