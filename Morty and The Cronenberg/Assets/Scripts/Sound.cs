using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [Range(0f, 1f)]
    public static float volume = 1f;

    // Update is called once per frame
    void Update()
    {
    }

    public void getVolume(float vol)
    {
        volume = vol;
    }

}
