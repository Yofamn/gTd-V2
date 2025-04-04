using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefence
{
    public class PlayerMovement : MonoBehaviour
   {
        CharacterController characterController;
        public float moveSpeed = 5f;
        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            float rightInput = Input.GetAxis("Horizontal");

            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 moveDirection = (forwardInput * forward) + (rightInput* right);
            moveDirection.Normalize();
            moveDirection.y = -1f;

            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

   }
}
