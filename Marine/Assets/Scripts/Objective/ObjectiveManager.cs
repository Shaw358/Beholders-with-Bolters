using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoSingleton<ObjectiveManager>
{
    [SerializeField] List<Objective> objectives = new List<Objective>();
    [SerializeField] int currObjective;

    [SerializeField] TextMeshProUGUI objectiveText;

    private IEnumerator UpdateObjectiveText()
    {
        float delay = .03f;
        currObjective++;
        objectives[currObjective].onObjectiveCompleted?.Invoke();

        objectiveText.text = "Current Objective: ";

        for (int i = 0; i < objectives[currObjective].description.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            objectiveText.text += objectives[currObjective].description[i];
        }
    }

    public void NextObjective()
    {
        StartCoroutine(UpdateObjectiveText());
    }
}