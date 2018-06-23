using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManagerUI : MonoBehaviour {
	[SerializeField] protected Animator Settings = null , MainMenu = null , SettingsSound = null , SettingsVideo;
	[SerializeField] protected Dropdown Graphic = null;
	// Use this for initialization
	void Start () {
		loadSettingsGraphic();
	}
	
	protected void loadSettingsGraphic () {
		this.Graphic.value = PlayerPrefs.GetInt("Graphic");
		QualitySettings.SetQualityLevel(this.Graphic.value);
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
		PlayerPrefs.Save();
		Debug.Log("Графика:сохранение успешно");
	}
	
	public void hideMainMenu () {
		this.MainMenu.SetBool("open" , false);
	}

	public void showMainMenu () {
		this.MainMenu.SetBool("open" , true);
	}
}
