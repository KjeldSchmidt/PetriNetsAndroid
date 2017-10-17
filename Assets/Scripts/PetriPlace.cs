using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetriPlace : MonoBehaviour {
	public int initialTokens;
	public GameObject token;

	private int tokenCount = 0;
	private Queue<GameObject> tokens;

	private static float tokenRadius = 0.74f;

	// Use this for initialization
	void Start () {
		tokenCount = initialTokens;
		tokens = new Queue<GameObject>();
		for ( int i = 0; i < initialTokens; i++ ) {
			createNewToken();
		}
	}
	
	// Update is called once per frame
	void Update () {
		spaceTokens();
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
		createNewToken();
	}

	private void createNewToken() {
		Vector3 randomOffset = Random.insideUnitCircle * 0.01f;
		tokens.Enqueue( Instantiate( token, transform.position + randomOffset, Quaternion.identity ) );
	}

	private void spaceTokens() {
		foreach( GameObject currentToken in tokens ) {
			foreach( GameObject compareToken in tokens ) {
				if ( !Object.ReferenceEquals( currentToken, compareToken ) ) {
					Vector3 displacement = compareToken.transform.position - currentToken.transform.position;
					float magnitude = displacement.magnitude;
					if ( magnitude < tokenRadius ) {
						currentToken.transform.position += -1 * displacement * ( ( tokenRadius - magnitude ) / tokenRadius );
					}
				}
			}
		}
	}
}
