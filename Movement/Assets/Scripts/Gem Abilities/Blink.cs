using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	public static Vector3 posAtBlink;
	public GameObject blink_checker;
	private float[] blinkDistance;
	private int blinksDone;


    public GameObject gbjYellowRing;

	void dash(){


		Vector3 dashTowards = Vector3.forward;

		//check_blink_target script = checker.GetComponent<check_blink_target> ();
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
		//GameObject checker = (GameObject)Instantiate (blink_checker, transform.position, transform.rotation);
		if (!Physics2D.OverlapCircle(dashTowards,0.08f)) {
			blinksDone++;
			transform.position = dashTowards;
		}

		//Debug.Log (script.can_blink);
	}

	// Use this for initialization
	void Start () {
		
		blinkDistance = new float[] { 2f, 3f, 4f };
		blinksDone = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && GemController.gem == GemController.ActiveGem.BLINK){
			dash ();
            GameObject gbj = (GameObject)Instantiate(gbjYellowRing, this.transform.position, Quaternion.identity);
            gbj.transform.parent = this.transform;

        }
	}
}
