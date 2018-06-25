//Ака 47 епта
using UnityEngine;

public class MoveObjectByPoint : MonoBehaviour {

	[SerializeField] protected int PointGood = 0;
	[SerializeField] protected Transform[] Point = null;
	[SerializeField] protected float smooth = 2f;
	[SerializeField] protected bool ToMove = true;
	[SerializeField] protected bool Restart = true;
	[SerializeField] protected int Freeze = 500;
	[SerializeField] [HideInInspector] protected float FreezeBegin;
	void Start(){
		FreezeBegin = Freeze;
	}

	// Update is called once per frame
	void Update () {
		if (Freeze == FreezeBegin) {
			if (ToMove == true) {
				if (Restart == false) {
					if (Point.Length != PointGood) {
						if (transform.localPosition == Point [PointGood].transform.localPosition) {
							PointGood++;
							Freeze = 0;
						}
						if(Freeze == FreezeBegin)
						{
							if (Point.Length != PointGood) {
								Vector3 a = Vector3.MoveTowards (transform.localPosition, Point [PointGood].transform.localPosition, Time.deltaTime * smooth);
								transform.localPosition = a;
							}
						}
					}
				} else {
					if (Point.Length != PointGood) {
						if (transform.localPosition == Point [PointGood].transform.localPosition) {
							PointGood++;
							Freeze = 0;
						}
						if (Point.Length == PointGood) {
							PointGood = 0;
							Freeze = 0;
						}
						if (Freeze == FreezeBegin) {
							if (Point.Length != PointGood) {
								Vector3 a = Vector3.MoveTowards (transform.localPosition, Point [PointGood].transform.localPosition, Time.deltaTime * smooth);
								transform.localPosition = a;
							}
						}
					}
				}
			}
		} else {
			Freeze++;
		}
	}
}