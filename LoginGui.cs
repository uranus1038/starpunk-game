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
            this.delay_0 = Time.time;
            this.eLogin = eLogin.Login;
            return;
        }
        if (this.eLogin == eLogin.success)
        {
            this.OnConnect();
        }
        if (this.eLogin == eLogin.connect)
        {
            this.FetchData();
        }
        if(this.eLogin == eLogin.connected)
        {

        }
    }
    private void Login()
    {
        // Text Input
        this.email_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 98f, 772f, 288f, 30f), this.email_0, 50);
        // Password Input
        this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 98f, 812f, 288f, 30f), this.QUk8sYq_x, "*"[0], 20);
        if (GUI.Button(new Rect(0.5f * this.display_0 - 142f, 863f, 253f / 2f, 124f / 2f), "Submit"))
        {
            UMIHashData.req = JSON.UMIRespon("{\"status\":\"202\"}");
            StartCoroutine(UMIGetLogin.star.GetLogin(this.email_0, this.QUk8sYq_x , UMIHashData.playerSetData));
            this.delay_0 = Time.time;
            this.eLogin = eLogin.Loading;
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
    private void OnConnect()
    {
        if (GUI.Button(new Rect(0.5f * this.display_0 - 142f, 863f, 253f / 2f, 124f / 2f), "serve uranus"))
        {
            Game.loadNextLevel(0);
           // this.OnJoinServer();
            //this.delay_0 = Time.time;
            //this.eLogin = eLogin.connect;
        }
    }
    private void FetchData()
    {
            this.RenderNoticeMessage("Retrieving player data file..");
    }
    private void OnJoinServer()
    {
        //UMIClientManager.star.connectServer();
    }
    private void RenderNoticeMessage(string message)
    {
        GUI.Label(new Rect(0.5f * this.display_0 - 645f / 2.8f, 738f, 700f / 1.4f, 268f / 1.4f), message);
    }

}