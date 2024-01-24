using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class DisplayMsgText
{
    public TextMeshProUGUI TextMsg;
    public List<GameObject> HidingSnapZone;
    public List<GameObject> DisabledGrabObject;
}

[Serializable]
public class DisplayPanelText
{
    public TextMeshProUGUI TextMsg;
    public int order;
    public GameObject panelText;
}

public class SendCheck : MonoBehaviour
{
    public CheckList checkList;
    [SerializeField] private List<AudioClip> greetness = new List<AudioClip>();
    [SerializeField] private List<AudioClip> badness = new List<AudioClip>();
    [SerializeField] private List<DisplayPanelText> displayPanelText = new List<DisplayPanelText>();
    [SerializeField] private GameObject canva;
    [SerializeField] private TextMeshProUGUI UItext;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<DisplayMsgText> displayMsgTextList = new List<DisplayMsgText>();
    private int currentStep = 0;
    System.Random rnd = new System.Random();
    [SerializeField] private UIControl uIControl;

    private bool raycasted = false;

    void Start()
    {
        checkList.list.ForEach(item => { item.status = false; });
        for (int i = 0; i < displayMsgTextList.Count; i++)
        {
            HideDisableObject(i, false);
        }
    }
    
    IEnumerator playEngineSound(AudioClip prevAudio, AudioClip nextAudio)
    {
        audioSource.clip = prevAudio;
        audioSource.Play();
        yield return new WaitForSeconds(prevAudio.length + 3);
        audioSource.clip = nextAudio;
        audioSource.Play();
    }


    private void HideDisableObject(int currentStep, bool status)
    {
        Debug.Log($"Im in index number : {currentStep}");
        if (displayMsgTextList[currentStep].HidingSnapZone.Count > 0)
        {
            Debug.Log($"Hiding object index : {currentStep}");
            foreach (var item in displayMsgTextList[currentStep].HidingSnapZone)
            {
                if (item != null)
                {
                    item.SetActive(status);
                }
                
            }
        }
        if (displayMsgTextList[currentStep].DisabledGrabObject.Count > 0)
        {
            foreach (var item in displayMsgTextList[currentStep].DisabledGrabObject)
            {
                if (item != null)
                {
                    item.GetComponent<XRGrabInteractable>().enabled = status;
                }
                
            }
        }
    }

    public void WriteMsg() {
        Debug.Log("Click me!");
    }

    private void Update()
    {
        if(checkList.list[currentStep].repetend == Repetend.Once)
        {
            StartCoroutine(playEngineSound(checkList.list[currentStep].clip, checkList.list[currentStep + 1].clip));
            if (displayMsgTextList[currentStep].TextMsg)
            {
                displayMsgTextList[currentStep].TextMsg.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            
            checkList.list[currentStep].status = true;
            currentStep ++;
        }
        // Debug.Log(currentStep);
    }

    public void ValidStep(int currentStepIndex)
    {
        if (currentStepIndex == 0 || checkList.list.GetRange(0, currentStepIndex).TrueForAll(b => b.status == true)) { 
            
            if (displayMsgTextList[currentStepIndex].TextMsg) {
                displayMsgTextList[currentStepIndex].TextMsg.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }

            if (currentStepIndex + 1 < checkList.list.Count && checkList.list[currentStepIndex].status == false)
            {
                StartCoroutine(playEngineSound(greetness[rnd.Next(greetness.Count)], checkList.list[currentStepIndex + 1].clip));
            }
            checkList.list[currentStepIndex].status = true;
            if (currentStep < currentStepIndex) {
                currentStep = currentStepIndex + 1;
                HideDisableObject(currentStep, true);
            }

        }
        else
        {
            int firstFalseIndex = checkList.list.FindIndex(b => b.status == false);
            StartCoroutine(playEngineSound(badness[rnd.Next(badness.Count)], checkList.list[firstFalseIndex].clip));
        }
    }


    public void ChangePanel(GameObject newPanel)
    {
        foreach (var panel in displayPanelText)
        {
            panel.panelText.SetActive(false);
        }
        newPanel.SetActive(true);
    }

    public IEnumerator Routine(int order) // this need fix
    {
        float timing = (float)(rnd.NextDouble() * 9 + 1);
        uIControl.timing = timing;
        uIControl.displayText = displayPanelText.Find(x => x.order == order).TextMsg;
        // send timing value to ui
        yield return new WaitForSeconds(timing + 0.5f);
        foreach (var panel in displayPanelText)
        {
            panel.panelText.SetActive(false);
        }
        displayPanelText.Find(x => x.order == order + 1).panelText.SetActive(true);
        // Debug.Log("DONE!");
        ValidStep(order);
        raycasted = false;
    }


    public void CalculatSpeed(int order) // this need fix
    {
        if (!raycasted)
        {
            foreach (var panel in displayPanelText)
            {
                panel.panelText.SetActive(false);
            }
            // Debug.Log("OneTime");
            displayPanelText.Find(x => x.order == order).panelText.SetActive(true);
            StartCoroutine(Routine(order));
            raycasted = true;
        }

    }

    public IEnumerator Routine2(GameObject panel) // this need fix
    {
        int GetChildIndex(Transform parent, string childName)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).name == childName)
                {
                    return i;
                }
            }

            // Return -1 if the child is not found
            return -1;
        }
        float timing = (float)(rnd.NextDouble() * 9 + 1);
        uIControl.timing = timing;
        uIControl.displayText = UItext;
        // send timing value to ui
        yield return new WaitForSeconds(timing + 0.5f);
        ChangePanel(panel.transform.parent.GetChild(GetChildIndex(panel.transform.parent, panel.name) + 1).gameObject);
    }

    private static GameObject[] GetChildObjects(Transform parent)
    {
        int childCount = parent.childCount;
        GameObject[] childObjects = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = parent.GetChild(i).gameObject;
        }

        return childObjects;
    }

    public void ChangePanel2(GameObject oneObject) {
        foreach (var item in GetChildObjects(canva.transform))
        {
            item.SetActive(false);
        };
        oneObject.SetActive(true);
    }

    public void CalculatVibration(GameObject panel) // this need fix
    {
        StartCoroutine(Routine2(panel));
    }

}
