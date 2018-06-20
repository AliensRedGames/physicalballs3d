using UnityEngine.EventSystems;
using UnityEngine;

public class camMove : MonoBehaviour {

	[SerializeField] [HideInInspector] protected StandaloneInputModule env = null;
	[SerializeField] [HideInInspector] protected bool ZoomOn = false;
	[SerializeField] protected float speed = 20.0f;
	[SerializeField] protected Transform pivot;

	// Use this for initialization
	void Start () {
		env = GameObject.Find("EventSystem").GetComponent<StandaloneInputModule>();
	}
	
	// Update is called once per frame
	void Update () {
		if (ZoomOn) {
			if (env.input.mousePosition.x < Screen.width / 2) {
				pivot.eulerAngles += new Vector3(0 , speed , 0) * Time.deltaTime;
			} else {
				pivot.eulerAngles -= new Vector3(0 , speed , 0) * Time.deltaTime;
			}
		} else {
		}
	}
	public void OnMoveEnable() {
		ZoomOn = true;
	}
	public void OnMoveDisable() {
		ZoomOn = false;
	}
}
