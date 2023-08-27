using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Data;
using UMI;
public class CharacterDataClass 
{
    CharacterClass playerData = new CharacterClass();
    public void Init(int slot )
    {
        int num= 0 ;
        switch(slot)
        {
            case 1:
                num = 0; 
                break;
            case 2:
                num = 100;
                break;
            case 3:
                num = 200;
                break;
        }
        try
        {
            if(UMIHashData.hDac.ContainsKey(num+1))
            {
                this.playerData.slot = slot;
                this.playerData.Name = UMIHashData.hDac[num + 1].ToString();
                UMISystem.Log(playerData.Name);
            }else
            {
                UMISystem.Log("Player Slot"+ slot + " None : " );
            }
            
        }
        catch
        {
            UMISystem.Log("[Script]ChracterClass(32)::Data Load fail . . . ");
        }
        }
        
}
