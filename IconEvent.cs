using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconEvent : MonoBehaviour
{
	public static eIconEvent getIconEvent(Rect position, int controlID)
	{
		EventType typeForControl = Event.current.GetTypeForControl(controlID);
		if (typeForControl == EventType.MouseDown)
		{
			if (position.Contains(Event.current.mousePosition))
			{
				GUIUtility.hotControl = controlID;
				if (Event.current.button == 0)
				{
					return eIconEvent.leftclick;
				}
				if (Event.current.button == 1)
				{
					return eIconEvent.rightclick;
				}
				Event.current.Use();
			}
		}
		else if (typeForControl == EventType.MouseUp)
		{
			if (GUIUtility.hotControl == controlID)
			{
				GUIUtility.hotControl = 0;
				return eIconEvent.mouseUp;
			}
			if (position.Contains(Event.current.mousePosition))
			{
				return eIconEvent.drop;
			}
		}
		else
		{
			if (typeForControl != EventType.MouseDrag)
			{
				return (!position.Contains(Event.current.mousePosition)) ? eIconEvent.none : eIconEvent.hover;
			}
			if (GUIUtility.hotControl == controlID && Event.current.button == 1)
			{
				GUIUtility.hotControl = 0;
				return eIconEvent.drag;
			}
		}
		return eIconEvent.none;
	}
	public static eIconState IconMove(IconClass nIcon, Rect nIconPosition)
	{
		int controlID = GUIUtility.GetControlID(FocusType.Native);
		eIconState result = eIconState.none;
		eIconEvent iconEvent = global::IconEvent.getIconEvent(nIconPosition, controlID);
		if (iconEvent == eIconEvent.none)
		{
			if (nIcon.state != eIconState.drag)
			{
				nIcon.state = eIconState.none;
			}
			else
			{
				result = eIconState.drag;
			}
		}
		else if (iconEvent == eIconEvent.hover)
		{
			if (nIcon.state == eIconState.drag)
			{
				result = eIconState.drag;
			}
			else if (nIcon.state == eIconState.none)
			{
				nIcon.state = eIconState.hover;
				nIcon.hoverTime = Time.time;
			}
			else if (nIcon.state == eIconState.hover)
			{
				if (nIcon.hoverTime + 0.5f <= Time.time)
				{
					result = eIconState.hover;
				}
				else
				{
					result = eIconState.over;
				}
			}
		}
		else if (iconEvent == eIconEvent.leftclick)
		{
			nIcon.hoverTime = Time.time;
			result = eIconState.press;
		}
		else if (iconEvent != eIconEvent.rightclick)
		{
			if (iconEvent == eIconEvent.drag)
			{
				if (nIcon.state != eIconState.drag)
				{
					nIcon.state = eIconState.drag;
					result = eIconState.drag;
				}
			}
			else if (iconEvent == eIconEvent.drop)
			{
				result = eIconState.drop;
			}
			else if (iconEvent == eIconEvent.mouseUp)
			{
				nIcon.state = eIconState.none;
				result = eIconState.none;
			}
		}
		return result;
	}
}
