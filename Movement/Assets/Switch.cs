using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Switch!");
        if (other.gameObject.tag == "Object")  
        {
            if(this.transform.tag == "Switch1")
            {
                FreePull.instance.bSwitch1 = true;
            }
            else if (this.transform.tag == "Switch2")
            {
                FreePull.instance.bSwitch2 = true;
            }

        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
       
        /*if (other.gameObject.tag == "Object")
        {
            if (this.transform.tag == "Switch1")
            {
                FreePull.instance.bSwitch1 = false;
            }
            else if (this.transform.tag == "Switch2")
            {
                FreePull.instance.bSwitch2 = false;
            }

        }*/

    }


}
