using UnityEngine;
public enum charType
{
    none ,
    Wolf , 
}
public class CharacterControl : MonoBehaviour
{
    [SerializeField] protected int UID;
    [SerializeField] protected int CID;
    [SerializeField] protected string Name;
    [SerializeField] protected string ownerGuild;
    [SerializeField] protected string ownerName;
    [SerializeField] protected string myCommand;
    [SerializeField] protected charType type;
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
    [SerializeField] protected float aspd;
    [SerializeField][Range(0,15)] protected float runSpeed;
    [SerializeField][Range(0,15)] protected float jumpForce;
    [SerializeField] protected string weapon;
    [SerializeField] protected string armor;
    [SerializeField] protected string head;
    [SerializeField] protected string boot;
    [SerializeField] protected string trinket;
    [SerializeField] protected string pet;
    [SerializeField] protected int hitMod;
    [SerializeField] protected int hate;
    [SerializeField] protected bool recieveTarget;
    [SerializeField] protected bool recieveDamage;
    [SerializeField] protected bool recieveEffectDamage;
    [SerializeField] protected bool recieveMovement;
    [SerializeField] protected bool recieveForce;
    [SerializeField] protected bool recieveStatus;
    [SerializeField] protected bool recieveHeal;
    [SerializeField] protected bool recieveHate;
    [SerializeField] protected bool recieveRevive;
    [SerializeField] protected bool recieveGravity;
    [SerializeField] protected bool isMine;
    [SerializeField] protected bool isActor;
    [SerializeField] protected bool isMove;
    [SerializeField] protected string skin;
    [SerializeField] protected string overlay;

    public float display_0 ;
    public float display_1 ;
    public Texture texture_0;

    [SerializeField] protected Vector3 myAttackPosition ;
    public CharacterControl()
    {
        this.Name = "none"; 
        this.ownerGuild = "none";
        this.ownerName = "none";
        this.myCommand = "none";
        this.type = charType.none;
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
        this.aspd = 5f;
        this.runSpeed = 8f;
        this.jumpForce = 5f;
        this.weapon = "none";
        this.armor = "none";
        this.head = "none";
        this.boot = "none";
        this.trinket = "none";
        this.pet = "none";
        this.hitMod = 1;
        this.hate = 1;
        this.skin = "standard";
        this.overlay = "standard";
        this.hate = 1;
        this.myAttackPosition = Vector3.zero;
        Game.eMenu = eMenuOptionState.Game; 
    }
    private void Init()
    {
    }
    private void Awake()
    {
        this.Init();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void hit(int a , int b)
    {
        this.lck = a + b;
    }
    protected virtual void GameControl()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (Game.eInventory != eInventory.Active)
            {
                
                Game.eInventory = eInventory.Active;
                if (Game.eMenu != eMenuOptionState.Status)
                {
                    Game.eMenu = eMenuOptionState.Game;
                }
            }
            else
            {
                Game.eInventory = eInventory.none;
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (Game.eMenu != eMenuOptionState.Status)
            {
                Game.eMenu = eMenuOptionState.Status;
            }
            else
            {
                Game.eMenu = eMenuOptionState.Game;
            }
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (Game.eMenu != eMenuOptionState.Skill)
            {
                Game.eMenu = eMenuOptionState.Skill;
                Game.eInventory = eInventory.none;
            }
            else
            {
                Game.eMenu = eMenuOptionState.Game;
            }
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (Game.eMenu != eMenuOptionState.Network)
            {
                Game.eMenu = eMenuOptionState.Network;
                Game.eInventory = eInventory.none;
            }
            else
            {
                Game.eMenu = eMenuOptionState.Game;
            }
        }
    }
    protected virtual void PlayerRotation(GameObject mCam)
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) )
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y, 0f);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y - 180f, 0f);

        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y + 90f, 0f);

        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) )
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y - 90f, 0f);

        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y + 45f, 0f);

        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y - 45f, 0f);


        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y + 135f, 0f);

        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, mCam.transform.eulerAngles.y - 135f, 0f);

        }
    }
}
