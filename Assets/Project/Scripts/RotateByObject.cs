//ака 47
using UnityEngine;

public class RotateByObject : MonoBehaviour {

	[SerializeField] protected Vector3 vc3 = new Vector3(0,0,0);

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (this.vc3.x,this.vc3.y,this.vc3.z);
	}
}