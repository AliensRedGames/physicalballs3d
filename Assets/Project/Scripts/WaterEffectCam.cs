using UnityEngine;

namespace UnityEngine.PostProcessing
{
	public class WaterEffectCam : MonoBehaviour {

		[SerializeField] [HideInInspector] protected PostProcessingBehaviour profile;
		
		// Use this for initialization
		void Start () {
			this.profile = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessingBehaviour>();
		}

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Water Volume")) {
				this.profile.profile.vignette.enabled = true;
			}
		}
		private void OnTriggerExit(Collider other) {
			if (other.CompareTag("Water Volume")) {
				this.profile.profile.vignette.enabled = false;
			}
		}
	}
}
