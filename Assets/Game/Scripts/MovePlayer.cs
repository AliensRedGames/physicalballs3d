using UnityEngine;

public class MovePlayer : MonoBehaviour {

	[SerializeField] protected float speed = 5.0f;
	RectTransform js;
	Rigidbody rb;
	// Use this for initialization
	protected void Start () {
		rb = GetComponent<Rigidbody>();
		js = GameObject.Find("MobileJoystick").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	protected void FixedUpdate () {
		var h = Mathf.Round(js.position.x) - 145;
		var v = Mathf.Round(js.position.y) - 123;

		rb.AddTorque(new Vector3(v * Time.deltaTime * speed , 0 , -h * Time.deltaTime * speed));
	}
}
