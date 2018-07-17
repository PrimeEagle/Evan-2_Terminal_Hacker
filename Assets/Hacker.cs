
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest", };

    //Game State
    int level;
    enum Screen { MainMenu, PasswordMenu, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
        


    }
    void Update()
    {
        int index1 = Random.Range(0, level1Passwords.Length);
        print(index1);
        int index2 = Random.Range(0, level2Passwords.Length);
        print(index2);
    }

    void ShowMainMenu()
    {
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Enter your selection:");

    }

    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();

        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.PasswordMenu)
        {
            CheckPassword(input);
        }
     
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello Mr. bond");
        }
        else
        {
            Terminal.WriteLine("Invalid input please try again");
        }
    }



    void StartGame()
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        currentScreen = Screen.PasswordMenu;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password,hint:" + password.Anagram());
    }
    void CheckPassword(string input)
        {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect!");
            ShowMainMenu();
        }

        }
         void DisplayWinScreen()
        {

        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        }
        void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine("press menu to restart.");
                break;
            case 2:
                Terminal.WriteLine("you got the prison key");
                Terminal.WriteLine("press menu to restart.");
                    break;
        }
    }
    }


