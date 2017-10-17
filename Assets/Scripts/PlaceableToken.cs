using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableToken : MonoBehaviour {

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

	//public bool hasPlaceableToken
}
