using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEventPanel : MonoBehaviour
{
    private EventsController _eventsController { get { return EventsController.Instance; } }

    public TextMeshProUGUI EventDescription;
    public TextMeshProUGUI OptionOneText;
    public TextMeshProUGUI OptionTwoText;

    public void SetEvent((string description, string optionOne, string optionTwo) eventData)
    {
        EventDescription.text = GameTranslate.GetTranslation(eventData.description);
        OptionOneText.text = GameTranslate.GetTranslation(eventData.optionOne);
        OptionTwoText.text = GameTranslate.GetTranslation(eventData.optionTwo);
    }

    public void PickOptionOne()
    {
        _eventsController.OptionOneSelected();
        gameObject.SetActive(false);
    }

    public void PickOptionTwo()
    {
        _eventsController.OptionTwoSelected();
        gameObject.SetActive(false);
    }
}
