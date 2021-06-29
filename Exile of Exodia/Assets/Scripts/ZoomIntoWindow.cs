
using UnityEngine;

public class ZoomIntoWindow : MonoBehaviour
{
    public Transform Window;
    public Transform Player;
    public Camera mainCam;
    public Camera targetCam;
    public GameObject Canvas;
    public GameObject SpaceBarCanvas;
    public Light light;
    public float windowRadius = 6;

    private bool clickedSpace;

    void Start(){
        clickedSpace = false;
        mainCam.enabled = true;
        targetCam.enabled = false;
        Canvas.SetActive(false);
        light.enabled=false;
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Window.position, Player.position);
        if(distance < windowRadius){
            SpaceBarCanvas.SetActive(true);
            //Zid zmr to reveal button click request
            if (Input.GetKeyDown(KeyCode.Space) && clickedSpace == false){
                clickedSpace = true;
                mainCam.enabled = false;
                targetCam.enabled = true;
                Canvas.SetActive(true);
                light.enabled=true;
            }
        }
        else
        {
            SpaceBarCanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && clickedSpace == true){
            clickedSpace = false;
            mainCam.enabled = true;
            targetCam.enabled = false;
            Canvas.SetActive(false);
            light.enabled=false;
        }
    }
}

