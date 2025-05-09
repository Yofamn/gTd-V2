using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
   [SerializeField] private string interactionText = "Press e to interact";

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
        if(Input.GetKeyDown(KeyCode.Return))
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
