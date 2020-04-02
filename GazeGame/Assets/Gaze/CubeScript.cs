using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CameraMode{
    BigCamera,
    MediumCamera,
    SmallCamera,
    NoneCamera
}

public class CubeScript : MonoBehaviour
{
    public GameObject spawnObject;
    
    private GameObject cubeMin;
    private GameObject cubeSmall;
    private GameObject cubeMedium;
    private GameObject cubeBig;

    public Camera cameraSmall;
    public Camera cameraMedium;
    public Camera cameraBig;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPoint = spawnObject.transform.position;
        cubeMin = Instantiate(GameObject.Find("6_poly_obj"), spawnPoint, Quaternion.identity);
        cubeSmall = Instantiate(GameObject.Find("1500_poly_obj"), spawnPoint, Quaternion.identity);
        cubeMedium = Instantiate(GameObject.Find("12k_poly_obj"), spawnPoint, Quaternion.identity);
        cubeBig = Instantiate(GameObject.Find("125k_poly_obj"), spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        hideAllCubes();
        if (isCameraSeeObject(cameraSmall)) {
            cubeBig.GetComponent<Renderer>().enabled = true;
        } else if (isCameraSeeObject(cameraMedium)) {
            cubeMedium.GetComponent<Renderer>().enabled = true;
        } else if (isCameraSeeObject(cameraBig)) {
            cubeSmall.GetComponent<Renderer>().enabled = true;
        } else {
            cubeMin.GetComponent<Renderer>().enabled = true;
        }
    }
    
    void hideAllCubes() {
        cubeBig.GetComponent<Renderer>().enabled = false;
        cubeMedium.GetComponent<Renderer>().enabled = false;
        cubeSmall.GetComponent<Renderer>().enabled = false;
        cubeMin.GetComponent<Renderer>().enabled = false;
    }
    
    bool isCameraSeeObject(Camera camera) {
        Vector3 viewPos = camera.WorldToViewportPoint(spawnObject.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1) {
            return true;
        } else {
            return false;
        }
    }
}
