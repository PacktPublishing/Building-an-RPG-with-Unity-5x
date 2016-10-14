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

   public float lookIKWeight = 1.0f;
   public float bodyWeight = 0.7f;
   public float headWeight = 0.9f;
   public float eyesWeight = 1.0f;
   public float clampWeight = 1.0f;

   public Transform lookPosition;

   //public Transform diePosition;
   //public Transform body;

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
      // we can set the look position here somewhere
      Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

      Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 15, Color.cyan);

      //lookPosition.position = ray.GetPoint(15);

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

   /*void FixedUpdate()
   {
      if (this.Die)
      {
         Ray dieRay = new Ray(transform.position + Vector3.up, -Vector3.up);
         RaycastHit dieHit = new RaycastHit();

         //anim.bodyPosition = new Vector3(0, -0.5f, 0);
         if (Physics.Raycast(dieRay, out dieHit))
         {
            if (dieHit.distance > 0.1f)
            {
               anim.MatchTarget(dieHit.point,
                  Quaternion.identity,
                  AvatarTarget.Root,
                  new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
            }
         }

      }
   }*/

   public bool Die = false;
   public void Died()
   {

      Debug.Log("I AM DEAD!");
      this.Die = true;
   }

   void OnAnimatorIK()
   {
      //anim.SetLookAtWeight(lookIKWeight, bodyWeight, headWeight, eyesWeight, clampWeight);
      //anim.SetLookAtPosition(lookPosition.position);

      /*anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikWeight);
      anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikWeight);
      anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftIKTarget.position);
      anim.SetIKPosition(AvatarIKGoal.RightFoot, rightIKTarget.position);

      anim.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, ikWeight);
      anim.SetIKHintPositionWeight(AvatarIKHint.RightKnee, ikWeight);
      anim.SetIKHintPosition(AvatarIKHint.LeftKnee, hintLeft.position);
      anim.SetIKHintPosition(AvatarIKHint.RightKnee, hintRight.position);

      anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, ikWeight);
      anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, ikWeight);
      anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftIKTarget.rotation);
      anim.SetIKRotation(AvatarIKGoal.RightFoot, rightIKTarget.rotation);*/

      leftFootWeight = anim.GetFloat("LeftFoot");
      rightFootWeight = anim.GetFloat("RightFoot");

      anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
      anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
      anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPosition + new Vector3(0f, offsetY, 0f));
      anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPosition + new Vector3(0f, offsetY, 0f));

      /*anim.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, ikWeight);
      anim.SetIKHintPositionWeight(AvatarIKHint.RightKnee, ikWeight);
      anim.SetIKHintPosition(AvatarIKHint.LeftKnee, hintLeft.position);
      anim.SetIKHintPosition(AvatarIKHint.RightKnee, hintRight.position);*/

      anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
      anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);
      anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
      anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);

   }
}
