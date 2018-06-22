using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SimpleTouchController : MonoBehaviour {

	[SerializeField] [HideInInspector] public delegate void TouchDelegate(Vector2 value);
	[SerializeField] [HideInInspector] public event TouchDelegate TouchEvent;

	[SerializeField] [HideInInspector] public delegate void TouchStateDelegate(bool touchPresent);
	[SerializeField] [HideInInspector] public event TouchStateDelegate TouchStateEvent;

	[SerializeField] [HideInInspector] private RectTransform joystickArea;
	[SerializeField] [HideInInspector] private bool touchPresent = false;
	[SerializeField] [HideInInspector] private Vector2 movementVector;


	public Vector2 GetTouchPosition
	{
		get { return this.movementVector;}
	}


	public void BeginDrag()
	{
		this.touchPresent = true;
		if(this.TouchStateEvent != null)
			TouchStateEvent(this.touchPresent);
	}

	public void EndDrag()
	{
		this.touchPresent = false;
		this.movementVector = this.joystickArea.anchoredPosition = Vector2.zero;

		if(this.TouchStateEvent != null)
			TouchStateEvent(this.touchPresent);

	}

	public void OnValueChanged(Vector2 value)
	{
		if(touchPresent)
		{
			// convert the value between 1 0 to -1 +1
			this.movementVector.x = ((1 - value.x) - 0.5f) * 2f;
			this.movementVector.y = ((1 - value.y) - 0.5f) * 2f;

			if(this.TouchEvent != null)
			{
				TouchEvent(this.movementVector);
			}
		}
	}
}
