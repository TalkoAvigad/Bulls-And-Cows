namespace Ex05.BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Ex05.BullsAndCowsLogic;
    using Ex05.BullsAndCowsUI;

    public partial class BoardGameUI : Form
    {
        private const int k_ButtonStartingLocationOfX = 22;
        private static readonly List<List<Button>> sr_ListOfButtonList = new List<List<Button>>();
        private static readonly List<Button> sr_RandomButtonList = new List<Button>();
        private static int s_ColorButtonChoiceSize = 45;
        private static int s_ArrowButtonSizeX = 50;
        private static int s_ArrowButtonSizeY = 17;
        private static int s_FeedbackButtonSize = 17;
        private static int s_SpaceBetweenButtons = 50;
        private static int s_XPositionOfButton = 22;
        private static int s_YPositionOfButton = 22;
        private static int s_RowOfCurrentButtons = 0;
        private static bool s_EnableGame = true;
        private static Button s_ButtonRef = new Button();

        public BoardGameUI()
        {
            InitializeComponent();
            createButtonsRandomComputerColorsSelection();
            createGameBoardUI();
            GameLogic.RandomComputerColorsSelectionForButtons();
            initializeButton();
        }

        public Button ButtonRef
        {
            get
            {
                return s_ButtonRef;
            }

            set
            {
                s_ButtonRef = value;
            }
        }

        private static void initializeButton()
        {
            List<Button> rowButtons = sr_ListOfButtonList.ElementAt(s_RowOfCurrentButtons);

            for (int i = 0; i < 4; i++)
            {
                rowButtons.ElementAt(i).Enabled = true;
                GameLogic.UserChosenColorArray[i] = null;
            }
        }

        private static void disableButton()
        {
            List<Button> rowButtons = sr_ListOfButtonList.ElementAt(s_RowOfCurrentButtons);

            for (int i = 0; i < GameLogic.UserChosenColorArray.Length + 1; i++)
            {
                rowButtons.ElementAt(i).Enabled = false;
            }
        }

        private static void checkRow()
        {
            s_RowOfCurrentButtons++;
            if (s_RowOfCurrentButtons >= GameLogic.NumberOfGuesses)
            {
                s_RowOfCurrentButtons--;
                endGame();
            }
        }

        private static void enableCheckButton()
        {
            int countNull = 0;

            for (int i = 0; i < GameLogic.UserChosenColorArray.Length; i++)
            {
                if (GameLogic.UserChosenColorArray[i] != null)
                {
                    countNull++;
                }
            }

            if (countNull == 4)
            {
                sr_ListOfButtonList.ElementAt(s_RowOfCurrentButtons).ElementAt(4).Enabled = true;
            }
        }

        private static void initializeGuessAndFeedbackButton()
        {
            int countBlackButton = 0;

            for (int i = 0; i < GameLogic.UserChosenColorArray.Length; i++)
            {
                if (GameLogic.FeedbackStrArray[i].Equals("0"))
                {
                    sr_ListOfButtonList.ElementAt(s_RowOfCurrentButtons).ElementAt(5 + i).BackColor = Color.Black;
                    countBlackButton++;
                }
                else if (GameLogic.FeedbackStrArray[i].Equals("1"))
                {
                    sr_ListOfButtonList.ElementAt(s_RowOfCurrentButtons).ElementAt(5 + i).BackColor = Color.Yellow;
                }
            }

            if (countBlackButton == 4)
            {
                endGame();
            }
        }

        private static void endGame()
        {
            s_EnableGame = false;
            disableButton();

            for (int i = 0; i < GameLogic.UserChosenColorArray.Length; i++)
            {
                switch (GameLogic.ComputerGameColorArray[i])
                {
                    case "Turquoise":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Turquoise;
                        break;

                    case "Red":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Red;
                        break;

                    case "Purple":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Purple;
                        break;

                    case "Blue":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Blue;
                        break;

                    case "Yellow":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Yellow;
                        break;

                    case "Brown":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Brown;
                        break;

                    case "White":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.White;
                        break;

                    case "Green":
                        sr_RandomButtonList.ElementAt(i).BackColor = Color.Green;
                        break;
                }
            }
        }

        private void createButtonsRandomComputerColorsSelection()
        {
            for (int buttonCounter = 0; buttonCounter < 4; buttonCounter++)
            {
                Button button = new Button();

                if (buttonCounter < 4)
                {
                    button.Name = $"Random color button {buttonCounter + 1}";
                    button.Location = new Point(s_XPositionOfButton, s_YPositionOfButton);
                    button.Size = new Size(s_ColorButtonChoiceSize, s_ColorButtonChoiceSize);
                    button.BackColor = Color.Black;

                    s_XPositionOfButton += s_SpaceBetweenButtons;
                    Controls.Add(button);
                    button.Enabled = false;
                    sr_RandomButtonList.Add(button);
                }
            }
        }

        private void createGameBoardUI()
        {
            s_YPositionOfButton += 75;

            for (int rowButtonCounter = 0; rowButtonCounter < GameLogic.NumberOfGuesses; rowButtonCounter++)
            {
                List<Button> listOfButtonRow = new List<Button>();
                s_XPositionOfButton = k_ButtonStartingLocationOfX;

                for (int buttonCounter = 0; buttonCounter < 9; buttonCounter++)
                {
                    Button button = new Button();

                    if (buttonCounter < 4)
                    {
                        button.Name = $"button{buttonCounter + 1}";
                        button.Location = new Point(s_XPositionOfButton, s_YPositionOfButton);
                        button.Size = new Size(s_ColorButtonChoiceSize, s_ColorButtonChoiceSize);
                        button.Click += (object sender, EventArgs e) =>
                        {
                            ButtonRef = button;
                            PickColorUI boardColorUI = new PickColorUI();
                            boardColorUI.Owner = this;

                            boardColorUI.ShowDialog();
                            enableCheckButton();
                        };

                        s_XPositionOfButton += s_SpaceBetweenButtons;
                        Controls.Add(button);
                        button.Enabled = false;
                        listOfButtonRow.Add(button);
                    }
                    else if (buttonCounter == 4)
                    {
                        s_YPositionOfButton += 15;
                        button.Name = $"button{buttonCounter + 1}";
                        button.Text = "-->>";
                        button.Location = new Point(s_XPositionOfButton, s_YPositionOfButton);
                        button.Size = new Size(s_ArrowButtonSizeX, s_ArrowButtonSizeY);
                        button.Click += (object sender, EventArgs e) =>
                        {
                            GameLogic.CompareStrColors();
                            initializeGuessAndFeedbackButton();

                            if (s_EnableGame)
                            {
                                disableButton();
                                checkRow();

                                if (s_EnableGame)
                                {
                                    initializeButton();
                                }
                            }
                        };

                        s_XPositionOfButton += 55;
                        s_YPositionOfButton -= 13;

                        Controls.Add(button);
                        button.Enabled = false;
                        listOfButtonRow.Add(button);
                    }
                    else if (buttonCounter > 4 && buttonCounter < 7)
                    {
                        button.Name = $"button{buttonCounter + 1}";
                        button.Location = new Point(s_XPositionOfButton, s_YPositionOfButton);
                        button.Size = new Size(s_FeedbackButtonSize, s_FeedbackButtonSize);

                        if (buttonCounter == 5)
                        {
                            s_XPositionOfButton += 20;
                        }
                        else
                        {
                            s_XPositionOfButton -= 20;
                            s_YPositionOfButton += 20;
                        }

                        Controls.Add(button);
                        button.Enabled = false;
                        listOfButtonRow.Add(button);
                    }
                    else
                    {
                        button.Name = $"button{buttonCounter + 1}";
                        button.Location = new Point(s_XPositionOfButton, s_YPositionOfButton);
                        button.Size = new Size(s_FeedbackButtonSize, s_FeedbackButtonSize);
                        s_XPositionOfButton += 20;

                        Controls.Add(button);
                        button.Enabled = false;
                        listOfButtonRow.Add(button);
                    }
                }

                s_YPositionOfButton += 30;
                sr_ListOfButtonList.Add(listOfButtonRow);
            }

            s_XPositionOfButton += 22;
            s_YPositionOfButton += 10;
            ClientSize = new Size(s_XPositionOfButton, s_YPositionOfButton);
            MaximizeBox = false;
        }

        private void BoardGameUI_Load(object sender, EventArgs e)
        {
        }
    }
}
