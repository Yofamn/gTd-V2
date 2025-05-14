using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
//using Palmmedia.ReportGenerator.Core.Parser.Analysis;


public class objectivescript: MonoBehaviour
{
    [SerializeField] private Text ObjectiveDisplay;
    [SerializeField] private string objectiveText = "I am an objective!";
    [SerializeField] private string completedText = "youve completed an objective";
    public UnityEvent OnCompleteObjective = new UnityEvent();
    private void OnEnable()
    {
        ObjectiveDisplay.text = objectiveText; 
    }
    public void CompleteObjective()
    {
        if(gameObject.activeSelf)
        {
            ObjectiveDisplay.text = "";
            OnCompleteObjective.Invoke();
            gameObject.SetActive(false);
        }
        
    }

}
