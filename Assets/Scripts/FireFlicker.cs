using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlicker : MonoBehaviour
{
    [SerializeField]
    private Transform[] lights;

    private Vector3[] initialLightPositions;
    private Vector2[] lightPerlinOffset;

    public float FlickerDistance = 0.1f;
    public float FlickerFrequency = 1;

    private void Start() 
    {
        initialLightPositions = new Vector3[lights.Length];
        lightPerlinOffset = new Vector2[lights.Length];
        for(int i = 0; i < lights.Length; i++)
        {
            initialLightPositions[i] = lights[i].position;
            lightPerlinOffset[i] = new Vector2(Random.value, Random.value);
        }    
    }

    void Update()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].position = initialLightPositions[i] + new Vector3(Mathf.PerlinNoise(Time.time * FlickerFrequency, - lightPerlinOffset[i].x) - 0.5f, Mathf.PerlinNoise(Time.time * FlickerFrequency, - lightPerlinOffset[i].y) - 0.5f, 0) * FlickerDistance;
        }
    }
}
