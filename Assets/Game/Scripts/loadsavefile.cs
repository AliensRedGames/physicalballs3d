using UnityEngine;

public class loadsavefile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Graphic"));
	}

}
