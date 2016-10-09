using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	public static Vector3 posAtBlink;
	private float[] blinkDistance;
	private int blinksDone;

	void dash(){

		posAtBlink = transform.position;
		Vector3 dashTowards = Vector3.forward;

		if (movement.direction == movement.directionEnum.LEFT){
			dashTowards = new Vector3 (transform.position.x - blinkDistance [blinksDone % blinkDistance.Length], transform.position.y, 0);
		}
		else if (movement.direction == movement.directionEnum.RIGHT){
			dashTowards = new Vector3 (transform.position.x + blinkDistance [blinksDone % blinkDistance.Length], transform.position.y, 0);
		}
		else if (movement.direction == movement.directionEnum.DOWN){
			dashTowards = new Vector3 (transform.position.x, transform.position.y - blinkDistance [blinksDone % blinkDistance.Length], 0);
		}
		else if (movement.direction == movement.directionEnum.UP){
			dashTowards = new Vector3 (transform.position.x, transform.position.y + blinkDistance [blinksDone % blinkDistance.Length], 0);
		}
		blinksDone++;
		transform.position = dashTowards;
	}

	// Use this for initialization
	void Start () {
		blinkDistance = new float[] { 1f, 2f, 3f };
		blinksDone = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && GemController.gem == GemController.ActiveGem.BLINK && !GameController.instance.isOnDialogue){
			dash ();
		}
	}
}
