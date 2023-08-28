using UnityEngine; 
public class Game 
{
    public static bool isConsole  ;
    public static bool isLoadDac  ; 
    public static void loadNextLevel(int mNextGameCode)
    {
        switch (mNextGameCode)
        {
            case 0:
                Application.LoadLevel("Demo");
                break;
            case 1:
                Application.LoadLevel("Login");
                break;
            case 2:
                Application.LoadLevel("A01_LobbyGame");
                break;
        }

    }
}
