using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Anim
{
    play , 
    next , 
    stop , 
    Loop
}

public class AnimationControl : MonoBehaviour
{
    private Animator actor; 
    public float delay;
    public string actionCurrent; 
    public string actionState;
    public int count;
    public int num;
    public int nSpeed; 
    public AnimationControl ()
    {
        this.delay = 0f;
        this.nSpeed = 0;
        this.actionState = "standby";
        this.actionCurrent = string.Empty;
        this.count = 0;
        this.num = 0;
    }
    private void Awake()
    {
        this.actor = (Animator)this.GetComponent(typeof(Animator));
    }
    public void PlayAnimation(string nAnimationName)
    {
            this.actor.Play(nAnimationName);
    }
    public void PlayAnimation(string nAnimationName, float nCrossFadeTime)
    {
        if (nCrossFadeTime <= 0f)
        {
            this.actor.Play(nAnimationName);
        }
        else
        {
            this.actor.CrossFade(nAnimationName, nCrossFadeTime);
        }
    }
    public void PlayAnimation(string nAnimationName, float nCrossFadeTime, float nSpeed)
    {
        if (nCrossFadeTime <= 0f)
        {
            this.actor.Play(nAnimationName);
        }
        else
        {
            this.actor.CrossFade(nAnimationName, nCrossFadeTime);
        }
        this.actor.speed = nSpeed;
    }

}
