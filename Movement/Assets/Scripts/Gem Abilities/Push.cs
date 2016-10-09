using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour {

	public float pushSpeed;
	public float maxDistance;
	private Vector2 pushTowards;

	public static GameObject objectPushed;

	void setObject(){
		Vector2 rayStart;
		Vector2 rayDirection;

		// Calculate ray direction
		if (movement.direction == movement.directionEnum.RIGHT){
			rayStart = new Vector2 (transform.position.x + 1.5f, transform.position.y);
			rayDirection = Vector2.right;
		}
		else if (movement.direction == movement.directionEnum.LEFT){
			rayStart = new Vector2 (transform.position.x - 1.5f, transform.position.y);
			rayDirection = Vector2.left;
		}
		else if (movement.direction == movement.directionEnum.UP){
			rayStart = new Vector2 (transform.position.x, transform.position.y + 1.5f);
			rayDirection = Vector2.up;
		}
		else {
			rayStart = new Vector2 (transform.position.x, transform.position.y - 1.5f);
			rayDirection = Vector2.down;
		}

		RaycastHit2D hit = Physics2D.Raycast (rayStart, rayDirection, maxDistance);

		if (hit.transform != null){
			if (hit.transform.gameObject.tag == "Projectile"){
				Destroy (hit.transform.gameObject);
			}
			else if (hit.transform.gameObject.tag == "Object"){
				objectPushed = hit.transform.gameObject;
				objectPushed.GetComponent<Rigidbody2D> ().isKinematic = false;
				pushTowards = (objectPushed.transform.position - transform.position);
			}
		}
	}

	void pushObject(){
		if (objectPushed != null && objectPushed.tag == "Object"){
			objectPushed.GetComponent<Rigidbody2D> ().velocity += (pushTowards * pushSpeed * Time.deltaTime);
		}
	}

	// Use this for initialization
	void Start () {
		pushSpeed = 0.3f;
		maxDistance = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GemController.gem == GemController.ActiveGem.PULL_PUSH && !GameController.instance.isOnDialogue){
			if(Input.GetKeyDown(KeyCode.P)){
				setObject ();
			}

			if(objectPushed != null){
				pushObject ();
			}
		}
	}
}
