using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI; 
public class CharacterData : MonoBehaviour
{
    public static CharacterDataClass currentDat = new CharacterDataClass();
    public static CharacterDataClass cDat1 = new CharacterDataClass();
    public static CharacterDataClass cDat2 = new CharacterDataClass();
    public static CharacterDataClass cDat3 = new CharacterDataClass();
    public static void Init()
    {
        UMISystem.Log("Character Data Initialized");
        CharacterData.cDat1.Init(1);
        CharacterData.cDat2.Init(2);
    }
    public static CharacterDataClass getCdat(int slot)
    {
        CharacterDataClass CharacterDataClass = null; 
        switch(slot)
        {
            case 1:
                CharacterDataClass = cDat1;
                break;
            case 2:
                CharacterDataClass = cDat2;
                break;

            case 3:
                CharacterDataClass = cDat3;
                break;
            default:
                 CharacterDataClass = null;
                break;
        }
        return CharacterDataClass; 
    }
    public static void createNewCharacterData()
    {

    }

}
