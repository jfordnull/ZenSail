using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Material waveMaterial;
    public static Wave instance;

    Vector4 wA, wB, wC;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        UpdateWave();
    }

    public void UpdateWave()
    {
        wA = waveMaterial.GetVector("_WaveA");
        wB = waveMaterial.GetVector("_WaveB");
        wC = waveMaterial.GetVector("_WaveC");
    }

    public float GetHeight(float x, float z)
    {
        Vector3 p = new Vector3(x,0,z);
        float y = 0;
        y += GerstnerWave(wA, p);
        y += GerstnerWave(wB, p);
        y += GerstnerWave(wC, p);
        return y;
    }

    float GerstnerWave(Vector4 wave, Vector3 point)
    {
        float s = wave.z;
        float k = (2 * Mathf.PI) / wave.w;
        float c = Mathf.Sqrt(Mathf.Abs(Physics.gravity.y) / k);
        float a = s / k;
        Vector2 d = new Vector2(wave.x, wave.y);
        d.Normalize();
        float dot = Vector2.Dot(d, new Vector2(point.x, point.y));
        float f = k * (dot - c * Time.time);
        return a * Mathf.Sin(f);
    }
}
