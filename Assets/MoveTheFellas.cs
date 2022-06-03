using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;

public class MoveTheFellas : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float speed2;
    [SerializeField] private float rotation;
    private Vector3 temp;
    [SerializeField] private Transform pup;
    [SerializeField] private Transform pin;
    private Quaternion fix;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
    //`[SerializeField] private PlayableDirector director;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 1;
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            if (rotation < 0.1 || rotation > 0.9)
            {
                
            }
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f,0f);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 0f,speed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f,0f);
        }*/
        temp = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f,speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f,0f);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 0f,speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f,0f);
            
        }

        temp = transform.position - temp;
        if (temp != Vector3.zero)
        {
            fix = quaternion.LookRotation(temp, Vector3.up);
            //fix = new Quaternion(fix.x, fix.y, 180f, fix.w);
            pup.rotation = Quaternion.Lerp(pup.rotation,fix, Time.deltaTime*speed2);
            //pin.rotation = Quaternion.Lerp(pin.rotation, fix, Time.deltaTime * speed2);
            //transform.rotation = Quaternion.Lerp(pin.rotation, fix, Time.deltaTime * speed2);
            anim.SetBool("Run",true);
            anim2.SetBool("Run",true);
        }
        else
        {
            //Time.timeScale = 0;
            anim.SetBool("Run",false);
            anim2.SetBool("Run",false);
        }
    }
}
