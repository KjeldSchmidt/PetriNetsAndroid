using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetriPlace : MonoBehaviour {
	public int initialTokens;
	public GameObject token;
	public bool canAddTokens;

	private Queue<GameObject> tokens;
	private PlaceableTokenController tokenController;

	private static float tokenRadius = 0.555f;

	// Use this for initialization
	void Start () {
		tokenController = GameObject.FindWithTag("PlaceableTokenController").GetComponent<PlaceableTokenController>();

		tokens = new Queue<GameObject>();
		for ( int i = 0; i < initialTokens; i++ ) {
			createNewToken();
		}
	}
	
	// Update is called once per frame
	void Update () {
		spaceTokens();
	}

	public bool hasToken() {
		return tokens.Count > 0;
	}

	public void takeToken() {
		if ( tokens.Count > 0 ) {
			var oldToken = tokens.Dequeue();
			Destroy( oldToken );
		}
	}

	public void giveToken() {
		createNewToken();
	}

	private void createNewToken() {
		Vector3 randomOffset = Random.insideUnitCircle * 0.1f;
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

	void OnMouseDown() {
		if ( canAddTokens ) {
			getTokenFromController();
		}
	}

	private void getTokenFromController() {
		if ( tokenController.hasPlaceableToken() ) {
			GameObject aquiredToken = tokenController.getPlaceableToken();
			Vector3 randomOffset = Random.insideUnitCircle * 0.01f;
			aquiredToken.transform.position = transform.position + randomOffset;
			tokens.Enqueue( aquiredToken );
		}
	}


}
