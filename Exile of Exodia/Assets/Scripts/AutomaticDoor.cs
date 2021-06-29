using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
	public Transform Door;
	public Transform Player;

	private Vector3 original;
	public Vector3 offset;
	public float speed;

	void Start(){
		original = Door.position;
	}
    // Update is called once per frame
    void Update()
    {
    	float distance = Vector3.Distance(Door.position, Player.position);
    	// Debug.Log(distance);
    	if(distance < 8){
    		transform.position = Vector3.MoveTowards(Door.position, original + offset, speed * Time.deltaTime);
    		//Door.position = original + offset;
    	}else{
    		if(Door.position != original){
    			transform.position = Vector3.MoveTowards(Door.position, original, speed * Time.deltaTime);
    			//Door.position = original;
    		}
    	}
        
    }
}
