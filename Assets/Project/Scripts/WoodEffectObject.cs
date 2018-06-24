using UnityEngine;

public class WoodEffectObject : MonoBehaviour {

	[SerializeField] [HideInInspector] protected AudioSource au;
	// Use this for initialization
	void Start () {
		this.au = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void OnCollisionEnter(Collision other) {
		if (other.collider.CompareTag("IsGround")) {
			this.au.Play();
		}
	} 
}
