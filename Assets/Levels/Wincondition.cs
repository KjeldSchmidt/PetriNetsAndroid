using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wincondition : MonoBehaviour {
	public PetriPlace[] placesToBeEmpty;
	public Object nextLevel;
	public bool haveToUseAllTokens;
	private PlaceableTokenController tokenController;

	// Use this for initialization
	void Start () {
		tokenController = GameObject.FindWithTag("PlaceableTokenController").GetComponent<PlaceableTokenController>();
	}
	
	// Update is called once per frame
	void Update () {
		bool winning = true;
		foreach ( PetriPlace place in placesToBeEmpty ) {
			if ( place.hasToken() ) {
				winning = false;
			}
		}

		





		if ( winning ) {
			SceneManager.LoadScene(nextLevel.name, LoadSceneMode.Single);
		}
	}
}
