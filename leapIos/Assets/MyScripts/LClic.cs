using UnityEngine;
using System.Collections;

public class LClic : MonoBehaviour {
	//This script defines the LIOS equivelent of left click (turn key gesture)
	public bool Lclic;
	public int step;
	private float t;
	private LeapManager manager;													//This provides access to leap data
	private Leap.Frame frame;
	private GetFrame a;

	void awake () {
		step    = 0;												//This will indicate state through the gesture.
	}

	void Start () {
		manager = Camera.main.GetComponent<LeapManager>();							//This links to some leap data
		a       = Camera.main.GetComponent<GetFrame> ();
		Lclic   = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Lclic)Lclic = false;
		frame = a.frame;
		t    += Time.deltaTime;
		if (manager != null && manager.IsLeapInitialized ()) {
			switch (step) {
			case 0:
				t = 0;
				if(frame.Pointables.Count==2)step++; //double pinch
			break;
			case 1:
				if(frame.Pointables.Count==0)step++;
			break;
			case 2:
				if(frame.Pointables.Count==2)step++;
			break;
			case 3:
				if(frame.Pointables.Count==0)step++;
			break;
			}
		}
		if (t > 1)step = 0;
		if (step == 4) {
			Lclic = true;
			t     = 0;
			step  = 0;
		}
	}
}
