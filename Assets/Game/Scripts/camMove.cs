using UnityEngine.EventSystems;
using UnityEngine;

public class camMove : MonoBehaviour {

	[SerializeField] [HideInInspector] protected StandaloneInputModule env = null;
	[SerializeField] [HideInInspector] protected bool ZoomOn = false;
	[SerializeField] protected float speed = 20.0f;
	[SerializeField] protected Transform pivot;

	// Use this for initialization
	void Start () {
		this.env = GameObject.Find("EventSystem").GetComponent<StandaloneInputModule>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.ZoomOn) {
			if (this.env.input.mousePosition.x < Screen.width / 2) {
				this.pivot.eulerAngles += new Vector3(0 , this.speed , 0) * Time.deltaTime;
			} else {
				this.pivot.eulerAngles -= new Vector3(0 , this.speed , 0) * Time.deltaTime;
			}
		} else {
		}
	}
	public void OnMoveEnable() {
		this.ZoomOn = true;
	}
	public void OnMoveDisable() {
		this.ZoomOn = false;
	}
}
