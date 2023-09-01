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
    internal protected string email_0;
    internal protected string QUk8sYq_x;
    internal protected eLogin eLogin;
    private Texture texture_0; // bg_black
    private GUIStyle style_0; 
    private LoadingGui Loading;
    private void Awake()
    {
        this.email_0 = string.Empty;
        this.QUk8sYq_x = string.Empty;
        this.Init();
        this.Loading = (LoadingGui)this.GetComponent(typeof(LoadingGui));
    }

    private void Start()
    {
        Application.targetFrameRate = 80;
        Application.runInBackground = true;
        Application.backgroundLoadingPriority = ThreadPriority.High;
    }
    private void Init()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Login/black", typeof(Texture));

        this.style_0 = new GUIStyle();
        this.style_0.font = (Font)Resources.Load("GUI/Fonts/Font", typeof(Font));
        this.style_0.normal.textColor = new Color(1f, 1f, 1f, 1f);
        this.style_0.fontSize = 20;
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
    private void Login()
    {
        // Text Input
        this.email_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 98f, 772f, 288f, 30f), this.email_0, 50);
        // Password Input
        this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 98f, 812f, 288f, 30f), this.QUk8sYq_x, "*"[0], 20);
        if (GUI.Button(new Rect(0.5f * this.display_0 - 142f, 863f, 253f / 2f, 124f / 2f), "Submit คลิก", this.style_0))
        {
            UMIHashData.req = JSON.UMIRespon("{\"status\":\"202\"}");
            StartCoroutine(UMIGetLogin.star.GetLogin(this.email_0, this.QUk8sYq_x , UMIHashData.playerSetData));
            this.delay_0 = Time.time;
            // # Edit
            this.eLogin = eLogin.success;
        }
    }
    private void vetifyPlayer()
    {
        GUI.Label(new Rect(0.5f * this.display_0 - 645f / 2.8f, 738f, 700f / 1.4f, 268f / 1.4f), "Loading . . .");
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
    private void OnConnect()
    {
        if (GUI.Button(new Rect(0.5f * this.display_0 - 142f, 863f, 253f / 2f, 124f / 2f), "serve uranus"))
        {
            this.OnJoinServer();
            this.delay_0 = Time.time;
            this.eLogin = eLogin.connected;
        }
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
       // StartCoroutine(UMIGetData.star.GetData(UMIHashData.hDac[01].ToString(), UMIHashData.playerLoadData));
        StartCoroutine(UMIGetData.star.GetData("uranus", UMIHashData.playerLoadData));
        //UMIClientManager.star.connectServer();
    }
    private void RenderNoticeMessage(string message)
    {
        GUI.Label(new Rect(0.5f * this.display_0 - 645f / 2.8f, 738f, 700f / 1.4f, 268f / 1.4f), message);
    }

}