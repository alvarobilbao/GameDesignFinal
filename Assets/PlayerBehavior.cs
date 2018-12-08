using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public int m_life;
    [Range(1f,6f)]
    public float m_speed;
    // Use this for initialization
    private bool _isJumping = false;
    private bool _isFalling = false;
    private int jumpDuration;
    private int jumpConstant = 15;
    private float jumpHeight = 2f;

    void Start () {
        jumpDuration = jumpConstant;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
        Jump();
    }

    private void Move()
    {
        Vector3 newPos = Vector3.zero;
        newPos.x += Input.GetAxis("Horizontal");
        newPos.z += Input.GetAxis("Vertical");
        newPos *= m_speed;
        newPos *= Time.deltaTime;

        transform.position += newPos;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && !_isFalling)
        {
            _isJumping = true;
            Debug.Log("JUMP");
        }

        if (_isFalling && jumpDuration < jumpConstant)
        {
            Vector3 newPos = Vector3.zero;
            newPos.y -= jumpHeight / (float)jumpConstant;
            transform.position += newPos;
            jumpDuration++;
        }
        else if (_isFalling && jumpDuration >= jumpConstant)
        {
            _isFalling = false;
        }

        if (_isJumping && jumpDuration > 0)
        {
            Vector3 newPos = Vector3.zero;
            newPos.y += jumpHeight / (float)jumpConstant;
            transform.position += newPos;
            jumpDuration--;
        } else if(_isJumping && jumpDuration <= 0)
        {
            _isJumping = false;
            _isFalling = true;
        }
        
    }

    private void Rotate()
    {
        Vector3 newRot = Vector3.zero;
        newRot.x += Input.GetAxis("Horizontal");
        newRot.z += Input.GetAxis("Vertical");

        if (newRot != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(newRot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {

            m_life--;
            Debug.Log("life remaining = " + m_life);
            if (m_life <= 0)
                Destroy(gameObject);

        }

    }
}
