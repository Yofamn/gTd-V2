
using System;
using UnityEngine;
using UnityEngine.Events;


public class InteractionObject : MonoBehaviour
{
   [SerializeField] private string interactionText = "I can be interacted with";

   public UnityEvent OnInteract = new UnityEvent();
   private void OnEnable()
   {

   }
   void Start()
    {
      OnInteract.AddListener(TestListener);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnInteract.Invoke();
        }
    }
   public string GetInteractionText()
   {
    return interactionText;
   }
   void TestListener()
    {
        print("test listener called");
    }

   public void Interact()
   {
      OnInteract.Invoke();
   }

}
