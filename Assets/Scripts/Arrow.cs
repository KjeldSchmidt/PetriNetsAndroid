using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public PetriPlace place;
	public Transition transition;
	public Direction direction;
	[Tooltip("How many tokens are consumed/given by this arrow? Usually should be ~1-4 (definitely >= 1")]
	public int multiplicity = 1;

	public enum Direction {In, Out};

	private Transform input;
	private Transform output;
	private Transform arrowLine;
	private Transform arrowHead;

	private float baseLength = 2.0f; // This is the length of the arrowLine, excluding the head(!), before scaling is applied. This depends on illustrator settings.

	private float absoluteLength;
	private float scale;
	private float angle;
	private Vector3 absoluteStartPosition; // This is equal to the center of the input to this arrow (a place for input, transition for output)
	private Vector3 absoluteEndPosition;   // This is equal to the center of the output of this arrow
	private Vector3 EndPosition;           // This is where the arrowHead will eventually point to.


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

		transform.position = new Vector3(input.position.x + scale, input.position.y, 1);

		angle = getAngle(input, output);

		transform.RotateAround(input.position, Vector3.forward, -angle);

		shortenLine(angle);

		registerWithTransition();
	}

	/*
	*	At the point of calling, the line will be extended from the midpoint of input to the midpoint of output
	*	For input, this is fine, since the excess line is just hidden behind it. For output, it is not; The arrowhead gets hidden
	*	Unfortunately, fixing this is only easy if this is outgoing (since the target is a circle and the angle doesn't matter)
	*	If this is an input to a transition, we have to do some trig, and also check multiple cases.
	*	Not implemented yet is the case where a place is beneath a transition, rather than to the side.
	*/
	void shortenLine(float angle) {
		// Case 1: Arrowhead going into a Place/Circle
		float scale = arrowHead.localPosition.x;
		if ( direction == Direction.Out ) {
			arrowHead.localPosition = new Vector3(scale-1.4f, 0, 0);	
		} else {
			arrowHead.localPosition = new Vector3(scale-0.65f, 0, 0);	
		}

	}

	float getAngle(Transform point1, Transform point2) {
		float x1 = point1.position.x;
		float x2 = point2.position.x;
		float y1 = point1.position.y;
		float y2 = point2.position.y;
		float dx = Mathf.Abs(x2 - x1);
		float dy = Mathf.Abs(y2 - y1);
		float angle = -Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
		angle = (y1 < y2) ? angle : -angle;
		angle = (x1 < x2) ? angle : 180-angle;
		return angle;
	}

	void registerWithTransition() {
		if ( direction == Direction.In ) {
			this.transition.inputPlaces.Add( this.place );
		}

		if ( direction == Direction.Out ) {
			this.transition.outputPlaces.Add( this.place );
		}
	}
}
