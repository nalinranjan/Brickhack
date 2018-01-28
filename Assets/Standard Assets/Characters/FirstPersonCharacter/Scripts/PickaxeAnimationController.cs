using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeAnimationController : MonoBehaviour {

	private Animation attackAnimation;
	private ParticleSystem hitParticles;
	private GameObject overlay;
	private bool newAttack;

	private void Start() {
		attackAnimation = GetComponent<Animation> ();
		hitParticles = GetComponentInChildren<ParticleSystem> ();
		newAttack = false;
		overlay = GameObject.Find ("WinOverlay");
		overlay.SetActive (false);
	}

	public void attack() {
		newAttack = true;
		attackAnimation.Play ();
	}

	private void OnCollisionEnter (Collision col) {
		print ("Collided");
		if (attackAnimation.isPlaying && col.gameObject.name == "JohnWall") {
			Destroy (col.gameObject);
		}
	}

	public void collide (GameObject obj) {
		if (attackAnimation.isPlaying && newAttack) {
			hitParticles.Play ();
			if (obj.GetComponent<WallController> ()) {
				obj.GetComponent<WallController> ().hit ();
				StartCoroutine (WinCondition ());
			}
			newAttack = false;
		}
	}

	private IEnumerator WinCondition() {
		yield return new WaitForSeconds (0.1f);

		if (GameObject.FindGameObjectsWithTag ("Wall").Length == 0) {
			overlay.SetActive (true);
		}
	}
}
