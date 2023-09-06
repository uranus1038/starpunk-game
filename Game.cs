using UnityEngine; 
public class Game 
{
    public static string request = "{\"cDat1\":[{\"type\":1,\"UID\":-1}],\"cDat2\":[{\"type\":1,\"UID\":1}]}";
    public static bool isConsole  ;
    public static bool isLoadDac  ;
    public static eMenuOptionState eMenu = eMenuOptionState.none; 
    public static eInventory eInventory = eInventory.none; 
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
