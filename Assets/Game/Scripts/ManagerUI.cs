using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerUI : MonoBehaviour {
	[SerializeField] protected Animator Settings = null , MainMenu = null;
	// Use this for initialization
	void Start () {
		
	}
	
	public void showSettings () {
		MainMenu.SetBool("open" , false);
		Settings.SetBool("open" , true);
	}

	public void hideSettings () {
		MainMenu.SetBool("open" , true);
		Settings.SetBool("open" , false);
	}

	public void loaddemolvl () {
		SceneManager.LoadScene(1);
	}

	public void ExitGame () {
		Application.Quit();
	}
}
