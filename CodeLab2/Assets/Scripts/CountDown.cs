using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

	public Timer timer;
	public TextMesh textMesh;
	public float duration;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			timer.StartTimer(duration, UpdateClock, TimerOff);

			timer.updateHandler += PrintElapsedTime;
		}
	}

	public void PrintElapsedTime(float timeElapsed){
		print("timeElapsed:" + timeElapsed);
	}

	private void UpdateClock(float timeElapsed){
		textMesh.text = "" + (duration - timeElapsed);
	}


	private void TimerOff(){
		textMesh.text = "TIME UP!";
	}
}
