using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.forward;
        newPos *= 2.5f * Time.deltaTime;
        transform.position += newPos;
    }
}
