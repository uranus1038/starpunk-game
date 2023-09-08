using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Data;
using UMI;
public class CharacterDataClass 
{
    private CharacterClass data = new CharacterClass();
    private string[] types = new string[]
    {
        "none" , 
        "Leo" 
    };
    public string[] getTypes()
    {
        return types; 
    }
    public void Init(int slot )
    {
        int jumpForce = 0;
        this.data.slot = slot; 
        this.data.UID = -1;
        this.data.Guild = "none";
        this.data.myCommand = "member";
        this.data.stat  = this.getStat();
        this.data.bStat = this.getBonusStat();
        this.data.bonus = this.getBonusStat();
        this.data.rank = 1;
        this.data.gold = 0;
        this.data.star = 0;
        this.data.rp = 0;
        this.data.mrp = 0;
        this.data.roleGuild = 1;
        this.data.lv = 1;
        this.data.exp = 1;
        this.data.nexp = 24;
        this.data.runspeed = this.getMove((int)this.data.type, out jumpForce);
        this.data.jumpForce = jumpForce; 
    }
    public void setCdat(CharacterClass mChar , SkillClass aSkill)
    {
        int jumpForce = 0;
        this.data.type = mChar.type; 
        this.data.slot = mChar.slot;
        this.data.UID = mChar.UID;
        this.data.Guild = mChar.Guild;
        this.data.myCommand = mChar.myCommand;
        this.data.stat = this.getStat(mChar);
        this.data.bStat = this.getBonusStat();
        this.data.bonus = this.getBonusStat();
        this.data.rank = mChar.rank;
        this.data.gold = mChar.gold;
        this.data.star = mChar.star;
        this.data.rp = mChar.rp;
        this.data.mrp = mChar.mrp;
        this.data.roleGuild = mChar.roleGuild;
        this.data.lv = mChar.lv;
        this.data.exp = mChar.exp;
        this.data.nexp = mChar.nexp;
        this.data.runspeed = this.getMove((int)this.data.type, out jumpForce);
        this.data.jumpForce = jumpForce;
        this.data.skill = aSkill.num;
    }
    private int[] getStat()
    {
        int[] stat;
        return stat = new int[] {
            this.data.str = 1 , 
            this.data.agi = 1 , 
            this.data.vit = 1 , 
            this.data.mag = 1 , 
            this.data.cha = 1 , 
            this.data.dex = 1 , 
            this.data.lck = 1 
        };
    }
    private int[] getStat(CharacterClass mChar)
    {
        int[] stat;
        return stat = new int[] {
            this.data.str = mChar.star ,
            this.data.agi = mChar.agi ,
            this.data.vit = mChar.vit ,
            this.data.mag = mChar.mag ,
            this.data.cha = mChar.cha ,
            this.data.dex = mChar.dex ,
            this.data.lck = mChar.lck
        };
    }
    private int[] getBonusStat()
    {
        int[] stat;
        return stat = new int[] {
            
        };
    }
    private int[] getBStat()
    {
        int[] stat;
        return stat = new int[] {
        };
    }
    private int getMove(int type , out int jumpForce)
    {
        int move = 0;
        switch (this.data.type)
        {
            case charType.Wolf:
                move = 3;
                jumpForce = 5;
                break;
            default:
                move = 1;
                jumpForce = 1;
                break;
        }

        return move ;
    }
    public  void addType(int slot)
    {

    } 
    public int getUID()
    {
        return this.data.UID; 
    }
    public int getSlot()
    {
        return this.data.slot;
    }
    public  string addType()
    {
        string result = string.Empty;
        switch (this.data.type)
        {
            case charType.Wolf:
                result = "Wolf";
                break;
        }
        return result;
    }
    public void ReadDataPlayer(int slot)
    {

    }
        
}
