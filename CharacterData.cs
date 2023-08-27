using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI; 
public class CharacterData : MonoBehaviour
{
    public static CharacterData star; 
    public static CharacterDataClass currentDac;
    public static CharacterDataClass cDac1;
    public static CharacterDataClass cDac2;
    public static CharacterDataClass cDac3;
    public void Awake()
    {
        star = this; 
        currentDac = new CharacterDataClass();
        cDac1 = new CharacterDataClass();
        cDac2 = new CharacterDataClass();
        cDac3 = new CharacterDataClass();
    }
    public static void Init()
    {
        UMISystem.Log("Character Data Initialized");
        CharacterData.cDac1.Init(1);
        CharacterData.cDac1.Init(2);
        CharacterData.cDac1.Init(3);
    }

}
