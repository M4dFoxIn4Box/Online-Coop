using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = false; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;
        public float cdInitial = 10 ;
        private float cdActive;
        private bool boostOff = false;
        public float boostMultiplier;


        private void Start()
        {
            cdActive = cdInitial;
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }

        void Update (){
            //BoostCooldown ();
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }

     /*public void BoostOn (){
     	if (boostOff == false){
        m_MovePower *= boostMultiplier;
    }
        cdActive = cdInitial;

    }

    void BoostOff (){
        m_MovePower /= boostMultiplier;
        cdActive = cdInitial;
        boostOff = false;
    }
    public void BoostBoolCooldown (){
        if (cdActive == cdInitial && boostOff == false){
        	boostOff = true;
        }
    }
    public void BoostCooldown (){
    	if (boostOff == true){
            cdActive -= Time.deltaTime;
    	}
        if (cdActive <= 0)
        {
            BoostOff(); 
        }
    }*/
}
}
