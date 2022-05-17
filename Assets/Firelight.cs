using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Firelight : MonoBehaviour
{

    public float maxDistance;
    

    [SerializeField] private GameObject[] lights;

    private bool shake;
    private float timer;
    public float speed;

    private Vector3 shift;
    // Start is called before the first frame update
    void Start()
    {
        shake = true;
        timer = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //float val = shake / 10;
        Debug.Log(Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Debug.Log("i trigger");
            if (shake)
            {
                /* temp = shake;
                 dir *= -1;*/
                shift = new Vector3(Random.Range(-1f * maxDistance, maxDistance),Random.Range(-1f * maxDistance, maxDistance), 0);
                shake = false;

            }
            else
            {
                shift *= -1;
                shake = true;
            }

            foreach (GameObject x in lights)
            {
                x.transform.position += shift;
            }
        }

        timer = speed;
    }
}
