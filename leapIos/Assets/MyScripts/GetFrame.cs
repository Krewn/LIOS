using UnityEngine;
using System.Collections;
using Leap;

public class GetFrame : MonoBehaviour {
	private LeapManager manager;													//This provides access to leap data
	public Leap.Frame frame;														//this is a home for leap data
	private Leap.Controller controller;												//This interprites the data stream
	private Leap.Listener listener;													//This is the data stream
										// Use this for initialization
	void Start () {
		manager = Camera.main.GetComponent<LeapManager>();							//This links to some leap data
		listener   = new Leap.Listener ();											//initializes the listener
		controller = new Leap.Controller ();										//Initializes the controler
		controller.AddListener (listener);											//Pipes the listener stream into the controler
	}
	
										// Update is called once per frame
	void Update () {
		if(controller.IsConnected)//controller is a Controller object
		{
			frame = controller.Frame();												//Puts the controler information into the frame for export
		}																			//to other scripts
	}
}
																					/*	scripts using this frame data
																					 * BIDT.cs
																					 * LClic.cs
																					 * RClic.cs
																					 * IsClic.cs //all instances
																					 */
