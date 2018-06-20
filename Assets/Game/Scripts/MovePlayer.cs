using UnityEngine;

public class MovePlayer : MonoBehaviour {

	[SerializeField] protected float speed = 5.0f;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
