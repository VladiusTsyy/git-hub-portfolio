using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
	public float slowdownfactor;
	private float slowdownlenght;

	// Use this for initialization
	void Start () {
		slowdownlenght = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(slowdownlenght < 1)
		{
			slowdownlenght += Time.unscaledDeltaTime;
			if(slowdownlenght > 1)
			{
				slowdownlenght = 1;
				Time.timeScale = 1;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;
			}
			
		}
	}
	public void Slowmotion()
	{
		slowdownlenght = 0;
		Time.timeScale = slowdownfactor;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}
}
