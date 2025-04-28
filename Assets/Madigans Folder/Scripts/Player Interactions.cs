using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    
    [SerializeField] private float maxDistance = 2f;
    [SerializeField]private Text interactableName;
    private InteractionObject targetInteraction;
    void Update()
    {
        Vector3 orgin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        //string objectName = " "; 
        string intractionText = "";
        targetInteraction = null; 
        if (Physics.Raycast(orgin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
        }

        if(targetInteraction && targetInteraction.enabled)
        {
            intractionText = targetInteraction.GetInteractionText();
        }
        SetInteractableNameText(intractionText);
    }

    private void SetInteractableNameText(string newText)
    {
        if(interactableName)
        {
            interactableName.text = newText;
        }
    }
    public void TryInteract()
    {
        if(targetInteraction && targetInteraction.enabled)
        {
            targetInteraction.Interact();
        }
    }
}
