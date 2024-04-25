using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMN.Player
{
    public class Player : MonoBehaviour
    {

        private CharacterController character;
        private float gravity = -9.81f;
        private Vector3 pVelocity = new Vector3(0f,0f,0f);

        // Start is called before the first frame update
        void Start()
        {
            character = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            var onGround = character.isGrounded;
            Vector3 playerMove = Vector3.zero;
            var inputStrength = Input.GetAxis("Vertical");
            if(inputStrength != 0)
            {
                playerMove = transform.forward * inputStrength;
            }
            
            Vector3 playerRot = new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime, 0);

            character.Move(playerMove * Time.deltaTime * 6f);

            transform.Rotate(playerRot * 132f);

            if(onGround && pVelocity.y < 0)
            {
                pVelocity.y = 0f;
            } 
            if (onGround && Input.GetButton("Jump"))
            {
                pVelocity.y += 6f;
            }

            pVelocity.y += gravity * Time.deltaTime;

            character.Move(pVelocity * Time.deltaTime);


        }

    }
}


