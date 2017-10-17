using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

	public PetriPlace[] inputPlaces;
	public PetriPlace[] outputPlaces;




	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		foreach ( PetriPlace input in inputPlaces ) {
			if ( !input.hasToken() ) {
				return;
			}
		}
		this.fire();
	}

	void fire() {
		foreach ( PetriPlace input in inputPlaces ) {
			input.takeToken();
		}

		foreach ( PetriPlace output in outputPlaces ) {
			output.giveToken();
		}
	}
}
