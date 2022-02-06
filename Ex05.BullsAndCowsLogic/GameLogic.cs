namespace Ex05.BullsAndCowsLogic
{
    using System;
    using System.Linq;

    public class GameLogic
    {
        private const int k_NumberOfColorChoices = 4;
        private const int k_MinGuesses = 4;
        private const int k_MaxGuesses = 10;
        private static readonly string[] sr_FeedbackStrArray = new string[k_NumberOfColorChoices];
        private static int s_NumberOfGuesses = k_MinGuesses;
        private static string[] s_ComputerGameColorArray = new string[k_NumberOfColorChoices];
        private static string[] s_UserChosenColorArray = new string[k_NumberOfColorChoices];

        public static string[] FeedbackStrArray
        {
            get
            {
                return sr_FeedbackStrArray;
            }
        }

        public static string[] UserChosenColorArray
        {
            get
            {
                return s_UserChosenColorArray;
            }

            set
            {
                s_UserChosenColorArray = value;
            }
        }

        public static string[] ComputerGameColorArray
        {
            get
            {
                return s_ComputerGameColorArray;
            }
        }

        public static int NumberOfGuesses
        {
            get
            {
                return s_NumberOfGuesses;
            }
        }

        public static string SetNumberOfGuesses()
        {
            if (s_NumberOfGuesses == k_MaxGuesses)
            {
                s_NumberOfGuesses = k_MinGuesses;
            }
            else
            {
                s_NumberOfGuesses += 1;
            }

            string numberOfGuessesStr = $"Number of Chances: {s_NumberOfGuesses}";

            return numberOfGuessesStr;
        }

        public static void RandomComputerColorsSelectionForButtons()
        {
            int randomColorsIndex = 0;
            Array randomColor;
            Random random = new Random();
            string[] randomColors = new string[k_NumberOfColorChoices];
            randomColor = Enum.GetValues(typeof(enumColorsChoices.eColor));
            enumColorsChoices.eColor chosenColor;

            while (randomColorsIndex < 4)
            {
                chosenColor = (enumColorsChoices.eColor)randomColor.GetValue(random.Next(randomColor.Length));

                if (!randomColors.Contains(chosenColor.ToString()))
                {
                    randomColors[randomColorsIndex] = chosenColor.ToString();
                    randomColorsIndex++;
                }
            }

            s_ComputerGameColorArray = randomColors;
        }

        public static void CompareStrColors()
        {
            char[] feedback = new char[k_NumberOfColorChoices];
            int vcount = 0;
            int xcount = 0;

            for (int i = 0; i < k_NumberOfColorChoices; i++)
            {
                for (int j = 0; j < k_NumberOfColorChoices; j++)
                {
                    if (s_ComputerGameColorArray[i] == s_UserChosenColorArray[j])
                    {
                        if (i == j)
                        {
                            vcount++;
                        }
                        else
                        {
                            xcount++;
                        }
                    }
                }
            }

            for (int i = 0; i < k_NumberOfColorChoices; i++)
            {
                if (vcount > 0)
                {
                    sr_FeedbackStrArray[i] = "0";
                    vcount--;
                }
                else if (xcount > 0)
                {
                    sr_FeedbackStrArray[i] = "1";
                    xcount--;
                }
                else
                {
                    sr_FeedbackStrArray[i] = " ";
                }
            }
        }
    }
}