using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class pin : MonoBehaviour {
    private AudioSource audio;
    int count = 1; 

    public void makeTriger()
    {
        transform.GetComponent<Collider>().isTrigger = true;
    }

    public bool isStanding; 
	// Use this for initialization
	void Start () {
		isStanding = true;
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

		if(transform.up.y < 0.8f)
        {
            if(count == 1)
            {
                audio.Play();
                count = 0;
            }
            isStanding = false;
            Invoke("makeTriger",2);
        }
	}
 
}
