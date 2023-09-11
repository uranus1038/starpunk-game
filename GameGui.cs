using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGui : MonoBehaviour
{
    private eSkillState eSkill;
    private float display_0;
    private float display_1;
    private float[] x;
    private float y;
    private int Divide;
    private bool isGame;
    private bool isTrue;
    private bool isTexture;
    private IconClass Icon;
    private HoverClass hover_0;
    private Texture2D texture_0;
    private Texture2D texture_1;
    private Texture2D texture_2;
    private Texture2D texture_3;
    private Texture2D texture_4;
    private Texture2D texture_5;
    private Texture2D texture_6;
    private Texture2D texture_7;
    private Texture2D texture_8;
    private Texture2D texture_9;
    private Texture2D texture_10;

    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private GUIStyle style_4;
    private GUIStyle style_5;
    private GUIStyle style_6;
    private GUIStyle style_7;
    private GUIStyle style_8;
    private GUIStyle style_9;
    private GUIStyle style_10;
    private GUIStyle style_11;
    private GUIStyle style_12;
    private GUIStyle style_13;
    private GUIStyle style_14;
    private GUIStyle style_15;
    private GUIStyle style_16;
    private GUIStyle style_17;
    private void Init()
    {
        this.x = new float[] { 0, 422f, 342f, 262f, 182f };
        this.y = 118f;
        this.eSkill = eSkillState.Basic; 
        this.Divide = 0; 
        this.hover_0 = new HoverClass();
        this.Icon = new IconClass();
        this.Icon.image = (Texture2D)Resources.Load("GUI/Icon/null", typeof(Texture2D));
        this.isGame = true;
        this.InitChracterOption();
        this.InitStatusbar();
        this.InitWorldMap();
        this.InitSkillBar();
        this.InitNetworkBar();
        this.InitInventory();
        this.style_10 = new GUIStyle();
        this.style_10.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonClose_h", typeof(Texture2D));
        this.style_11 = new GUIStyle();
        this.style_11.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonClose1_h", typeof(Texture2D));
        this.style_12 = new GUIStyle();
        this.style_12.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonClose2_h", typeof(Texture2D));
    }
    private void InitChracterOption()
    {
        this.texture_0 = (Texture2D)Resources.Load("GUI/Game/CharacterBg", typeof(Texture2D));
        this.texture_1 = (Texture2D)Resources.Load("GUI/Game/useBar", typeof(Texture2D));
        this.texture_2 = (Texture2D)Resources.Load("GUI/Game/HPMPSPMX", typeof(Texture2D));
        this.texture_3 = (Texture2D)Resources.Load("GUI/Game/HPMPSPTX", typeof(Texture2D));
        // ######
        this.texture_4 = (Texture2D)Resources.Load("GUI/Characters/Wolf", typeof(Texture2D));
        this.style_0 = new GUIStyle(); 
        this.style_0.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonInventoryIcon_h", typeof(Texture2D));  
        this.style_1 = new GUIStyle(); 
        this.style_1.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonStatusIcon_h", typeof(Texture2D));
        this.style_2 = new GUIStyle();
        this.style_2.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonSkillIcon_h", typeof(Texture2D));
        this.style_3 = new GUIStyle();
        this.style_3.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonNetworkIcon_h", typeof(Texture2D));
    }
    private void InitSkillBar()
    {
        this.texture_7 = (Texture2D)Resources.Load("GUI/SkillCharacter/SkillBar", typeof(Texture2D));

        this.style_4 = new GUIStyle();
        this.style_4.hover.background = (Texture2D)Resources.Load("GUI/Game/AButton_h", typeof(Texture2D));

        this.style_5 = new GUIStyle();
        this.style_5.hover.background = (Texture2D)Resources.Load("GUI/Game/BButton_h", typeof(Texture2D));

        this.style_6 = new GUIStyle();
        this.style_6.hover.background = (Texture2D)Resources.Load("GUI/Game/BasicButton_h", typeof(Texture2D));

    }
    private void InitStatusbar()
    {
        this.texture_6 = (Texture2D)Resources.Load("GUI/Game/StatusBar", typeof(Texture2D));
    }
    private void InitWorldMap()
    {
        this.texture_5 = (Texture2D)Resources.Load("GUI/Game/MiniMap", typeof(Texture2D));
    }
    private void InitNetworkBar()
    {
        this.texture_8 = (Texture2D)Resources.Load("GUI/Game/NetworkBar", typeof(Texture2D));
        this.style_13 = new GUIStyle();
        this.style_13.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonLeft_h", typeof(Texture2D));
        this.style_14 = new GUIStyle();
        this.style_14.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonRight_h", typeof(Texture2D));
        this.style_15 = new GUIStyle();
        this.style_15.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonTrash1_h", typeof(Texture2D));
        this.style_16 = new GUIStyle();
        this.style_16.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonGuild_h", typeof(Texture2D));
        this.style_17 = new GUIStyle();
        this.style_17.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonFriends_h", typeof(Texture2D));
    }

    private void InitInventory()
    {
        this.texture_9 = (Texture2D)Resources.Load("GUI/Game/InventoryBar", typeof(Texture2D));
        this.texture_10 = (Texture2D)Resources.Load("GUI/Game/UranusBg01", typeof(Texture2D));
        this.style_7 = new GUIStyle();
        this.style_7.hover.background = (Texture2D)Resources.Load("GUI/Game/ButtonTrash_h", typeof(Texture2D));
        this.style_8 = new GUIStyle();
        this.style_8.hover.background = (Texture2D)Resources.Load("GUI/Game/TroggleCopy2_h", typeof(Texture2D));
        this.style_9 = new GUIStyle();
        this.style_9.hover.background = (Texture2D)Resources.Load("GUI/Game/TroggleCopy1_h", typeof(Texture2D));
    }
    void Start()
    {

    }
    private void Awake()
    {
        this.Init();
    }
    private void Update()
    {
       
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        this.display_1 = (float)Screen.height / 1024f;
        if(this.isGame)
        {
            this.RenderNetWorkBar();
            this.RenderChracterUse();
            this.RenderStatusBar();
            this.RenderSkillBar();
            this.RenderInventory();
        }
    }
    private void RenderChracterUse()
    {
        // # character bar
        GUI.DrawTexture(new Rect(0f, this.display_1 + 799, 445, 225f), this.texture_0);
        // # Item bar
        GUI.DrawTexture(new Rect(1f * this.display_0 - 1167f, this.display_1 + 844f, 1168f, 180f), this.texture_1);
        
        this.GUIControl(); 
        // # HPMPSP bar
        GUI.DrawTexture(new Rect(155f, this.display_1 + 928f, 230f, 90f), this.texture_2);
        // # Character
        GUI.DrawTexture(new Rect(0f, this.display_1 + 680f, 300f, 380f), this.texture_4);
        // #HPMPSPTX text
        GUI.DrawTexture(new Rect(155f, this.display_1 + 928, 230f, 90f), this.texture_3);
        // # MiniMap
        GUI.DrawTexture(new Rect(0, 0, 360f, 250f), this.texture_5);
    }
    private void RenderInventory()
    {
        if(Game.eInventory == eInventory.Active)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 505f, this.display_1 + 482f, 450f, 410f), this.texture_9);
            // trash
            if(GUI.Button(new Rect(1f * this.display_0 - 110f, this.display_1 + 744f, 33f, 38f), string.Empty,this.style_7))
            {

            }
            // coppy2
            if (GUI.Button(new Rect(1f * this.display_0 - 115f, this.display_1 + 680f, 40f, 40f), string.Empty, this.style_8))
            {

            }
            // coppy1
            if (GUI.Button(new Rect(1f * this.display_0 - 115f, this.display_1 + 620f, 40f, 40f), string.Empty, this.style_9))
            {

            }
            // close
            if (GUI.Button(new Rect(1f * this.display_0 - 109f, this.display_1 + 504f, 40f, 40f), string.Empty, this.style_10))
            {
                Game.eInventory = eInventory.none;
            }
            //bg uranus
            GUI.DrawTexture(new Rect(1f * this.display_0 - 445f, this.display_1 + 601f, 349f, 193f), this.texture_10);
        }
    }   
    private void RenderStatusBar()
    {
        if(Game.eMenu == eMenuOptionState.Status)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 505f, this.display_1 + 18f, 450f, 450f), this.texture_6);
            if (GUI.Button(new Rect(1f * this.display_0 - 108f, this.display_1 + 30f, 30f, 30f), string.Empty, this.style_11))
            {
                Game.eMenu = eMenuOptionState.none;
            }
        }
    }
    private void RenderSkillBar()
    {
        if (Game.eMenu == eMenuOptionState.Skill)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 505f, this.display_1 + 78f, 450f, 820f), this.texture_7);
            if (GUI.Button(new Rect(1f * this.display_0 - 357f, this.display_1 + 121f, 81f, 35f), string.Empty, this.style_5))
            {
                this.eSkill = eSkillState.B;
            }
            if (GUI.Button(new Rect(1f * this.display_0 - 413f, this.display_1 + 121f, 81f, 35f), string.Empty, this.style_4))
            {
                this.eSkill = eSkillState.A;
            }
            if (GUI.Button(new Rect(1f * this.display_0 - 480f, this.display_1 + 121f, 81f, 35f),string.Empty ,this.style_6))
            {
                this.eSkill = eSkillState.Basic;
            }
            if (GUI.Button(new Rect(1f * this.display_0 - 125f, this.display_1 + 112f, 40f, 40f), string.Empty, this.style_10))
            {
                Game.eMenu = eMenuOptionState.none;
            }

            if(this.eSkill.Equals(eSkillState.Basic))
            {
                SkillClass skillClass = new SkillClass();
                skillClass.rows = 8;
                skillClass.num = new int[] { 0,2, 3, 2, 4 ,3,3,4,2};
                int slot=1;
                for(skillClass.index=1; skillClass.index <= skillClass.rows; skillClass.index++)
                {
                    skillClass.columns = 1;
                    for (skillClass.columns = 1; skillClass.columns <= skillClass.num[skillClass.index]; skillClass.columns++)
                    {
                        GUI.DrawTexture(new Rect(1f*this.display_0-x[skillClass.columns],
                            this.display_1+y+ global::Math.div(skillClass.index,78f),
                            64,64),
                            (Texture2D)Resources.Load("GUI/Icon/null", typeof(Texture2D)));
                        slot++;
                    }
                    UMI.UMISystem.Log(skillClass.index);
                }
            }
            if (this.eSkill.Equals(eSkillState.A))
            {
                SkillClass skillClass = new SkillClass();
                skillClass.rows = 8;
                skillClass.num = new int[] { 0, 4, 4, 4, 4, 3, 3, 4, 2 };
                int slot = 1;
                for (skillClass.index = 1; skillClass.index <= skillClass.rows; skillClass.index++)
                {
                    skillClass.columns = 1;
                    for (skillClass.columns = 1; skillClass.columns <= skillClass.num[skillClass.index]; skillClass.columns++)
                    {
                        GUI.DrawTexture(new Rect(1f * this.display_0 - x[skillClass.columns],
                            this.display_1 + y + global::Math.div(skillClass.index, 78f),
                            64, 64),
                            (Texture2D)Resources.Load("GUI/Icon/null", typeof(Texture2D)));
                        slot++;
                    }
                    UMI.UMISystem.Log(skillClass.index);
                }
            }
        }
    }
    private void RenderNetWorkBar()
    {
        if (Game.eMenu == eMenuOptionState.Network)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 415f, this.display_1 + 420f, 420f, 605f), this.texture_8);
            // Close
            if (GUI.Button(new Rect(1f * this.display_0 - 52f, this.display_1 + 435f, 30f, 30f), string.Empty, this.style_11))
            {
                Game.eMenu = eMenuOptionState.none;
            }
            // troggle Left
            if (GUI.Button(new Rect(1f * this.display_0 - 376f, this.display_1 + 909f, 22f, 25f), string.Empty, this.style_13))
            {
               
            }
            // troggle Right
            if (GUI.Button(new Rect(1f * this.display_0 - 311f, this.display_1 + 909f, 22f, 25f), string.Empty, this.style_14))
            {
               
            }
            // trash 
            if (GUI.Button(new Rect(1f * this.display_0 - 211f, this.display_1 + 905f, 30f, 34f), string.Empty, this.style_15))
            {

            }
            // Guild Network
            if (GUI.Button(new Rect(1f * this.display_0 - 258f, this.display_1 + 442f, 101f, 48f), string.Empty, this.style_16))
            {

            }
            // Friends Network
            if (GUI.Button(new Rect(1f * this.display_0 - 360f, this.display_1 + 442f, 101f, 48f), string.Empty, this.style_17))
            {

            }
        }
    }
    private void GUIControl()
    {
        // # h Inventory
        if (GUI.Button(new Rect(1f * this.display_0 - 144f, this.display_1 + 905f, 60f, 50f), string.Empty, this.style_0))
        {
            if (Game.eInventory != eInventory.Active)
            {
                Game.eInventory = eInventory.Active;
                Game.eMenu = eMenuOptionState.Status;
            }
            else
            {
                Game.eInventory = eInventory.none;
            }
        }
        // # h status
        if (GUI.Button(new Rect(1f * this.display_0 - 67f, this.display_1 + 905f, 60f, 50f), string.Empty, this.style_1))
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
        // # h skill
        if (GUI.Button(new Rect(1f * this.display_0 - 144f, this.display_1 + 962f, 60f, 50f), string.Empty, this.style_2))
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
        // # h network
        if (GUI.Button(new Rect(1f * this.display_0 - 67f, this.display_1 + 962f, 60f, 50f), string.Empty, this.style_3))
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
    private void RenderTest()
    {
        //Rect keyCodeNumber = new Rect(1f * this.display_0 - 1167f, this.display_1 + 844f, 1168f, 180f);
        //GUI.BeginGroup(keyCodeNumber);
        //GUILayout.BeginHorizontal();
        //GUILayout.BeginArea(new Rect(0, 0, 100, keyCodeNumber.height));
        //GUILayout.Button("Button 1");
        //GUILayout.EndArea();
        //GUILayout.EndHorizontal();
        //GUI.EndGroup();
    }
    
}
