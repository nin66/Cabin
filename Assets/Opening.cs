using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] clouds;
    public int[] dir;
    public float timer = 10f;
    public bool tick = false;
    [SerializeField] private Canvas UI;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tick = true;
            Destroy(UI);
            Time.timeScale = 1;
        }

        if (tick)
        {
            timer -= Time.deltaTime;
            for (int i = clouds.Length - 1; i > -1; i--)
            {
                Vector3 move = new Vector3(0.1f*(float)dir[i],0,0);
                clouds[i].transform.Translate(move);
            }
        }

        if (timer < 0)
        {
            for (int i = clouds.Length - 1; i > -1; i--)
            {
                Destroy(clouds[i]);
                tick = false;
            }
        }
    }
}
