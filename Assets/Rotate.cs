using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private Transform transform;
    public Vector3 rotation;

	// Use this for initialization
	void Start ()
	{
	    transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotation);
	}
}
