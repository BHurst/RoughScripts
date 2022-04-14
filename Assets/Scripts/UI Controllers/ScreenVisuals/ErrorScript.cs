using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ErrorScript : MonoBehaviour
{
    static GameObject ErrorPane;
    static Text ErrorText;
    static float displayTime = 0;

    public static void DisplayError(string text)
    {
        ErrorPane.SetActive(true);
        ErrorPane.GetComponent<CanvasRenderer>().SetAlpha(1);
        ErrorText.GetComponent<CanvasRenderer>().SetAlpha(1);
        ErrorText.text = text;
        displayTime = 0;
    }

    void Update()
    {
        displayTime += Time.deltaTime;
        if(displayTime > 1.5f)
        {
            ErrorPane.GetComponent<CanvasRenderer>().SetAlpha(ErrorPane.GetComponent<CanvasRenderer>().GetAlpha() - Time.deltaTime * 2);
            ErrorText.GetComponent<CanvasRenderer>().SetAlpha(ErrorPane.GetComponent<CanvasRenderer>().GetAlpha() - Time.deltaTime * 2);
        }
            
        else if (displayTime > 2 && ErrorPane.activeInHierarchy)
            ErrorPane.SetActive(false);
    }

    void Start()
    {
        ErrorPane = gameObject.transform.GetComponentsInChildren<Transform>(true).ToList().FirstOrDefault(t => t.name == "ErrorPane").gameObject;
        ErrorText = gameObject.transform.GetComponentsInChildren<Text>(true).ToList().FirstOrDefault(t => t.name == "ErrorText");;
    }
}