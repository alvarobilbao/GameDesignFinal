using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumShooter : MonoBehaviour {

    public AudioAnalyser m_audioAnalyser;
    public GameObject m_bullet;
    //reduce the delay to 30 and it will be closer to the actual drum beat, but im using 60 for playablity
    private int shootingDelay = 60;
    private bool isShooting = false;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        float drumIntensity = m_audioAnalyser.m_audioSpectrumAverages[3] * 500;
        //with this values the piano will always fire on the piano sound, however there are some other moments where it will also fire because the spectrum falls in the same harmony
        if (drumIntensity >= 0.5f && drumIntensity < 1.5f && !isShooting)
        {
            //Debug.Log("The drum intensity is " + drumIntensity);
            Shoot();
            isShooting = true;
            shootingDelay = 60;
        }

        if (isShooting && shootingDelay == 0)
            isShooting = false;
        else
            shootingDelay--;
    }

    private void Shoot()
    {
        Quaternion originalRotation = transform.rotation;
        originalRotation.x = 0f;
        originalRotation.z = 0f;
        Instantiate(m_bullet, transform.position, originalRotation);
    }
}
