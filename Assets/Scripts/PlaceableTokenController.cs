using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaceableTokenController : MonoBehaviour {

	public int numberOfAvailabeTokens;
	public GameObject tokenPrefab;

	private Stack<GameObject> placeableTokens = new Stack<GameObject>();


	// Use this for initialization
	void Start () {
		for ( int i = 0; i < numberOfAvailabeTokens; i++ ) {
			Vector3 offset = new Vector3(i, 0, 0);
			placeableTokens.Push( Instantiate( tokenPrefab, transform.position + offset, Quaternion.identity ) );
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool hasPlaceableToken() {
		return placeableTokens.Count > 0;
	}

	public GameObject getPlaceableToken() {
		if ( this.hasPlaceableToken() ) {
			return placeableTokens.Pop();
		}

		throw new Exception("You should have checked to see if tokens are available, but you didn't");
	}
}
