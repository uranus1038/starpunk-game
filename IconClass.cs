using UnityEngine;
public class IconClass
{
	public IconClass()
	{
		this.name = "none";
	}

	public virtual void reset()
	{
		this.name = "none";
		this.command = 0;
		this.image = null;
		this.state = eIconState.none;
		this.hoverTime = 0f;
	}

	public string name;
	public int command;
	public Texture2D image;
	public eIconState state;
	public float hoverTime;
}
