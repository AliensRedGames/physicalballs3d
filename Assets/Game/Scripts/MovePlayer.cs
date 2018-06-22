using UnityEngine;
public class MovePlayer : MonoBehaviour {

	[SerializeField] protected float speed = 50.0f;
	[SerializeField] protected float SpeedJump = 5.0f;
	[SerializeField] [HideInInspector] protected bool IsGround = false;
	[SerializeField] protected  SimpleTouchController leftController;
	[SerializeField] protected AudioSource IsGroundSound = null , IsWaterSound = null;
	[SerializeField] protected Transform cam;
	[SerializeField] protected bool isMobile = false;

	Rigidbody rb;
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
	protected void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Water Volume")) {
			this.IsWaterSound.Play();
		}
	}

	protected void OnTriggerStay (Collider other) {
		if (this.isMobile) {
			if (other.CompareTag("Water Volume")) {
				var h = this.leftController.GetTouchPosition.x;
				var v = this.leftController.GetTouchPosition.y;
				this.rb.AddForce(this.cam.transform.forward * v * Time.deltaTime * this.speed + this.cam.transform.right * h * Time.deltaTime * this.speed);
				this.rb.AddTorque(this.cam.transform.forward * -h * Time.deltaTime * this.speed + this.cam.transform.right * v * Time.deltaTime * this.speed);
			}
		} else {
			var h = Input.GetAxis("Horizontal");
			var v = Input.GetAxis("Vertical");
			this.rb.AddForce(this.cam.transform.forward * v * Time.deltaTime * this.speed + this.cam.transform.right * h * Time.deltaTime * this.speed);
			this.rb.AddTorque(this.cam.transform.forward * -h * Time.deltaTime * this.speed + this.cam.transform.right * v * Time.deltaTime * this.speed);
		}
	}

	protected void OnCollisionExit (Collision other) {
		if(other.collider.CompareTag("IsGround")) {
			this.IsGround = false;
		}
	}
}
