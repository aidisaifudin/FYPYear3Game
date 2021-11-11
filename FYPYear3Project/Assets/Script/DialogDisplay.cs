using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question> { }
public class DialogDisplay : MonoBehaviour {
    
    public QuestionEvent questionEvent;
    public Conversation conversation;
	public GameObject speakerLeft;
	public GameObject speakerRight;
 

	private SpeakerUI speakerUILeft;

	private SpeakerUI speakerUIRight;

	int activeLineIndex = 0;
    private bool conversationStarted = false;

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

	public void Start() {
		speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
		speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        

		speakerUILeft.Speaker = conversation.speakerLeft;
		speakerUIRight.Speaker = conversation.speakerRight;
        
	}

	public void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
            AdvanceLine();
		}
        else if (Input.GetKeyDown(KeyCode.X))
        {
            EndConversation();
        }
	}

    private void EndConversation()
    {
        conversation = null;
        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
    }
    public void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }
	void AdvanceLine() {
        if (conversation == null)
        {
            return;
        }

        if (!conversationStarted)
        {
            Initialize();
        }

        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
        }
        else
        {
            AdvancedConversation();
        }

	}

	void DisplayLine() {
		Line line = conversation.lines[activeLineIndex];
		//Sprite portrait = conversation.portrait[0];
		Character Character = line.character;

		if(speakerUILeft.SpeakerIs(Character)) {
			SetDialog(speakerUILeft, speakerUIRight, line.text);
		} 
        else 
        {
			SetDialog(speakerUIRight, speakerUILeft, line.text);
		}
        activeLineIndex += 1;
	}
    private void AdvancedConversation()
    {
        // These are really three types of dialog tree node
        // and should be three different objects with a standard interface
        if (conversation.question != null)
        {
            questionEvent.Invoke(conversation.question);
        }
        else if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else
            EndConversation();
            
    }

    void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text) {
		activeSpeakerUI.Dialog = text;
		activeSpeakerUI.Show();
		inactiveSpeakerUI.Hide();

	}

}