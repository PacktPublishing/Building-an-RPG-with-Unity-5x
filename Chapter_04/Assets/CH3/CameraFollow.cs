using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

   public float distanceAway;
   public float distanceUp;
   public float smooth;

   public Transform follow;
   public Vector3 targetPosition;

   public bool FOLLOW_ME = false;

   // Use this for initialization
   void Start()
   {
      if(this.FOLLOW_ME)
         this.follow = GameObject.FindGameObjectWithTag("FOLLOW").transform;
   }

   // Update is called once per frame
   void Update()
   {

   }

   void LateUpdate()
   {
      if(this.FOLLOW_ME)
      {
         this.targetPosition = this.follow.position + this.follow.up * this.distanceUp - follow.forward * this.distanceAway;

         transform.position = Vector3.Lerp(transform.position, this.targetPosition, Time.deltaTime * smooth);
         transform.LookAt(this.follow);
      }
   }
}
