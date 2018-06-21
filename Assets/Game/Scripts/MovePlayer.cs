using UnityEngine;
public class MovePlayer : MonoBehaviour {

	[SerializeField] protected float speed = 50.0f;
	[SerializeField] protected float SpeedJump = 5.0f;
	[SerializeField] [HideInInspector] protected bool IsGround = false;
	[SerializeField] protected  SimpleTouchController leftController;
	[SerializeField] protected AudioSource IsGroundSound = null;
	[SerializeField] protected Transform cam;

	Rigidbody rb;
	// Use this for initialization
	protected void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	protected void FixedUpdate () {
		var h = leftController.GetTouchPosition.x;
		var v = leftController.GetTouchPosition.y;
		rb.AddTorque(cam.transform.forward * -h * Time.deltaTime * speed + cam.transform.right * v * Time.deltaTime * speed);
	}
	public void JumpToPlayer() {
		if (IsGround) {
			rb.velocity += Vector3.up * SpeedJump;
		}
	}
	protected void OnCollisionEnter (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			IsGround = true;
			IsGroundSound.Play();
		}
	}
	protected void OnCollisionExit (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			IsGround = false;
		}
	}
}
