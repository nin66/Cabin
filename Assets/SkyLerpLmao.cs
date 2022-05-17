using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLerpLmao : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Material day;
    [SerializeField] private Material night;
    [SerializeField] private bool lerp;
    private Material Storage;
    public float x;
    public float speed;
    void Start()
    {
        lerp = false;
        Storage = day;
    }

    // Update is called once per frame
    void Update()
    {
        if (lerp)
        {
            x += Time.deltaTime*speed;
            RenderSettings.skybox.Lerp(day,night,x);
        }

        
    }
}
