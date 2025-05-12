
/*using System;
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

} */
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "Press E to interact";  // Text to show when the object is looked at
    [SerializeField] private string sceneToLoad;  // The scene to load
    [SerializeField] private float interactionRange = 5f;  // How far the player can interact with the object

    public UnityEvent OnInteract = new UnityEvent();

    private Camera playerCamera;  // The player's camera

    private void Start()
    {
        playerCamera = Camera.main;  // Get the player's main camera
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera not found!");
        }

        OnInteract.AddListener(TestListener);
        OnInteract.AddListener(LoadScene);  // Add the scene loading listener
    }

    private void Update()
    {
        if (IsLookingAtObject() && Input.GetKeyDown(KeyCode.E))  // Only interact when looking at the object
        {
            OnInteract.Invoke();
        }
    }

    private bool IsLookingAtObject()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);  // Create a ray from the camera to where the player is looking
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))  // Check if the ray hits something within the interaction range
        {
            if (hit.collider.CompareTag("Interactable"))  // Make sure the object has the correct tag (e.g., "Interactable")
            {
                return true;
            }
        }
        return false;
    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    void TestListener()
    {
        print("Test listener called");
    }

    public void Interact()
    {
        OnInteract.Invoke();
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene specified to load!");
        }
    }
}

