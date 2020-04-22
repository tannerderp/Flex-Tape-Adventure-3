using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//making only the objects close to the player enabled so there's no no lag
public class ObjectLoader : MonoBehaviour
{
    private Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = FindObjectOfType<Camera>();
        Transform[] children = new Transform[transform.childCount];;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            if(Vector2.Distance(child.GetComponent<BoxCollider2D>().ClosestPoint(Camera.transform.position), Camera.transform.position) > Camera.GetComponent<Camera>().orthographicSize * 2) //if the game object is far from the camera, disable it so less lag
            {
                child.gameObject.SetActive(false);
            }
        }

    }

}