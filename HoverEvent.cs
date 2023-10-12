using System;
using UnityEngine;

public class HoverEvent : MonoBehaviour
{
	public static eHoverEvent getHoverButtonEvent(Rect position, int controlID)
	{
		EventType typeForControl = Event.current.GetTypeForControl(controlID);
		if (typeForControl == EventType.MouseDown)
		{
			if (position.Contains(Event.current.mousePosition))
			{
				GUIUtility.hotControl = controlID;
				Event.current.Use();
				if (Event.current.button == 0)
				{
					return eHoverEvent.leftclick;
				}
			}
		}
		else
		{
			if (typeForControl == EventType.MouseUp)
			{
				if (GUIUtility.hotControl == controlID)
				{
					GUIUtility.hotControl = 0;
				}
				return (!position.Contains(Event.current.mousePosition)) ? eHoverEvent.none : eHoverEvent.hover;
			}
			if (GUIUtility.hotControl == controlID)
			{
				GUIUtility.hotControl = 0;
				return eHoverEvent.mouseUp;
			}
		}
		return eHoverEvent.none;
	}

	// Token: 0x06004171 RID: 16753 RVA: 0x005CD7B0 File Offset: 0x005CB9B0
	public static eHoverState newCreateRect(HoverClass nHover, Rect nButtonPosition, float t)
	{
		int controlID = GUIUtility.GetControlID(FocusType.Native);
		eHoverState result = eHoverState.none;
		eHoverEvent hoverButtonEvent = HoverEvent.getHoverButtonEvent(nButtonPosition, controlID);
		if (hoverButtonEvent == eHoverEvent.none)
		{
			nHover.state = eHoverState.none;
		}
		else if (hoverButtonEvent == eHoverEvent.hover)
		{
			if (nHover.state == eHoverState.none)
			{
				nHover.state = eHoverState.hover;
				nHover.hoverTime = Time.time;
			}
			else if (nHover.state == eHoverState.hover)
			{
				if (nHover.hoverTime + t <= Time.time)
				{
					result = eHoverState.hover;
				}
				else
				{
					result = eHoverState.over;
				}
			}
		}
		else if (hoverButtonEvent == eHoverEvent.leftclick)
		{
			nHover.hoverTime = Time.time;
			result = eHoverState.press;
		}
		else if (hoverButtonEvent == eHoverEvent.mouseUp)
		{
			nHover.state = eHoverState.none;
		}
		return result;
	}
}
