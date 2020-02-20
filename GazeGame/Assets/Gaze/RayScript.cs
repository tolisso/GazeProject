using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
	public Camera gazeCamera;
	public Ray gazeRay;

	private int x = 200, y = 200;
    // Start is called before the first frame update
    void Start()
    {
		   
    }

    // Update is called once per frame
    void Update()
    {
    	gazeRay = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
    	
 		Vector3 direction = gazeRay.direction;
    	gazeCamera.transform.position = Camera.main.transform.position;
    	gazeCamera.transform.rotation = Quaternion.Euler(direction[0], direction[1], 0);
    }
}
