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
    public GameObject cubeMinFather;
    public GameObject cubeSmallFather;
    public GameObject cubeMediumFather;
    public GameObject cubeBigFather;
    
    public GameObject spawnObject;
    
    private GameObject cubeMin;
    private GameObject cubeSmall;
    private GameObject cubeMedium;
    private GameObject cubeBig;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPoint = spawnObject.transform.position;
        cubeMin = Instantiate(cubeMinFather, spawnPoint, Quaternion.identity);
        cubeSmall = Instantiate(cubeSmallFather, spawnPoint, Quaternion.identity);
        cubeMedium = Instantiate(cubeMediumFather, spawnPoint, Quaternion.identity);
        cubeBig = Instantiate(cubeBigFather, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
