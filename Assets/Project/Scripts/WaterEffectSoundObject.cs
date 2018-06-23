using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]
public class WaterEffectSoundObject : MonoBehaviour {
	[SerializeField] [HideInInspector] protected AudioSource Effect = null;
	// Use this for initialization
	void Start () {
		this.Effect = this.GetComponent<AudioSource>();
	}
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Water Volume")) {
			this.Effect.Play();
		}
	}
}
