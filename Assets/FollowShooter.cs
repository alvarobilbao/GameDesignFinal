using System;
using UnityEngine;

public class FollowShooter : MonoBehaviour {

    public GameObject m_bullet;
    public GameObject m_Player;
    public AudioAnalyser m_audioAnalyser;
    private bool isShooting = false;
    private int shootingDelay = 5;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SearchPlayer();
        float bassIntensity1 = m_audioAnalyser.m_audioSpectrumAverages[0] * 500;
        float bassIntensity2 = m_audioAnalyser.m_audioSpectrumAverages[1] * 500;
        float bassIntensity3 = m_audioAnalyser.m_audioSpectrumAverages[2] * 500;
        if (bassIntensity1 > 50 && bassIntensity2 > 50 && bassIntensity3 > 30 && !isShooting)
        {
            //Debug.Log("The bassIntensity1 is " + bassIntensity1);
            //Debug.Log("The bassIntensity2 is " + bassIntensity2);
            //Debug.Log("The bassIntensity3 is " + bassIntensity3);
            Shoot();
            isShooting = true;
            shootingDelay = 5;
        }
        if (isShooting && shootingDelay == 0)
            isShooting = false;
        else
            shootingDelay--;
    }

    private void SearchPlayer()
    {
        transform.LookAt(m_Player.transform);
    }

    private void Shoot()
    {
        Instantiate(m_bullet, transform.position, transform.rotation);
    }
}
