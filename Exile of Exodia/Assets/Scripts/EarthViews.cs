using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthViews : MonoBehaviour
{
	public Transform Earth;
	public Camera Camera;
	public Vector3 Rotation;
	public bool rotated = false;
    // Update is called once per frame
    void Update()
    {
        if(Camera.enabled == true && rotated == false){
        	Earth.GetComponent<SpinFree>().enabled = false;
        	rotated = true;
            //Earth.Rotate(Rotation.x, Rotation.y, Rotation.z, Space.Self);
            Earth.eulerAngles = Rotation;
        }
        else if(Camera.enabled == false){
        	Earth.GetComponent<SpinFree>().enabled = true;
        	rotated = false;
        }
    }
}
