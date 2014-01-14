using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class BIDT : MonoBehaviour {
	//This script makes the desktop icons apear at a gesture. (flip of the hand)

	public float RotTot;															//indicates the total rotation required
	public bool isDT;																//This indicates weather or not to display desktop icons.
	public int k;																	//Counts the number of consecutive frames rotation is detected.
	public int km;
	public float t;
	private LeapManager manager;													//This provides access to leap data
	private Leap.Frame frame;
	private GetFrame a;																//I enjoy Aframe architecture ;)


	//tracks the maximum value of k for dev purposes

	void awake () {					
		isDT    = false;															//could start true or false, need initialization regrdless.
	}

	void Start () {
		manager = Camera.main.GetComponent<LeapManager>();	
		a       = Camera.main.GetComponent<GetFrame> ();

		k  = 0;
		km = 0;
		t  = 0;
		transform.GetChild(0).gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		frame = a.frame;
		if(t<1.5)
			t += Time.deltaTime; 													//This prevents multiple unintentional gestures.
		Debug.Log (manager != null);
		Debug.Log (manager.IsLeapInitialized ());
		if (manager != null && manager.IsLeapInitialized ()) {
			if(t>=1.5){																// prevents multiple unintentional gestures.
				if(frame.Pointables.Count>=5){
					k++;
					/*if(frame.RotationAngle(frame)<=0){
						k++;
					}
					else{
						k=0;
					}*/
				}
			}
			if(k>15){//Debug.Log ("BditVICTORY");
				isDT=!isDT;															//This is the "objective" of the gesture.
				k=0;
				t=0;
			}
			if(isDT){transform.GetChild(0).gameObject.SetActive(false);}
			else{transform.GetChild(0).gameObject.SetActive(true);}
		}
	}
}
