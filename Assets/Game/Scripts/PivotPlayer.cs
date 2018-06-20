using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPlayer : MonoBehaviour {
	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = player.transform.localPosition;
	}
}
