using UnityEngine;

public class PivotPlayer : MonoBehaviour {
	[SerializeField] [HideInInspector] protected float X , Y , Z;
	[SerializeField] protected Transform player;
	// Use this for initialization
	protected void Start () {
		this.X = this.transform.localPosition.x;
		this.Y = this.transform.localPosition.y;
		this.Z = this.transform.localPosition.z;
	}
	
	// Update is called once per frame
	protected void Update () {
		this.transform.localPosition = new Vector3(this.player.transform.localPosition.x + this.X , this.player.transform.localPosition.y + this.Y, this.player.transform.localPosition.z + this.Z);
	}
}
