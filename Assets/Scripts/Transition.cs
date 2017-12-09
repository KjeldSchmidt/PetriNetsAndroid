using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

	[Tooltip("Please leave at 0, thanks.")]
	public Dictionary<PetriPlace, int> inputPlaces = new Dictionary<PetriPlace, int>();
	[Tooltip("Please leave at 0, thanks.")]	
	public Dictionary<PetriPlace, int> outputPlaces = new Dictionary<PetriPlace, int>();




	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		foreach ( KeyValuePair<PetriPlace, int> entry in inputPlaces ) {
			if ( !entry.Key.hasEnoughTokens( entry.Value ) ) {
				return;
			}
		}
		this.fire();
	}

	void fire() {
		foreach ( KeyValuePair<PetriPlace, int> entry in inputPlaces ) {
			entry.Key.takeTokens( entry.Value );
		}

		foreach ( KeyValuePair<PetriPlace, int> entry in outputPlaces ) {
			entry.Key.giveTokens( entry.Value );
		}
	}
}
