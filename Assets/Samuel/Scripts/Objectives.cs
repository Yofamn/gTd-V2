using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private Text objectiveDisplay;
    [SerializeField] private string objectiveText = "I am an objective!!";
    [SerializeField] private string completedObjective = "Wahoo! You've completed an objective!";

    public UnityEvent OnCompleteObjective = new UnityEvent();

    private void OnEnable()
    {
        objectiveDisplay.text = objectiveText;
    }

    public void CompleteObjective()
    {
        if (gameObject.activeSelf)
        {
            objectiveDisplay.text = "";

            OnCompleteObjective.Invoke();

            gameObject.SetActive(false);
        }
    }
}
