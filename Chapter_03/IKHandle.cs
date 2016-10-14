using UnityEngine;
using System.Collections;

public class IKHandle : MonoBehaviour
{
   Animator anim;

   public Transform leftIKTarget;
   public Transform rightIKTarget;

   public Transform hintLeft;
   public Transform hintRight;

   public float ikWeight = 1f;

   // to make it dynamic
   Vector3 leftFootPosition;
   Vector3 rightFootPosition;

   Quaternion leftFootRotation;
   Quaternion rightFootRotation;

   float leftFootWeight;
   float rightFootWeight;

   Transform leftFoot;
   Transform rightFoot;

   public float offsetY;

   // Use this for initialization
   void Start()
   {
      anim = GetComponent<Animator>();

      leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
      rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

      leftFootRotation = leftFoot.rotation;
      rightFootRotation = rightFoot.rotation;

   }

   // Update is called once per frame
   void Update()
   {
      RaycastHit leftHit;
      RaycastHit rightHit;

      Vector3 lpos = leftFoot.TransformPoint(Vector3.zero);
      Vector3 rpos = rightFoot.TransformPoint(Vector3.zero);

      if (Physics.Raycast(lpos, -Vector3.up, out leftHit, 1))
      {
         leftFootPosition = leftHit.point;
         leftFootRotation = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
      }

      if (Physics.Raycast(rpos, -Vector3.up, out rightHit, 1))
      {
         rightFootPosition = rightHit.point;
         rightFootRotation = Quaternion.FromToRotation(transform.up, rightHit.normal) * transform.rotation;
      }
   }

   public bool Die = false;
   public void Died()
   {

      Debug.Log("I AM DEAD!");
      this.Die = true;
   }

   void OnAnimatorIK()
   {
      leftFootWeight = anim.GetFloat("LeftFoot");
      rightFootWeight = anim.GetFloat("RightFoot");

      anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
      anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
      anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPosition + new Vector3(0f, offsetY, 0f));
      anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPosition + new Vector3(0f, offsetY, 0f));

      anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
      anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);
      anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
      anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);

   }
}
