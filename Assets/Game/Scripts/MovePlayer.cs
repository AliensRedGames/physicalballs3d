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
		this.rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	protected void FixedUpdate () {
		var h = leftController.GetTouchPosition.x;
		var v = leftController.GetTouchPosition.y;
		this.rb.AddTorque(this.cam.transform.forward * -h * Time.deltaTime * this.speed + this.cam.transform.right * v * Time.deltaTime * this.speed);
	}
	public void JumpToPlayer() {
		if (this.IsGround) {
			this.rb.velocity += Vector3.up * this.SpeedJump;
		}
	}
	protected void OnCollisionEnter (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			this.IsGround = true;
			this.IsGroundSound.Play();
		}
	}
	protected void OnCollisionExit (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			this.IsGround = false;
		}
	}
}
