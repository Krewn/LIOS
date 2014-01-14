using UnityEngine;
using System.Collections;

public class RClic : MonoBehaviour {
	public bool Rclic;
	public int step;
	private int k;
	private float t;
	private LeapManager manager;													//This provides access to leap data
	private Leap.Frame frame;
	private GetFrame a;
	public float[] spector;

	void Start () {
		manager = Camera.main.GetComponent<LeapManager>();							//This links to some leap data
		a       = Camera.main.GetComponent<GetFrame> ();
		Rclic   = false;
		step    = 0;
		spector = new float[3];
	}
	
	// Update is called once per frame
	void Update () {
		if (Rclic)Rclic = false;
		frame = a.frame;
		if (manager != null && manager.IsLeapInitialized ()) {
			Debug.Log ("ello");
			spector = frame.RotationAxis(frame).ToFloatArray();
			switch(step){
			case 0:t =0;
				if(frame.Pointables.Count==2){
					step++;
				}
				break;
			case 1:t += Time.deltaTime;
				if(frame.Pointables.Count==0){
					step++;
				}
				break;
			case 2:t += Time.deltaTime;												// prevents multiple unintentional gestures.
				if(frame.Pointables.Count<=2){
					if(frame.RotationAxis(frame).z>0.5){
						k++;
					}
				}
				if(k>15){
					step++;															//This is the "objective" of the gesture.
					k=0;
					t=0;
				}
			break;
			}
			if(step==3){
				Rclic=true;
				step=0;
			}
		}
	}
}
