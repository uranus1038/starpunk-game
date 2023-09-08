using UnityEngine;
public class IconClass
{
	public IconClass()
    {
		this.name = "none"; 
	}
	public void reset()
    {
		this.name = "none";
		this.hoverTime = 0f;
		this.image = null;
		this.state = eIconState.none; 
	}
	public string name;
	public float hoverTime;
	public Texture2D image;
	public eIconState state; 
}
