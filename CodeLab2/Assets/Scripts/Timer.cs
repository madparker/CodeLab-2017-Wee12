using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public delegate void UpdateHandler(float timeElapsed);
	public event UpdateHandler updateHandler;

	public delegate void EndHandler();
	public event EndHandler endHandler;

	private bool isActive = false;
	private float currentTime = 0;
	private float length = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(isActive){
			currentTime += Time.deltaTime;

			if(updateHandler != null){
				updateHandler(currentTime);
			}

			if(currentTime >= length){
				endTimer();
			}
		}
	}

	public void StartTimer(float time, UpdateHandler u, EndHandler e){
		updateHandler = u;
		endHandler = e;
		isActive = true;
		currentTime = 0;
		length = time;
	}

	public void endTimer(){
		isActive = false;
		endHandler();
	}
}
