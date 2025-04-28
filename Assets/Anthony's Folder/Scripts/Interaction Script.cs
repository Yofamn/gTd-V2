using UnityEngine.Events;
using UnityEngine;

namespace TowerDefence
{
    public class InteractionScript : MonoBehaviour
    {
        public UnityEvent OnInteract = new UnityEvent();
        public void Interact()
        {
            OnInteract.Invoke();
        }
    }
}
