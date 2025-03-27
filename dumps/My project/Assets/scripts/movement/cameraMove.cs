using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

    private Camera cam;
    private Vector3 move=new Vector3(0,0,-10);
    private readonly float maxHorizontal = 8.84f, maxVertical=0f;
    private readonly float maxZoomedHorizontal = 13.3f, maxZoomedVertical = 2.5f;
    private readonly int ZoomStep = 2;
    private float vertical, horizontal;
    private bool zoomed = false;
    [SerializeField]private GameObject up;
    [SerializeField]private GameObject down;

    public void Awake()
    {
        cam=Camera.main;

    }
    void Update()
    {  
        runCam();
    }
    public void runCam()
    {
        if (Input.GetKeyDown("space")){
            if (zoomed) {
                UnZoom();
                this.up.SetActive(false);
                this.down.SetActive(false);
            }
            else
            {
                Zoom();
                this.up.SetActive(true);
                this.down.SetActive(true);
            }
        };
        
        if ((vertical != 0) || (horizontal != 0))
        {

            if (zoomed)
            {
                SetCamMove(maxZoomedHorizontal, maxZoomedVertical);
            }
            else
            {
                SetCamMove(maxHorizontal, maxVertical);
            }
           
        }
    }

    public void SetCamMove(float maxH,float maxV) {
        float verticalstep = cam.transform.position.y + vertical;
        float horizontalstep = cam.transform.position.x + horizontal;
        this.move.y = Mathf.Clamp(verticalstep, -maxV, maxV);
        this.move.x = Mathf.Clamp(horizontalstep, -maxH, maxH);
        cam.transform.position = this.move;
    }
    public void Zoom() {
        cam.orthographicSize = cam.orthographicSize / ZoomStep;
        zoomed = true;
    }
    public void UnZoom()
    {
        cam.orthographicSize = cam.orthographicSize* ZoomStep;
        SetCamMove(maxHorizontal, maxVertical);//zajistuje aby se pri odzoomnuti nedostal hrac mimo povolene bounds
        zoomed = false;
    }

    public void setVert(int vert) {
        this.vertical = (float)vert/5;
    }
    public void setHort(int hort)
    {
        this.horizontal =(float)hort/5;
    }
    public bool getZoomed() {
        return this.zoomed;
    }
}

