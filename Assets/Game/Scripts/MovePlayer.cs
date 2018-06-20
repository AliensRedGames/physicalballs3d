using UnityEngine;

public class MovePlayer : MonoBehaviour {

	[SerializeField] protected float speed = 5.0f;
	[SerializeField] protected float SpeedJump = 5.0f;
	[SerializeField] protected bool IsGround = false;
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
	public void JumpToPlayer() {
		if (IsGround) {
			rb.velocity += Vector3.up * SpeedJump;
		}
	}
	protected void OnCollisionEnter (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			IsGround = true;
		}
	}
	protected void OnCollisionExit (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			IsGround = false;
		}
	}
}
