using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Pointer : MonoBehaviour {
	//this script will make a laser out of a finger if there is only 1 finger detected
	/*
	private Vector3 leapPointablePos;
	private Vector3 leapPointableDir;
	 */
	public Mesh strMesh;
	private List<Vector3> verts;//new Vector3(x,y,z)
	private int[] groups;//of 3
	private List<bool>isThere;
	private LeapManager manager;							//This provides access to leap data
	private Vector3 util;

	void awake () {
		util = new Vector3(0, 0, 1);
		manager = Camera.main.GetComponent<LeapManager>();
		verts=new List<Vector3>();
		groups=new int[6]{0,1,2,2,1,0,};
	}

	void Start () {
		//on your marks, get set, GO!
	}

	void Update () {												//this is called once per frame
		if (manager != null && manager.IsLeapInitialized ()) {
			if (Input.anyKey) {Debug.Log ("The");
				if (manager.GetFingersCount () == 1) {Debug.Log ("more");
					if (manager.IsPointableValid ()) {Debug.Log ("youKNow");
						verts.Clear ();
						verts.Add (manager.GetPointablePos ());
						verts.Add (manager.GetPointablePos () + 100 * manager.GetPointablePos () - util);
						verts.Add (manager.GetPointablePos () + 100 * manager.GetPointablePos () + util);
						if (!GetComponent<MeshFilter> ())
								gameObject.AddComponent<MeshFilter> ();
						if (!GetComponent<MeshRenderer> ())
								gameObject.AddComponent<MeshRenderer> ();
						strMesh.vertices = verts.ToArray ();
						strMesh.triangles = groups;
						strMesh.RecalculateNormals ();
						gameObject.GetComponent<MeshFilter> ().mesh = strMesh;
					}
				}
			}
		}
	}
}
