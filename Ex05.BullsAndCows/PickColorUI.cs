namespace Ex05.BullsAndCowsUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Ex05.BullsAndCows;
    using Ex05.BullsAndCowsLogic;

    public partial class PickColorUI : Form
    {
        private static Button s_ButtonColorRef = new Button();

        public PickColorUI()
        {
            InitializeComponent();
        }

        private void PickColorUI_Load(object sender, EventArgs e)
        {
            foreach (var color in GameLogic.UserChosenColorArray)
            {
                switch (color)
                {
                    case "Turquoise":
                        buttonTurquoise.Enabled = false;
                        break;

                    case "Red":
                        buttonRed.Enabled = false;
                        break;

                    case "Purple":
                        buttonPurple.Enabled = false;
                        break;

                    case "Blue":
                        buttonBlue.Enabled = false;
                        break;

                    case "Yellow":
                        buttonYellow.Enabled = false;
                        break;

                    case "Brown":
                        buttonBrown.Enabled = false;
                        break;

                    case "White":
                        buttonWhite.Enabled = false;
                        break;

                    case "Green":
                        buttonGreen.Enabled = false;
                        break;
                }
            }
        }

        private void buttonTurquoise_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Turquoise;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Turquoise.ToString());
            this.Close();
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Red;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Red.ToString());
            this.Close();
        }

        private void buttonPurple_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Purple;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Purple.ToString());
            this.Close();
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Blue;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Blue.ToString());
            this.Close();
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Yellow;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Yellow.ToString());
            this.Close();
        }

        private void buttonBrown_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Brown;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Brown.ToString());
            this.Close();
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.White;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.White.ToString());
            this.Close();
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            s_ButtonColorRef = (this.Owner as BoardGameUI).ButtonRef;
            s_ButtonColorRef.BackColor = Color.Green;
            inputColorToArray(s_ButtonColorRef, enumColorsChoices.eColor.Green.ToString());
            this.Close();
        }

        private void inputColorToArray(Button i_Button, string i_Color)
        {
            switch (i_Button.Name)
            {
                case "button1":
                    GameLogic.UserChosenColorArray[0] = i_Color;
                    break;

                case "button2":
                    GameLogic.UserChosenColorArray[1] = i_Color;
                    break;

                case "button3":
                    GameLogic.UserChosenColorArray[2] = i_Color;
                    break;

                case "button4":
                    GameLogic.UserChosenColorArray[3] = i_Color;
                    break;
            }
        }
    }
}
