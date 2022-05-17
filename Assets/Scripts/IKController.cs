using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    [System.Serializable]
    public enum IKAvatarGroup
    {LeftArm, RightArm, LeftLeg, RightLeg}

    [System.Serializable]
    public class IKSet
    {
        public IKAvatarGroup IKAvatarGroup;
        public Transform IKTarget;
        [Range(0,1)]
        public float IKTargetWeight;
        public Transform IKHint;
        [Range(0,1)]
        public float IKHintWeight;
    }


    private Animator animator;

    [SerializeField]
    private IKSet[] IKTargetSettings;
    [SerializeField]
    private float lerpSpeed = 1;

    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    private void OnAnimatorIK(int layerIndex) 
    {
        if(animator == null)
        {
            return;
        }

        foreach(IKSet ikSet in IKTargetSettings)
        {
            switch(ikSet.IKAvatarGroup)
            {
                case IKAvatarGroup.LeftArm:
                SetIKProp(ikSet, AvatarIKGoal.LeftHand, AvatarIKHint.LeftElbow);
                break;

                case IKAvatarGroup.RightArm:
                SetIKProp(ikSet, AvatarIKGoal.RightHand, AvatarIKHint.RightElbow);
                break;

                case IKAvatarGroup.LeftLeg:
                SetIKProp(ikSet, AvatarIKGoal.LeftFoot, AvatarIKHint.LeftElbow);
                break;

                case IKAvatarGroup.RightLeg:
                SetIKProp(ikSet, AvatarIKGoal.RightFoot, AvatarIKHint.RightKnee);
                break;

                default:
                Debug.LogError("IKAvatarGroup not set, cannot apply IK info.");
                break;
            }
        }
    }

    private void SetIKProp(IKSet ikPropInfo, AvatarIKGoal avatarIKGoal, AvatarIKHint avatarIKHint)
    {
        if(ikPropInfo.IKTarget == null)
        {
            return;
        }
        animator.SetIKPosition(avatarIKGoal, ikPropInfo.IKTarget.position);
        animator.SetIKPositionWeight(avatarIKGoal, ikPropInfo.IKTargetWeight);

        if(ikPropInfo.IKHint == null)
        {
            return;
        }
        animator.SetIKHintPosition(avatarIKHint, ikPropInfo.IKHint.position);
        animator.SetIKHintPositionWeight(avatarIKHint, ikPropInfo.IKHintWeight);
    }

    public void LerpIn()
    {
        StartCoroutine(IKLerpCo(lerpSpeed));
    }

    public void LerpOut()
    {
        StartCoroutine(IKLerpCo(-lerpSpeed));
    }

    private IEnumerator IKLerpCo(float lerpDelta)
    {
        bool ended = false;
        while(!ended)
        {
            foreach(IKSet ikSet in IKTargetSettings)
            {
                ikSet.IKTargetWeight = Mathf.Clamp01(Time.deltaTime * lerpDelta + ikSet.IKTargetWeight);
                ikSet.IKHintWeight = Mathf.Clamp01(Time.deltaTime * lerpDelta + ikSet.IKHintWeight);
            }
            yield return null;
        }
    }
}
