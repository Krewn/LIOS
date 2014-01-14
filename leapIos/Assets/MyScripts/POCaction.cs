using UnityEngine;
using System.Collections;

public class POCaction : MonoBehaviour {

	bool l;
	bool r;
	IsClic ic;

	// Use this for initialization
	void Start () {
		l = false;
		r = false;
		ic = gameObject.GetComponent<IsClic> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ic.isLclic)
						l = true;
				else
						l = false;
		if (ic.isRclic)
						r = true;
				else
						r = false;

		if (!l && !r)renderer.material.color = Color.grey;
		if (!l && r )renderer.material.color = Color.red;
		if (l  && !r)renderer.material.color = Color.blue;
		if (l  && r )renderer.material.color = Color.magenta;
			
	}
}
