using UnityEngine;
public class MovePlayer : MonoBehaviour {

	[SerializeField] public float speed = 50.0f;
	[SerializeField] protected float SpeedJump = 5.0f;
	[SerializeField] [HideInInspector] protected bool IsGround = false;
	[SerializeField] public  SimpleTouchController leftController;
	[SerializeField] protected AudioSource IsGroundSound = null;
	[SerializeField] public Transform cam;
	[SerializeField] public bool isMobile = false;

	[SerializeField] [HideInInspector] public Rigidbody rb;
	// Use this for initialization
	protected void Start () {
		this.rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	protected void FixedUpdate () {
		if (this.isMobile) {
			var h = this.leftController.GetTouchPosition.x;
			var v = this.leftController.GetTouchPosition.y;
			this.rb.AddTorque(this.cam.transform.forward * -h * Time.deltaTime * this.speed + this.cam.transform.right * v * Time.deltaTime * this.speed);
		} else {
			var h = Input.GetAxis("Horizontal");
			var v = Input.GetAxis("Vertical");
			this.rb.AddTorque(this.cam.transform.forward * -h * Time.deltaTime * this.speed + this.cam.transform.right * v * Time.deltaTime * this.speed);
			if (Input.GetButton("Jump")) {
				JumpToPlayer();
			}
		}
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
