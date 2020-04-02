using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using System.IO;

public class RayScript : MonoBehaviour
{
	public Camera gazeCamera;
	public Ray gazeRay;

	private int x = 200, y = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/cords.txt");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    
    void UpdateCords() {
        StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCords();
    	gazeRay = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
    	Debug.DrawRay(gazeRay.origin, gazeRay.direction * 10, Color.yellow);		
 		Vector3 direction = gazeRay.direction;
    	gazeCamera.transform.position = Camera.main.transform.position;
    	gazeCamera.transform.rotation = Quaternion.LookRotation(direction);
    }
}
