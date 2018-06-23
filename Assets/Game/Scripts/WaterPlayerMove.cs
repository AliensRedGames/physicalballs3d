using UnityEngine;

public class WaterPlayerMove: MonoBehaviour {

	[SerializeField] [HideInInspector] protected MovePlayer mv = null;
	// Use this for initialization
	void Start () {
		this.mv = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
	}
	protected void OnTriggerStay (Collider other) {
		if (other.CompareTag("Water Volume")) {
			if (this.mv.isMobile) {
				var h = this.mv.leftController.GetTouchPosition.x;
				var v = this.mv.leftController.GetTouchPosition.y;
				this.mv.rb.AddForce(this.mv.cam.transform.forward * v * Time.deltaTime * this.mv.speed + this.mv.cam.transform.right * h * Time.deltaTime * this.mv.speed);
				this.mv.rb.AddTorque(this.mv.cam.transform.forward * -h * Time.deltaTime * this.mv.speed + this.mv.cam.transform.right * v * Time.deltaTime * this.mv.speed);
			} else {
				var h = Input.GetAxis("Horizontal");
				var v = Input.GetAxis("Vertical");
				this.mv.rb.AddForce(this.mv.cam.transform.forward * v * Time.deltaTime * this.mv.speed + this.mv.cam.transform.right * h * Time.deltaTime * this.mv.speed);
				this.mv.rb.AddTorque(this.mv.cam.transform.forward * -h * Time.deltaTime * this.mv.speed + this.mv.cam.transform.right * v * Time.deltaTime * this.mv.speed);
			}
		}
	}
}
