// See https://aka.ms/new-console-template for more information

GameSystem game = new GameSystem();
game.DisplayNumpad();
while (game.IsRunning)
{
    game.AskForChoice();
    game.MakeChoice(game.CurrentChoice);
    game.CheckWinCon();
}

class Player
{

}

public class GameSystem
{
    List<int> player1Choices = new List<int>();
    List<int> player2Choices = new List<int>();
    readonly List<string> numList = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    string[] resultString = new string[10];
    PlayerTurn turn = PlayerTurn.Player1;
    public int CurrentChoice;
    public bool IsRunning = true;

    public void AskForChoice()
    {
        Console.WriteLine($"\n\nIt is {turn}'s turn. Please enter a choice, based on your numpad. An example is shown at the start of the program.");
        string input = Console.ReadLine();
        Console.WriteLine($"You have chosen {input}.");

        if (!numList.Contains(input) || input == "")
        {
            Console.WriteLine("Error! Please enter a number from 1 to 9!");
            AskForChoice();
        }
        else
        {
            CurrentChoice = Int32.Parse(input);
        }
        
    }
    public void MakeChoice(int choice)
    {
        if (CheckChoiceValidity(choice))
        {
            LockInChoice(choice);
            DisplayResult();
        }
        else
        {
            DisplayChoiceError();
        }
    }

    bool CheckChoiceValidity(int choice)
    {
        if (player1Choices.Contains(choice) || player2Choices.Contains(choice))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void LockInChoice(int choice)
    {
        if (turn == PlayerTurn.Player1)
        {
            player1Choices.Add(choice);
            turn = PlayerTurn.Player2;
        }
        else
        {
            player2Choices.Add(choice);
            turn = PlayerTurn.Player1;
        }
    }
    public void DisplayNumpad()
    {
        Console.WriteLine($" {numList[6]} | {numList[7]} | {numList[8]}\n---+---+---\n {numList[3]} | {numList[4]} | {numList[5]}\n---+---+---\n {numList[0]} | {numList[1]} | {numList[2]}");
    }
    void DisplayChoiceError()
    {
        Console.WriteLine("Error! The spot you have chosen has already been marked. \nPlease make another choice.");
    }

    void DisplayResult()
    {
        for (int i = 0; i < resultString.Length; i++)
        {
            if (player1Choices.Contains(i))
            {
                resultString[i-1] = "X";
            }
            else if (player2Choices.Contains(i))
            {
                resultString[i-1] = "O";
            }
        }

        for (int i = 0; i < resultString.Length; i++)
        {
            if (resultString[i] == null)
                resultString[i] = " ";
        }

        Console.WriteLine("Player1 symbol: X, Player2 symbol: O");
        Console.WriteLine($" {resultString[6]} | {resultString[7]} | {resultString[8]}\n---+---+---\n {resultString[3]} | {resultString[4]} | {resultString[5]}\n---+---+---\n {resultString[0]} | {resultString[1]} | {resultString[2]}");
    }

    void DisplayerPlayer1Win()
    {
        Console.WriteLine("\nPlayer1 wins!");
        IsRunning = false;
        Console.ReadLine();
    }
    void DisplayerPlayer2Win()
    {
        Console.WriteLine("\nPlayer2 wins!");
        IsRunning = false;
        Console.ReadLine();
    }

    public void CheckWinCon()
    {
        if (resultString[0] == "X" && resultString[1] == "X" && resultString[2] == "X")
        {
            DisplayerPlayer1Win();
        }
        else if (resultString[0] == "X" && resultString[4] == "X" && resultString[8] == "X")
        {
            DisplayerPlayer1Win();
        }
        else if (resultString[0] == "X" && resultString[3] == "X" && resultString[6] == "X")
        {
            DisplayerPlayer1Win();
        }
        else if (resultString[3] == "X" && resultString[4] == "X" && resultString[5] == "X")
        {
            DisplayerPlayer1Win();
        }
        else if (resultString[6] == "X" && resultString[7] == "X" && resultString[8] == "X")
        {
            DisplayerPlayer1Win();
        }
        else if (resultString[6] == "X" && resultString[4] == "X" && resultString[2] == "X")
        {
            DisplayerPlayer1Win();
        }


        else if (resultString[0] == "O" && resultString[1] == "O" && resultString[2] == "O")
        {
            DisplayerPlayer2Win();
        }
        else if (resultString[0] == "O" && resultString[4] == "O" && resultString[8] == "O")
        {
            DisplayerPlayer2Win();
        }
        else if (resultString[0] == "O" && resultString[3] == "O" && resultString[6] == "O")
        {
            DisplayerPlayer2Win();
        }
        else if (resultString[3] == "O" && resultString[4] == "O" && resultString[5] == "O")
        {
            DisplayerPlayer2Win();
        }
        else if (resultString[6] == "O" && resultString[7] == "O" && resultString[8] == "O")
        {
            DisplayerPlayer2Win();
        }
        else if (resultString[6] == "O" && resultString[4] == "O" && resultString[2] == "O")
        {
            DisplayerPlayer2Win();
        }

        CheckDrawCon();
    }

    void CheckDrawCon()
    {
        int counter = 0;
        foreach(string s in resultString)
        {
            if (s == " ")
            {
                counter++;
            }
        }

        if (counter == 1)
        {
            Console.WriteLine("\nTie!");
            IsRunning = false;
            Console.ReadLine();
        }
    }

    enum PlayerTurn { Player1, Player2 }
}