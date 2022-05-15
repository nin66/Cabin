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

    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    private void OnAnimatorIK(int layerIndex) 
    {
        foreach(IKSet ikSet in IKTargetSettings)
        {
            switch(ikSet.IKAvatarGroup)
            {
                case IKAvatarGroup.LeftArm:
                animator.SetIKPosition(AvatarIKGoal.LeftHand, ikSet.IKTarget.position);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikSet.IKTargetWeight);
                if(ikSet.IKHint != null)
                {
                    animator.SetIKHintPosition(AvatarIKHint.LeftElbow, ikSet.IKHint.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, ikSet.IKHintWeight);
                }
                break;

                case IKAvatarGroup.RightArm:
                animator.SetIKPosition(AvatarIKGoal.RightHand, ikSet.IKTarget.position);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, ikSet.IKTargetWeight);
                if(ikSet.IKHint != null)
                {
                    animator.SetIKHintPosition(AvatarIKHint.RightElbow, ikSet.IKHint.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, ikSet.IKHintWeight);
                }
                break;

                case IKAvatarGroup.LeftLeg:
                animator.SetIKPosition(AvatarIKGoal.LeftFoot, ikSet.IKTarget.position);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikSet.IKTargetWeight);
                if(ikSet.IKHint != null)
                {
                    animator.SetIKHintPosition(AvatarIKHint.LeftKnee, ikSet.IKHint.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, ikSet.IKHintWeight);
                }
                break;

                case IKAvatarGroup.RightLeg:
                animator.SetIKPosition(AvatarIKGoal.RightFoot, ikSet.IKTarget.position);
                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikSet.IKTargetWeight);
                if(ikSet.IKHint != null)
                {
                    animator.SetIKHintPosition(AvatarIKHint.RightKnee, ikSet.IKHint.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, ikSet.IKHintWeight);
                }
                break;

                default:
                Debug.LogError("IKAvatarGroup not set, cannot apply IK info.");
                break;
            }
        }
    }
}
