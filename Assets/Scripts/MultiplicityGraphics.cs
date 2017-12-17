using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MultiplicityGraphics : MonoBehaviour {
	public Sprite OneGraphic;
	public Sprite TwoGraphic;
	public Sprite ThreeGraphic;

	private SpriteRenderer multiplicityRenderer;


	private void Start() {
		multiplicityRenderer = GetComponent<SpriteRenderer>();
	}

	public void setMultiplicity(int i) {
		Assert.IsTrue(i >= 1 && 1 <= 3);
		if ( i == 1 ) multiplicityRenderer.sprite = OneGraphic;
		if ( i == 2 ) multiplicityRenderer.sprite = TwoGraphic;
		if ( i == 3 ) multiplicityRenderer.sprite = ThreeGraphic;
	}
}
