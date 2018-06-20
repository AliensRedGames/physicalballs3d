using UnityEngine;

public class PivotPlayer : MonoBehaviour {
	[SerializeField] [HideInInspector] protected float X , Y , Z;
	Transform player;
	// Use this for initialization
	protected void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		X = transform.localPosition.x;
		Y = transform.localPosition.y;
		Z = transform.localPosition.z;
	}
	
	// Update is called once per frame
	protected void Update () {
		transform.localPosition = new Vector3(player.transform.localPosition.x + X , player.transform.localPosition.y + Y, player.transform.localPosition.z + Z);
	}
}
