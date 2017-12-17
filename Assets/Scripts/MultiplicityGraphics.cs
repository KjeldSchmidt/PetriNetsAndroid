using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MultiplicityGraphics : MonoBehaviour {
	public Sprite OneGraphic;
	public Sprite TwoGraphic;
	public Sprite ThreeGraphic;

	public int spriteRef;

	private SpriteRenderer multiplicityRenderer;


	private void Start() {
		multiplicityRenderer = GetComponent<SpriteRenderer>();
	}

	public void setMultiplicity(int i) {
		Assert.IsTrue(i >= 1 && 1 <= 3);
		spriteRef = i;
	}

	public void applyMultiplicity() {
		if ( spriteRef == 1 ) multiplicityRenderer.sprite = OneGraphic;
		if ( spriteRef == 2 ) multiplicityRenderer.sprite = TwoGraphic;
		if ( spriteRef == 3 ) multiplicityRenderer.sprite = ThreeGraphic;
	}
}
