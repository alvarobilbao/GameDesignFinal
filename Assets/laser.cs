using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x += 3f * Time.deltaTime;
        newPos.z -= 3f * Time.deltaTime;
        transform.position = newPos;

    }
}
