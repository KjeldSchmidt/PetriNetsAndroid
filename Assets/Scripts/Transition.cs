using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

	PetriPlace[] inputPlaces;
	PetriPlace[] outputPlaces;




	// Use this for initialization
	void Start () {
		PetriPlace input = GameObject.Find("Input").GetComponent<PetriPlace>();
		PetriPlace output = GameObject.Find("Output").GetComponent<PetriPlace>();
		inputPlaces = new PetriPlace[] { input };
		outputPlaces = new PetriPlace[] { output };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
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
