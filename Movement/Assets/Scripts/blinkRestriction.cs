using UnityEngine;
using System.Collections;

public class blinkRestriction : MonoBehaviour {

	private float blinkOffset;

	void Start(){
		blinkOffset = 0.04f;
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag != "Projectile"){
			Vector3 moveTowards = blinkOffset * (Blink.posAtBlink - this.transform.position).normalized;
		}
	}
}
