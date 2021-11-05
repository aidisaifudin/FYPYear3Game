using UnityEngine;

public class DialogDisplay : MonoBehaviour {
	public Conversation conversation;
	public GameObject speakerLeft;
	public GameObject speakerRight;
    public GameObject speakerMiddle;

	SpeakerUI speakerUILeft;
	SpeakerUI speakerUICenter;
	SpeakerUI speakerUIRight;

	int activeLineIndex = 0;

	void Start() {
		speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
		speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        speakerUICenter = speakerMiddle.GetComponent<SpeakerUI>();

		speakerUILeft.Speaker = conversation.speakerLeft;
		speakerUIRight.Speaker = conversation.speakerRight;
        speakerUICenter.Speaker = conversation.speakerCenter;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			AdvanceConversation();
		}
	}

	void AdvanceConversation() {
		if(activeLineIndex < conversation.lines.Length) {
			DisplayLine();
			activeLineIndex += 1;
		} else {
			speakerUILeft.Hide();
			speakerUIRight.Hide();
			activeLineIndex = 0;
		}
	}

	void DisplayLine() {
		Line line = conversation.lines[activeLineIndex];
		//Sprite portrait = conversation.portrait[0];
		Character Character = line.character;

		if(speakerUILeft.SpeakerIs(Character)) {
			SetDialog(speakerUILeft, speakerUIRight,speakerUICenter, line.text);
		} 
        else if (speakerUIRight.SpeakerIs(Character))
        {
			SetDialog(speakerUIRight, speakerUILeft,speakerUICenter, line.text);
		}
        else if(speakerUICenter.SpeakerIs(Character))
        {
            SetDialog(speakerUICenter, speakerUILeft,speakerUIRight, line.text);
           // SetDialog(speakerUIRight, speakerUIRight, line.text);
        }
	}

	void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI,SpeakerUI inactiveSpeakerUI2, string text) {
		activeSpeakerUI.Dialog = text;
		activeSpeakerUI.Show();
		inactiveSpeakerUI.Hide();
        inactiveSpeakerUI2.Hide();
	}
}