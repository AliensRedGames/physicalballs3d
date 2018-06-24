using UnityEngine;

public class CursorShow : MonoBehaviour {

	[SerializeField] protected bool CursorOn = false;
	// Use this for initialization
	void Start () {
		Cursor.visible = this.CursorOn;
	}
}
