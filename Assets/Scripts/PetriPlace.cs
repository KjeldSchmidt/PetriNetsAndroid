using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetriPlace : MonoBehaviour {
	public int initialTokens;
	public GameObject token;

	private int tokenCount = 0;
	private Queue<GameObject> tokens;

	// Use this for initialization
	void Start () {
		tokenCount = initialTokens;
		tokens = new Queue<GameObject>();
		for ( int i = 0; i < initialTokens; i++ ) {
			var newToken = Instantiate( token, new Vector3(-4, 0, 0), Quaternion.identity );
			tokens.Enqueue( newToken );
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void takeToken() {
		if ( tokenCount > 0 ) {
			tokenCount--;
			var oldToken = tokens.Dequeue();
			Destroy( oldToken );
		}
	}

	public void giveToken() {
		tokenCount++;

		Instantiate( token, transform.position, Quaternion.identity );
	}
}
