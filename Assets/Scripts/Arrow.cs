using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public PetriPlace place;
	public Transition transition;
	public Direction direction;

	public enum Direction {In, Out};

	private Transform input;
	private Transform output;
	private Transform arrowLine;
	private Transform arrowHead;

	private float baseLength = 2.0f; // This is the length of the arrowLine, excluding the head(!), before scaling is applied. This depends on illustrator settings.

	private float absoluteLength;
	private float scale;
	private Vector3 absoluteStartPosition; // This is equal to the center of the input to this arrow (a place for input, transition for output)
	private Vector3 absoluteEndPosition;   // This is equal to the center of the output of this arrow
	private Vector3 EndPosition;           // This is where the arrow 


	// Use this for initialization
	void Start () {
		arrowHead = transform.GetChild(0);
		arrowLine = transform.GetChild(1);
		input = (direction == Direction.In) ? place.transform : transition.transform;
		output = (direction == Direction.Out) ? place.transform : transition.transform;
		absoluteLength = Vector3.Distance(input.position, output.position);
		scale = absoluteLength/baseLength;

		arrowLine.localScale = new Vector3(scale, 1, 1);
		arrowHead.localPosition = new Vector3(scale, 0, 0);

		transform.position = new Vector3(input.position.x + scale, input.position.y, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
