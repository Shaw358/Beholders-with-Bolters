using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoSingleton<ObjectiveManager>
{
    [SerializeField] List<Objective> objectives = new List<Objective>();
    [SerializeField] int currObjective;

    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] AudioSource sourceSFX;
    [SerializeField] AudioClip typewriterSFX;
    
    private IEnumerator UpdateObjectiveText()
    {
        float delay = .1f;
        currObjective++;
        if (currObjective >= 0)
        {
            objectives[currObjective].onObjectiveCompleted?.Invoke();
        }

        objectiveText.text = "Current Objective: ";

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < objectives[currObjective].description.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            objectiveText.text += objectives[currObjective].description[i];
            sourceSFX.PlayOneShot(typewriterSFX);
        }
    }

    public void NextObjective()
    {
        StartCoroutine(UpdateObjectiveText());
    }
}