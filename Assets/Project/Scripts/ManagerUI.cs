using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace UnityEngine.PostProcessing {
	public class ManagerUI : MonoBehaviour {
		[SerializeField] protected Animator Settings = null , MainMenu = null , SettingsSound = null , SettingsVideo = null , Task = null;
		[SerializeField] protected Dropdown Graphic = null;
		[SerializeField] protected Toggle Bloom = null , Antialiasing = null , AmbientOcclusionEffect = null;
		[SerializeField] [HideInInspector] protected PostProcessingBehaviour profile = null;
		// Use this for initialization
		void Start () {
			this.profile = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessingBehaviour>();
			loadSettingsGraphic();
		}
		
		protected void loadSettingsGraphic () {
			this.Graphic.value = PlayerPrefs.GetInt("Graphic");
			QualitySettings.SetQualityLevel(this.Graphic.value);
			//Bloom эффект
			if (PlayerPrefs.GetInt("Bloom") == 0) {
				this.Bloom.isOn = false;
			} else {
				this.Bloom.isOn = true;
			}
			this.BloomApplyEffect();
			//Antialiasing эффект
			if (PlayerPrefs.GetInt("Antialiasing") == 0) {
				this.Antialiasing.isOn = false;
			} else {
				this.Antialiasing.isOn = true;
			}
			this.AmbientOcclusionApplyEffect();
			//Antialiasing эффект
			if (PlayerPrefs.GetInt("AmbientOcclusion") == 0) {
				this.AmbientOcclusionEffect.isOn = false;
			} else {
				this.AmbientOcclusionEffect.isOn = true;
			}
			this.AmbientOcclusionApplyEffect();
		}

		public void la () {
			AudioListener Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
			
		}

		public void showSettings () {
			this.MainMenu.SetBool("open" , false);
			this.Settings.SetBool("open" , true);
		}

		public void hideSettings () {
			this.MainMenu.SetBool("open" , true);
			this.Settings.SetBool("open" , false);
		}

		public void loaddemolvl () {
			SceneManager.LoadScene(1);
		}

		public void showSettingsSound () {
			this.SettingsSound.SetBool("open" , true);
		}
		public void showSettingsVideo () {
			this.SettingsVideo.SetBool("open" , true);
		}

		public void hideSettingsSound () {
			this.SettingsSound.SetBool("open" , false);
		}
		public void hideSettingsVideo () {
			this.SettingsVideo.SetBool("open" , false);
			loadSettingsGraphic();
		}

		public void selectedgraphic () { 
			QualitySettings.SetQualityLevel(this.Graphic.value);
		}

		public void ExitGame () {
			Application.Quit();
		}
		public void saveSettingsGraphic () {
			PlayerPrefs.SetInt("Graphic" , QualitySettings.GetQualityLevel());
			//Bloom Эффект
			if (this.Bloom.isOn == true) {
				PlayerPrefs.SetInt("Bloom" , 1);
			} else {
				PlayerPrefs.SetInt("Bloom" , 0);
			}
			//Antialiasing эффект
			if (this.Antialiasing.isOn == true) {
				PlayerPrefs.SetInt("Antialiasing" , 1);
			} else {
				PlayerPrefs.SetInt("Antialiasing" , 0);
			}
			//Antialiasing эффект
			if (this.AmbientOcclusionEffect.isOn == true) {
				PlayerPrefs.SetInt("AmbientOcclusion" , 1);
			} else {
				PlayerPrefs.SetInt("AmbientOcclusion" , 0);
			}
			PlayerPrefs.Save();
			Debug.Log("Графика:сохранение успешно");
		}
		
		public void hideMainMenu () {
			this.MainMenu.SetBool("open" , false);
		}

		public void showMainMenu () {
			this.MainMenu.SetBool("open" , true);
		}
		
		public void showTask () {
			this.Task.SetBool("open" , true);
		}
		public void hideTask () {
			this.Task.SetBool("open" , false);
		}
		public void BloomApplyEffect () {
			this.profile.profile.bloom.enabled = this.Bloom.isOn;
		}
		public void AntialiasingApplyEffect () {
			this.profile.profile.antialiasing.enabled = this.Antialiasing.isOn;
		}
		public void AmbientOcclusionApplyEffect () {
			this.profile.profile.ambientOcclusion.enabled = this.AmbientOcclusionEffect.isOn;
		}
	}
}
