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

	public bool hasEnoughTokens(int numberToTake) {
		return tokens.Count >= numberToTake;
	}

	public void takeTokens(int numberToTake) {
		if ( tokens.Count >= numberToTake ) {
			for ( int i = 0; i < numberToTake; i++ ) {
				var oldToken = tokens.Dequeue();
				Destroy( oldToken );
			}
		}
	}

	public void giveTokens(int numberToCreate) {
		for ( int i = 0; i < numberToCreate; i++ ) {
			createNewToken();
		}
	}

	private void createNewToken() {
		Vector3 randomOffset = Random.insideUnitCircle * 0.1f;
		Vector3 tokenPosition = new Vector3(transform.position.x, transform.position.y, -1);
		tokens.Enqueue( Instantiate( token, tokenPosition + randomOffset, Quaternion.identity ) );
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
			Vector3 inFront = new Vector3(0, 0, -1);
			aquiredToken.transform.position = transform.position + randomOffset + inFront;
			tokens.Enqueue( aquiredToken );
		}
	}


}
