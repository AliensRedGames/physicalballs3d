using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerUI : MonoBehaviour {
	[SerializeField] protected Animator Settings = null , MainMenu = null , SettingsSound = null , SettingsVideo;
	// Use this for initialization
	void Start () {
		
	}
	
	public void showSettings () {
		this.MainMenu.SetBool("open" , false);
		this.Settings.SetBool("open" , true);
		this.Settings.GetComponent<MeshRenderer>().material.color = Color.black;
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
	}

	public void ExitGame () {
		Application.Quit();
	}
}
