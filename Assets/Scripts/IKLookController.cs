using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKLookController : MonoBehaviour
{
    private Animator animator;

    public Transform IKLookTarget;
    public float IKLookWeight;
    public float lerpSpeed = 1;

    private Coroutine activeLerp;

    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    private void OnAnimatorIK(int layerIndex) 
    {
        animator.SetLookAtPosition(IKLookTarget.position);
        animator.SetLookAtWeight(IKLookWeight);
    }

    public void LerpIn()
    {
        SetIKLerp(IKLerpCo(lerpSpeed));
    }

    public void LerpOut()
    {
        SetIKLerp(IKLerpCo(-lerpSpeed));
    }

    private void SetIKLerp(IEnumerator LerpCo)
    {
        if(activeLerp != null)
        {
            StopCoroutine(activeLerp);
        }
        activeLerp = StartCoroutine(LerpCo);
    }

   private IEnumerator IKLerpCo(float lerpDelta)
    {
        bool ended = false;
        float targetWeight = 0;
        if(lerpDelta >= 0)
        {
            targetWeight = 1;
        }
        else
        {
            targetWeight = 0;
        }
        while(!ended)
        {
            ended = true;
            
            IKLookWeight = Mathf.Clamp01(Time.deltaTime * lerpDelta + IKLookWeight);
            if(!Mathf.Approximately(IKLookWeight, targetWeight))
                ended = false;
            
            yield return null;
        }
    }
}
