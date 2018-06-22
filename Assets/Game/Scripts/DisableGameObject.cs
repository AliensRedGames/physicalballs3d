using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : StateMachineBehaviour {
	[SerializeField]  protected GameObject gmoff = null , gmon = null;
	[SerializeField] protected string gmnameoff = "MainMenu" , gmnameon = "Settings";

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.gmoff = GameObject.Find(this.gmnameoff);
		this.gmon = GameObject.Find(this.gmnameon);
		this.gmoff.SetActive(false);
		this.gmon.SetActive(true);
	}
}
