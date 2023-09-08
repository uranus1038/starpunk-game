using UnityEngine;
using UMI.API;
using UMI.Data;
using UMI;
using UMI.JSON;
using UMI.Network.Client;
public class LoginGui : MonoBehaviour
{
    internal protected static UMIJSON JSON = new UMIJSON();
    internal protected float delay_0;
    internal protected float display_0;
    internal protected float speddPlay_0 = 0.3f;
    internal protected string email_0;
    internal protected string QUk8sYq_x;
    internal protected eLogin eLogin;
    private Texture2D texture_0; // bg_black
    private Texture2D texture_1; // bg_loginBar
    private Texture2D texture_2; // bg_loginBar
    private Texture2D texture_3; // bg_loginBar
    private Texture2D texture_4; // bg_loginBar
    private Texture2D texture_5; // bg_loginBar
    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private GUIStyle style_4;
    private GUIStyle style_5;
    private GUIStyle style_6;
    private GUIStyle style_7;
    private LoadingGui Loading;
    private void Awake()
    {
        this.QUk8sYq_x = string.Empty;
        this.Init();
        this.Loading = (LoadingGui)this.GetComponent(typeof(LoadingGui));
    }

    private void Start()
    {
        this.email_0 = "ex@gmail.com";
        Application.targetFrameRate = 80;
        Application.runInBackground = true;
        Application.backgroundLoadingPriority = ThreadPriority.High;
    }
    private void Init()
    {
        this.texture_0 = (Texture2D)Resources.Load("GUI/Login/black", typeof(Texture2D));
        this.texture_1 = (Texture2D)Resources.Load("GUI/Login/LoginBar", typeof(Texture2D));
        this.texture_2 = (Texture2D)Resources.Load("GUI/Login/CheckMark", typeof(Texture2D));
        this.texture_3 = (Texture2D)Resources.Load("GUI/Login/ServerSelectBar", typeof(Texture2D));
        this.texture_4 = (Texture2D)Resources.Load("GUI/Login/UranusBg", typeof(Texture2D));
        this.texture_5 = (Texture2D)Resources.Load("GUI/Login/RealmSelectBar", typeof(Texture2D));

        this.style_0 = new GUIStyle();
        this.style_0.font = (Font)Resources.Load("GUI/Fonts/ItimFont", typeof(Font));
        this.style_0.normal.textColor = new Color(1f, 1f, 1f, 1f);
        this.style_0.fontSize = 20;

        this.style_1 = new GUIStyle();
        this.style_1.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_1.normal.textColor = global::Math.HexToColor("#1c2940");
        this.style_1.fontSize = 18;
        this.style_1.alignment = TextAnchor.MiddleLeft;
        this.style_1.normal.background = (Texture2D)Resources.Load("GUI/Login/InputBar01", typeof(Texture2D));

        this.style_2 = new GUIStyle();
        this.style_2.hover.background = (Texture2D)Resources.Load("GUI/Login/loginButton_h", typeof(Texture2D));

        this.style_3 = new GUIStyle();
        this.style_3.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_3.normal.textColor = new Color(1f, 1f, 1f, 1f);
        this.style_3.fontSize = 18;
        this.style_3.alignment = TextAnchor.MiddleCenter;
        this.style_3.normal.background = (Texture2D)Resources.Load("GUI/Login/NoticeBarMessage1", typeof(Texture2D));

        this.style_4 = new GUIStyle();

        this.style_5 = new GUIStyle();
        this.style_5.hover.background = (Texture2D)Resources.Load("GUI/Login/ServerAumButton_h", typeof(Texture2D));


        this.style_6 = new GUIStyle();
        this.style_6.hover.background = (Texture2D)Resources.Load("GUI/Login/Realm1Button_h", typeof(Texture2D));

        this.style_7 = new GUIStyle();
        this.style_7.normal.background = (Texture2D)Resources.Load("GUI/Login/ButtonUndo", typeof(Texture2D));
        this.style_7.hover.background = (Texture2D)Resources.Load("GUI/Login/ButtonUndo_h", typeof(Texture2D));
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1980f, 1080f), this.texture_0);
        if (this.eLogin == eLogin.Init)
        {
            this.delay_0 = Time.time;
            this.eLogin = eLogin.fadeIn;
            return;
        }
        if (this.eLogin == eLogin.fadeIn)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.Loading.Fade();
                return;
            }
            this.delay_0 = Time.time;
            this.eLogin = eLogin.Login;
            return;
        }
        if (this.eLogin == eLogin.Login)
        {
            this.Login();
        }
        if (this.eLogin == eLogin.Loading)
        {
            this.vetifyPlayer();
        }
        if (this.eLogin == eLogin.fail)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("load fail");
                return;
            }
            this.delay_0 = Time.time;
            this.eLogin = eLogin.Login;
            return;
        }
        if (this.eLogin == eLogin.down)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("server down");
                return;
            }
            this.delay_0 = Time.time;
            this.eLogin = eLogin.Login;
            return;
        }
        if (this.eLogin == eLogin.timeOut)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Too many requests, please try again later.");
                return;
            }
            this.eLogin = eLogin.Login;
            return;
        }
        if (this.eLogin == eLogin.success)
        {
            this.SelectServer();
        }
        if (this.eLogin == eLogin.selectRealm)
        {
            this.OnConnect();
        }
        if (this.eLogin == eLogin.connect)
        {

        }
        if (this.eLogin == eLogin.isFull)
        {

        }
        if (this.eLogin == eLogin.serveOut)
        {

        }
        if (this.eLogin == eLogin.tooOut)
        {

        }
        if (this.eLogin == eLogin.connected)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Connected");
                return;
            }
            this.eLogin = eLogin.retriev;
            return;
        }
        if (this.eLogin == eLogin.retriev)
        {
            this.FetchData();
        }
        if (this.eLogin == eLogin.join)
        {
            if (Time.time < this.delay_0 + 1f)
            {
                this.RenderNoticeMessage("Entering Starpunk . . .");
                return;
            }
            this.OnJoin();
            return;
        }
    }
    private void OnConnect()
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 353.5f, 600f, 707f, 350f), this.texture_5);
        if (GUI.Button(new Rect(0.5f * this.display_0 - 295f, 720f, 586f, 74f), string.Empty, this.style_6))
        {
            this.OnJoinServer();
            this.delay_0 = Time.time;
            this.eLogin = eLogin.connected;
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 + 255f, 626, 60f, 55f), string.Empty, this.style_7))
        {
            this.delay_0 = Time.time;
            this.eLogin = eLogin.success;
        }
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 126f, 623f, 252f, 288f), this.texture_4);
    }
    private void SelectServer()
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 353.5f, 600f, 707f, 350f), this.texture_3);
        if (GUI.Button(new Rect(0.5f * this.display_0 - 295f, 720f, 586f, 74f), string.Empty, this.style_5))
        {
            this.eLogin = eLogin.selectRealm;
            this.delay_0 = Time.time;
        }
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 126f, 623f, 252f, 288f), this.texture_4);
    }
    private void Login()
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 215f, 700f, 430f, 236f), this.texture_1);
        // Text Input
        this.email_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 100f, 752f, 246, 27f), this.email_0, 50, this.style_1);
        // Password Input
        this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 100f, 801f, 246, 27f), this.QUk8sYq_x, "*"[0], 20, this.style_1);
        if (GUI.Button(new Rect(0.5f * this.display_0 + 38f, 852f, 35f, 35f), string.Empty, this.style_4))
        {
            if (PlayerPrefs.GetInt("saveUser", 0) != 0)
            {
                PlayerPrefs.SetInt("saveUser", 0);
            }
            else
            {
                PlayerPrefs.SetInt("saveUser", 1);
                PlayerPrefs.SetString("email", this.email_0);
            }
        }
        if (PlayerPrefs.GetInt("saveUser", 0) != 0)
        {
            this.email_0 = PlayerPrefs.GetString("email");
            GUI.DrawTexture(new Rect(0.5f * this.display_0 + 38f, 852f, 30f, 30f), this.texture_2);
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 - 149f, 846f, 163f, 47f), string.Empty, this.style_2))
        {
            UMIHashData.req = JSON.UMIRespon("{\"status\":\"202\"}");
            StartCoroutine(UMIGetLogin.star.GetLogin(this.email_0, this.QUk8sYq_x, UMIHashData.playerSetData));
            this.delay_0 = Time.time;
            //# edit
            this.eLogin = eLogin.success;
        }
    }
    private void vetifyPlayer()
    {
        if (Time.time - this.delay_0 < this.speddPlay_0)
        {
            this.ReaderAnimationNoticeBar();
            return;
        }
        this.RenderNoticeMessage("Loading . . .");
        try
        {
            if (UMIHashData.req.status == "200")
            {
                this.delay_0 = Time.time;
                this.eLogin = eLogin.success;
            }
            if (UMIHashData.req.status == "404")
            {
                this.delay_0 = Time.time;
                this.eLogin = eLogin.fail;
            }
            if (UMIHashData.req.status == "429")
            {
                this.delay_0 = Time.time;
                this.eLogin = eLogin.timeOut;
            }
            if (UMIHashData.req.status == "500")
            {
                this.delay_0 = Time.time;
                this.eLogin = eLogin.down;
            }
        }
        catch
        {
            UMISystem.Log("Loading Data ... ");
        }

    }
    private void OnJoin()
    {
        Game.loadNextLevel((int)eNextLevel.lobby);
    }
    private void FetchData()
    {
        this.RenderNoticeMessage("Retrieving player data . . .");
        if (Time.time - this.delay_0 < 1f)
        {
            return;
        }
        if (Game.isLoadDac)
        {
            this.delay_0 = Time.time;
            this.eLogin = eLogin.join;
            return;
        }
    }
    private void OnJoinServer()
    {
        //StartCoroutine(UMIGetData.star.GetData(UMIHashData.hDac[01].ToString(), UMIHashData.playerLoadData));
        // # edit
        StartCoroutine(UMIGetData.star.GetData("yo", UMIHashData.playerLoadData));
        //UMIClientManager.star.connectServer();
    }
    private void RenderNoticeMessage(string message)
    {
        GUI.Label(new Rect(0.5f * this.display_0 - 282.5f, 752f, 565f, 150f), message, this.style_3);
    }
    private void ReaderAnimationNoticeBar()
    {
        GUI.Label(new Rect(Mathf.SmoothStep(0.5f * this.display_0 - 0f, 0.5f * this.display_0 - 282.5f, (Time.time - this.delay_0) / this.speddPlay_0),
            752f,
            Mathf.SmoothStep(0f, 565, (Time.time - this.delay_0) / this.speddPlay_0), Mathf.SmoothStep(0f, 150f, (Time.time - this.delay_0) / this.speddPlay_0)), string.Empty, this.style_3);
    }

}