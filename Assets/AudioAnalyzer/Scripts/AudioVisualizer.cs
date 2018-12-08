using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour {

    private GameObject[] _objects = new GameObject[512];
    private GameObject[] _objects2 = new GameObject[512];

    public GameObject m_cubeModel;
    public AudioAnalyser m_audioAnalyser;
    private int radius;
	// Use this for initialization
	void Start () {
        radius = 40;
        //logic for all the cubes
        
        for(int i=0; i < _objects.Length; i++)
        {
            GameObject g = Instantiate(m_cubeModel);
            g.transform.position = new Vector3((float)(radius * Math.Cos(0.012*(i+1))), 0f, (float)(radius * Math.Sin(0.012 * (i + 1))));
            g.transform.parent = transform;
            g.name = "Visualizer cube: " + i;
            _objects[i] = g;
        }
        
        for (int i = 0; (int)Math.Pow(2.0, i) < _objects2.Length; i++)
        {
            GameObject g = Instantiate(m_cubeModel);
            g.transform.position = new Vector3(2 * i, 0f, 0f);
            g.transform.parent = transform;
            g.name = "Visualizer cube: " + i;
            _objects2[i] = g;
        }
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; (int)Math.Pow(2.0,i) < _objects2.Length; i++)
        {
            int k = (int)Math.Pow(2.0, i);
            float sum = 0;
            for(int j=(int)Math.Pow(2.0, i-1); j < k; j++)
            {
                sum += m_audioAnalyser.m_analysedData[j];
            }
            float avg = sum / (float)k;
            GameObject g = _objects2[i];
            Vector3 newPos = g.transform.localScale;
            //newPos.x += 2 * i;
            newPos.y = avg * 500;
            //newPos.z += (float)(radius * Math.Sin(0.012 * (i + 1)));
            //newPos *= Time.deltaTime;
            g.transform.localScale = Vector3.Lerp(g.transform.localScale, newPos, Time.time);
            //g.transform.position = newPos;

            /**
             * logic for all the cubes 
             * 
             */
            /*
           GameObject g = _objects[i];
           Vector3 newPos = Vector3.zero;
           newPos.x += (float)(radius * Math.Cos(0.012 * (i + 1)));
           newPos.y += m_audioAnalyser.m_analysedData[i] * 500;
           newPos.z += (float)(radius * Math.Sin(0.012 * (i + 1)));
           //newPos *= Time.deltaTime;
           g.transform.position = newPos;
           */
        }
        for(int i=0; i< _objects.Length;i++)
        {
            GameObject g = _objects[i];
            Vector3 newPos = Vector3.zero;
            newPos.x += (float)(radius * Math.Cos(0.012 * (i + 1)));
            newPos.y += m_audioAnalyser.m_analysedData[i] * 500;
            newPos.z += (float)(radius * Math.Sin(0.012 * (i + 1)));
            //newPos *= Time.deltaTime;
            g.transform.position = newPos;

        }
    }
}
