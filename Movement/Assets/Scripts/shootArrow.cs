using UnityEngine;
using System.Collections;

public class shootArrow : MonoBehaviour {

	// public variables
	public GameObject arrow;
	public float arrowSpeed;
	public float secondsToFire;
	public short direction; // 0 = right, 1 = up, 2 = left, 3 = down.

	// private variables
	private Rigidbody2D rbArrow;
	private Rigidbody2D rbArrowClone;
	private bool canShoot;

	// Use this for initialization
	void Start () {
		rbArrow = arrow.GetComponent<Rigidbody2D> ();
		canShoot = true;
	}

	// Function that gets called every frame (even before Update).
	void FixedUpdate() {
		StartCoroutine (Fire ());
	}

	// Function that controls the shooting ability of this GameObject.
	IEnumerator Fire() {
		// Checks whether this GameObject can shoot (according to its shooting rate).
		if (canShoot) {
			canShoot = false;

			// An arrow is created at the position of this GameObject.
			rbArrowClone = (Rigidbody2D)Instantiate (rbArrow);
			rbArrowClone.position = (Vector2)this.transform.position;

			// Checks in what the direction the arrow is supposed to point.
			// Gives the corresponding speed to the arrow in the correct direction.
			// Rotates the arrow according to the correct direction.
			switch (direction) {
			case 0:
				rbArrowClone.velocity = new Vector2 (arrowSpeed, 0f);
				break;
			case 1:
				rbArrowClone.velocity = new Vector2 (0f, arrowSpeed);
				rbArrowClone.gameObject.transform.Rotate (0f, 0f, 90f);
				break;
			case 2:
				rbArrowClone.velocity = new Vector2 (-1 * arrowSpeed, 0f);
				rbArrowClone.gameObject.transform.Rotate (0f, 0f, 180f);
				break;
			case 3:
				rbArrowClone.velocity = new Vector2 (0f, -1 * arrowSpeed);
				rbArrowClone.gameObject.transform.Rotate (0f, 0f, 270f);
				break;
			}

			// Destroys the arrow after 1 second.
			// Destroy (rbArrowClone.gameObject, 1);

			// Waits for some time (secondsToFire) to be able to shoot again.
			yield return new WaitForSeconds (secondsToFire);
			canShoot = true;
		}
	}
}
