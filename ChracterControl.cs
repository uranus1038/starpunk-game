using UnityEngine;
public enum charType
{
    none ,
    Leo , 
}
public class ChracterControl : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected string ownerGuild;
    [SerializeField] protected string ownerName;
    [SerializeField] protected string myCommand;
    [SerializeField] protected charType Type;
    [SerializeField] protected int str;
    [SerializeField] protected int agi;
    [SerializeField] protected int vit;
    [SerializeField] protected int mag;
    [SerializeField] protected int cha;
    [SerializeField] protected int dex;
    [SerializeField] protected int lck;
    [SerializeField] protected int hp;
    [SerializeField] protected int sp;
    [SerializeField] protected int mp;
    [SerializeField] protected int ko;
    [SerializeField] protected int mhp;
    [SerializeField] protected int msp;
    [SerializeField] protected int mmp;
    [SerializeField] protected int mko;
    [SerializeField] protected int cri;
    [SerializeField] protected int weight;
    [SerializeField] protected float asp;
    [SerializeField][Range(0,15)] protected float runSpeed;
    [SerializeField][Range(0,15)] protected float jumpForce;
    [SerializeField] protected string weapon;
    [SerializeField] protected string armor;
    [SerializeField] protected string headgear;
    [SerializeField] protected string boot;
    [SerializeField] protected string trinket;
    [SerializeField] protected string pet;
    [SerializeField] protected int hitMod;
    [SerializeField] protected int hate; public bool recieveTarget;
    [SerializeField] protected bool recieveDamage;
    [SerializeField] protected bool recieveEffectDamage;
    [SerializeField] protected bool recieveMovement;
    [SerializeField] protected bool recieveForce;
    [SerializeField] protected bool recieveStatus;
    [SerializeField] protected bool recieveHeal;
    [SerializeField] protected bool recieveHate;
    [SerializeField] protected bool recieveRevive;
    [SerializeField] protected bool recieveGravity;

    [SerializeField] protected Vector3 myAttackPosition ;
    public ChracterControl()
    {
        this.Name = "none"; 
        this.ownerGuild = "none";
        this.ownerName = "none";
        this.myCommand = "none";
        this.Type = charType.none;
        this.str = 8;
        this.agi = 8;
        this.vit = 8;
        this.mag = 8;
        this.dex = 8;
        this.cha = 8;
        this.lck = 8;
        this.hp = 8;
        this.sp = 8;
        this.mp = 8;
        this.ko = 8;
        this.mhp = 8;
        this.msp = 8;
        this.mmp = 8;
        this.mko = 8;
        this.cri = 5;
        this.weight = 8;
        this.asp = 5f;
        this.runSpeed = 8f;
        this.jumpForce = 5f;
        this.weapon = "none";
        this.armor = "none";
        this.headgear = "none";
        this.boot = "none";
        this.trinket = "none";
        this.pet = "none";
        this.hitMod = 1;
        this.hate = 1;
        this.myAttackPosition = Vector3.zero;
        this.recieveTarget = false;
        this.recieveDamage = false;
        this.recieveEffectDamage = false;
        this.recieveMovement = false;
        this.recieveForce = false;
        this.recieveStatus = false;
        this.recieveHeal = false;
        this.recieveHate = false;
        this.recieveRevive = false;
        this.recieveGravity = false;
    }
    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnGUI()
    {

    }
    public void hit(int a , int b)
    {
        this.lck = a + b;
    }
}
