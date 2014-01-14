using UnityEngine;
using System.Collections;

public class IsClic : MonoBehaviour {

	//this class imports rclic and lclic and handles clicability

	public LClic lClic;								//...For the conection to the clicking
	public RClic rClic;								//...

	private LeapManager manager;

	public bool isLclic;							//the combination of booleans from lClic or rClic
	public bool isRclic;							//and the position of the and and object yeild click or selection

	public Vector3 handPos;							//the position of the hand
	public Vector3 objPos;							//the position of the object or Icon
	public float Distance;							//represents the distance btween the 2
	public float tol;								//represents the tolorance or size of the clickable object (How close is cloe enough)
	public int rk,lk;
	public Vector3 fix;



	void Start () {
		manager = Camera.main.GetComponent<LeapManager>();
		rClic = Camera.main.GetComponent<RClic>();	
		lClic = Camera.main.GetComponent<LClic>();
		tol   = 2.5F;
		lk = 0;
		rk = 0;
		fix.x=1.5F;fix.y = 0F;fix.z = 3F;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (manager != null && manager.IsLeapInitialized ()) {
			handPos = manager.GetHandPos () * manager.DisplayFingerScale + manager.DisplayFingerPos + fix;
			objPos = transform.position;
			Distance = Mathf.Pow ((float)(Mathf.Pow ((objPos.x - handPos.x), 2) + Mathf.Pow ((objPos.y - handPos.y), 2) + Mathf.Pow ((objPos.z - handPos.z), 2)), (float)0.5);
		}
		if(Distance<tol) {							//cehcking to make sure that the gesture was infact intended for a particualr Icon
			transform.GetChild(1).gameObject.SetActive(true);
			if(lClic.Lclic){
				isLclic=!isLclic;
				lk++;
			}
			if(rClic.Rclic){
				isRclic=!isRclic;
				rk++;
			}
		}
		else{transform.GetChild(1).gameObject.SetActive(false);}
	}
}
