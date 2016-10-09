using UnityEngine;
using System.Collections;

public class panelCollision : MonoBehaviour {

	public Sprite panelOn;

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Projectile"){
			if (this.gameObject == Level_Pull2.Panel1 && !Level_Pull2.hitPanel1){
				Level_Pull2.Panel1.GetComponent<SpriteRenderer> ().sprite = panelOn;
				if(Level_Pull2.panelsHitted == 0){
					Level_Pull2.firstPanelHit = Time.time;
				}
				Level_Pull2.hitPanel1 = true;
				Level_Pull2.panelsHitted++;
			}
			else if (this.gameObject == Level_Pull2.Panel2 && !Level_Pull2.hitPanel2){
				Level_Pull2.Panel2.GetComponent<SpriteRenderer> ().sprite = panelOn;
				if(Level_Pull2.panelsHitted == 0){
					Level_Pull2.firstPanelHit = Time.time;
				}
				Level_Pull2.hitPanel2 = true;
				Level_Pull2.panelsHitted++;
			}
			else if (this.gameObject == Level_Pull2.Panel3 && !Level_Pull2.hitPanel3){
				Level_Pull2.Panel3.GetComponent<SpriteRenderer> ().sprite = panelOn;
				if(Level_Pull2.panelsHitted == 0){
					Level_Pull2.firstPanelHit = Time.time;
				}
				Level_Pull2.hitPanel3 = true;
				Level_Pull2.panelsHitted++;
			}
		}
	}
}
