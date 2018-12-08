using System;
using UnityEngine;

public class PianoShooter : MonoBehaviour {

    public AudioAnalyser m_audioAnalyser;
    public GameObject m_laser;
    private int shootingDelay=30;
    private bool isShooting = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float pianoIntensity = m_audioAnalyser.m_audioSpectrumAverages[4] * 500;
        //with this values the piano will always fire on the piano sound, however there are some other moments where it will also fire because the spectrum falls in the same harmony
        if (pianoIntensity >= 2.6f && pianoIntensity <= 3.1f && !isShooting)
        {
            //Debug.Log("The piano intensity is " + pianoIntensity);
            Shoot();
            isShooting = true;
            shootingDelay = 30;
        }

        if (isShooting && shootingDelay == 0)
            isShooting = false;        
        else
            shootingDelay--;

    }

    

    private void Shoot()
    {
        Instantiate(m_laser, transform.position, m_laser.transform.rotation);
    }
}
