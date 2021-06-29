using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
	public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( ( Input.GetButtonDown( "Horizontal" ) || Input.GetButtonDown( "Vertical" ) ) && !audio.isPlaying ) 
        	audio.Play();
    	else if ( !Input.GetButton( "Horizontal" ) && !Input.GetButton( "Vertical" ) && audio.isPlaying )
        	audio.Stop();
    }
}
