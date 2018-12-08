using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyser : MonoBehaviour {

    private AudioSource _audioSource;

    public float[] m_analysedData = new float[512];
    public float[] m_audioSpectrumAverages = new float[10];

    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        _audioSource.GetSpectrumData(m_analysedData, 0, FFTWindow.Hanning);
        getSpectrumAvg();

    }

    private void getSpectrumAvg()
    {
        for (int i = 0; (int)Math.Pow(2.0, i) < 512; i++)
        {
            int k = (int)Math.Pow(2.0, i);
            float sum = 0;
            for (int j = (int)Math.Pow(2.0, i - 1); j < k; j++)
            {
                sum += m_analysedData[j];
            }
            float avg = sum / (float)k;
            m_audioSpectrumAverages[i] = avg;
        }
    }
}
