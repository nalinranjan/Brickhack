using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	private Renderer renderer;
	private int health;

	void Start () {
		health = 2;
		renderer = gameObject.GetComponent<Renderer> ();
	}

	public void hit() {
		health--;
		if (health == 0) {
			Destroy (gameObject, 0.1f);
		}
		renderer.material.SetColor ("_Color", Color.gray);
	}
}
