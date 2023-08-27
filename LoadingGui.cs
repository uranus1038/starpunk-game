using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoadingGui : MonoBehaviour
{
    protected float display_0;
    protected float delay_0;
    protected float float_0;
    protected eLoading eLoading;
    private Texture texture_0; // bg_white
    public LoadingGui()
    {
        this.eLoading = eLoading.Init;
    }
    private void Awake()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Loading/White", typeof(Texture));
    }
    public virtual void fadeIn()
    {
        if (this.eLoading != eLoading.fadeIn)
        {
            this.eLoading = eLoading.fadeIn;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public virtual void fadeIn(float time)
    {
        if (this.eLoading != eLoading.fadeIn)
        {
            this.eLoading = eLoading.fadeIn;
            this.delay_0 = Time.time;
            this.float_0 = time;
            base.enabled = true;
        }
    }
    public virtual void fadeOut()
    {
        if (this.eLoading != eLoading.fadeOut)
        {
            this.eLoading = eLoading.fadeOut;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public virtual void fadeOut(float time)
    {
        if (this.eLoading != eLoading.fadeOut)
        {
            this.eLoading = eLoading.fadeOut;
            this.delay_0 = Time.time;
            this.float_0 = time;
            base.enabled = true;
        }
    }
    public virtual void Fade()
    {
        if (this.eLoading != eLoading.Fade)
        {
            this.eLoading = eLoading.Fade;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 1;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        switch (eLoading)
        {
            case eLoading.fadeIn:
                float a = Mathf.Lerp(1f, 0f, (Time.time - this.delay_0) / this.float_0);
                Color color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1980f, 1080f), this.texture_0);
                break;
            case eLoading.fadeOut:
                a = Mathf.Lerp(0f, 1f, (Time.time - this.delay_0) / this.float_0);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                break;
            case eLoading.Fade:
                a = 2f * (this.delay_0 + 0.5f - Time.time);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                Color color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                break;
        }
    }

}