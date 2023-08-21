using UnityEngine; 
public class Game 
{
    public static bool isConsole  ;
    public static void loadNextLevel(int mNextGameCode)
    {
        switch (mNextGameCode)
        {
            case 0:
                Application.LoadLevel("Demo");
                break; 
        }

    }
}
