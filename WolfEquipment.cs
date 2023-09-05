using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEquipment : MonoBehaviour
{
    private string weapon;
    private GameObject weaponInit;
    public WolfEquipment()
    {
        this.weapon = string.Empty;
    }
    public  virtual void EquipWeapon(string nWeapon)
    {
        UMI.UMISystem.Log("success weapon");
        this.weapon = nWeapon;
        GameObject weaponObj = WolfEquipment.getWeapon(nWeapon);
        if (weaponObj)
        {
            this.weaponInit = (GameObject)UnityEngine.Object.Instantiate(weaponObj, Vector3.zero, Quaternion.identity);
            this.weaponInit.transform.parent = global::Math.findChildObject(this.gameObject.transform,"Hand.R");
            this.weaponInit.transform.localPosition = new Vector3(0.0016f, 0.0087f , 0.0181f);
            this.weaponInit.transform.localRotation = Quaternion.Euler(181f, -27f, -109f);
            this.weaponInit.transform.localScale = Vector3.one;
            this.weaponInit.name = "Weapon"; 
        }
    }
    public static GameObject getWeapon(string nWeapon)
    {
        GameObject result ;
        switch (nWeapon)
        {
            case "SwordStandard":
                result = (GameObject)Resources.Load("GameAssets/Characters/Heroes/wolf/Weapons/SwordStandard", typeof(GameObject));
                break;
            default:
                result = (GameObject)Resources.Load("GameAssets/Characters/Heroes/wolf/Weapons/SwordStandard", typeof(GameObject));
                break;
        }
        return result; 
    }
}
