using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.forward;
        newPos *= 3.5f * Time.deltaTime;
        transform.position += newPos;
    }
}
