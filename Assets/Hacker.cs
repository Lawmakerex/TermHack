using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Hacker : MonoBehaviour
{
    //Game Configs
    string[] level1Pass = { "Ranma", "One Piece", "Dragonball", "Naruto", "Inuyasha", "HunterXHunter", "Pokemon", };
    string[] level2Pass = {"Jolteon","Flareon", "Vaporeon", "Umbreon", "Espeon", "Glaceon", "Leafeon", };
    string[] level3Pass = {"Mars","Venus", "Earth", "Mercury", "Jupiter", "Neptune", "Saturn","Uranus" };
    
    //Game State
    int level;
    string password;
    int counter = 3;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        
        ShowMainMenu("Hello Hacker");
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Were would you like to hack");
        Terminal.WriteLine("Press 1 For Manga Store");
        Terminal.WriteLine("Press 2 For Eeveelution shop");
        Terminal.WriteLine("Press 3 For NASA Solar Readings");
        Terminal.WriteLine("Type Menu to return to main menu");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Hello again Hacker");
            counter = 3;
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);

        }
    }


    void RunMainMenu(string input)
    {
       
            if (input == "1")
            {
                level = 1;
            password = level1Pass[Random.Range(0, level1Pass.Length)];
            AskForPassword(" ");
            }
            else if (input == "2")
            {
                level = 2;
                password = level2Pass[Random.Range(0, level2Pass.Length)];
            AskForPassword(" ");
            }
            else if (input == "3")
            {
                level = 3;
                password = level3Pass[Random.Range(0, level3Pass.Length)];
            AskForPassword(" ");
            }
            else
            {
                Terminal.WriteLine("wrong input choice");
                Terminal.WriteLine("You can type menu anytime");


        }


        
    }

    void CheckPassword(string input)
    {
        if (counter > 1)
        {
            if (level == 1 && input == password)
            {
                Terminal.WriteLine("Hello fellow Otaku");
                DisplayWinscreen();
            }
            else if (level == 1 && input != password)
            {
                Terminal.ClearScreen();
                counter--;
               
                AskForPassword("Wrong passowrd");
                

            }
            else if (level == 2 && input == password)
            {
                Terminal.WriteLine("Hello fellow master");
                DisplayWinscreen();
            }
            else if (level == 2 && input != password)
            {
                Terminal.ClearScreen();
                counter--;
        
                AskForPassword("Wrong passowrd");
                
            }
            else if (level == 3 && input == password)
            {
                Terminal.WriteLine("Hello fellow astrophysisist");
                DisplayWinscreen();
            }
            else if (level == 3 && input != password)
            {
                Terminal.ClearScreen();
                counter--;
                
                AskForPassword("Wrong passowrd");
                
            }
            else
            {

                Terminal.WriteLine("You can type menu anytime");
                AskForPassword("");
            }
        }
        else
        {

            

            counter = 3;
            Terminal.WriteLine("Failed To Decrypt Passowrd...");
            
            Terminal.WriteLine("System will now Terminate!");
            ShowMainMenu("Hello Hacker");




        }

    }


    void DisplayWinscreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        ShowLevelReward();
        Terminal.WriteLine("You can type menu anytime");
    }

    void DisplayLosescreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        ShowLevelReward();
        Terminal.WriteLine("You can type menu anytime");
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You really know your mangas!!");
                Terminal.WriteLine(@"
             .---|__| .((\=.
          .--|===|--|/    ,(,
          |  |===|  |\      y
          |%%| M |  | `.__,'
          |%%| A |  | /  \\\
          |  | N |  |/|  | \`----.
          |  | G |  ||\  \  |___.'_
         _|  | A |__||,\  \-+-._.' )_
");
                break;
            case 2:
                Terminal.WriteLine("Welcome Pokemon Master!!");
                Terminal.WriteLine(@"
         \  \ .---. .-' /
          '. '     `\_.'
            |(),()  |     ,
            (  __   /   .' \
           .''.___.'--,/\_,|
          {  /     \   }   |
           '.\     /_.'    /
            |'-.-',  `; _.'
            |  |  |   |`
");
                break;
            case 3:
                Terminal.WriteLine("Get ready to Travel the Stars!!");
                Terminal.WriteLine(@"
        _____
    ,-:` \;',`'-, 
  .'-;_,;  ':-;_,'.
 /;   '/    ,  _`.-\
| '`. (`     /` ` \`|
|:.  `\`-.   \_   / |
|     (   `,  .`\ ;'|
 \     | .'     `-'/
  `.   ;/        .'
     `'-. _____.
");
                break;


        }
    }

    void AskForPassword(string message)
    {
       
        Terminal.WriteLine(message);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter Your Passowrd, Hint: " + password.Anagram());
        Terminal.WriteLine("You can type menu anytime");
        Terminal.WriteLine("Tries Left: " + counter);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Pass[Random.Range(0, level1Pass.Length)];
                break;
            case 2:
                password = level2Pass[Random.Range(0, level2Pass.Length)];
                break;
            case 3:
                password = level3Pass[Random.Range(0, level3Pass.Length)];
                break;
        }
        

    }
}
