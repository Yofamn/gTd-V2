using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class PlyInteract : MonoBehaviour
    {
        private InteractionScript targetInteraction;
        void Update()
        {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        
        targetInteraction = null;
            if (Physics.Raycast(origin, direction, out raycastHit, 100f))
            {
                targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionScript>();
            }
        }
        public void tryInteract()
        {
            if (targetInteraction && targetInteraction.enabled)
            {
                targetInteraction.Interact();
            }
        }
    }
}

