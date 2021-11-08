using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuestionController : MonoBehaviour
{
    public Question question;
    public Text questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initialized();
    }
    public void Hide(Conversation conversation)
    {
        RemoveChoices();
        gameObject.SetActive(false);

    }
    public void RemoveChoices()
    {
        foreach (ChoiceController c in choiceControllers)
            Destroy(c.gameObject);

        choiceControllers.Clear();
    }
    public void Start() { }

    private void Initialized()
    {
        questionText.text = question.text;

        for(int index = 0; index < question.choices.Length;index++)
        {
            ChoiceController c = ChoiceController.AddChoiceButton(choiceButton, question.choices[index], index);
            choiceControllers.Add(c);
        }
        choiceButton.gameObject.SetActive(false);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
