using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TooltipController : MonoBehaviour {

    Transform npcTooltip;
    Transform objectTooltip;
    Transform itemTooltip;
    Vector3 screenSizeCorrect = new Vector3(0f,0f,0f);
    Vector3 offset = new Vector3(60f,0f,0f);
    float timer = 0;
    public float delayTime = 1;
    public Canvas canv;

    void Start () {
        npcTooltip = transform.GetChild(0);
        objectTooltip = transform.GetChild(1);
        itemTooltip = transform.GetChild(2);
    }

    void Clear()
    {
        timer = 0;
        npcTooltip.GetComponentInChildren<Text>().text = "";
        npcTooltip.gameObject.SetActive(false);
        objectTooltip.GetComponentInChildren<Text>().text = "";
        objectTooltip.gameObject.SetActive(false);
        itemTooltip.GetComponentInChildren<Text>().text = "";
        itemTooltip.gameObject.SetActive(false);
    }
	
	//Manipulates a text box to display the name of a object/character when moused over for a short period of time.
	void Update ()
    {
        return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        screenSizeCorrect = new Vector3(0, 0, 0);

        if (Physics.Raycast(ray, out hit) && (!EventSystem.current.IsPointerOverGameObject()))
        {
            if (hit.transform.tag.Contains("Character"))
            {
                timer += Time.deltaTime;
                if (timer >= delayTime)
                {
                    npcTooltip.gameObject.SetActive(true);
                    npcTooltip.GetComponentInChildren<Text>().text = hit.transform.GetComponent<RootUnit>().unitName;
                    if ((Input.mousePosition.x + (offset.x + npcTooltip.GetComponent<RectTransform>().rect.width) * canv.scaleFactor) > Screen.width)
                    {
                        screenSizeCorrect.x = Screen.width - (Input.mousePosition.x + (offset.x + npcTooltip.GetComponent<RectTransform>().rect.width) * canv.scaleFactor);
                    }
                    if (Input.mousePosition.y - (npcTooltip.GetComponent<RectTransform>().rect.height * canv.scaleFactor) < 0)
                    {
                        screenSizeCorrect.y = Mathf.Abs(Input.mousePosition.y - npcTooltip.GetComponent<RectTransform>().rect.height * canv.scaleFactor);
                    }
                    GetComponent<RectTransform>().position = Input.mousePosition + screenSizeCorrect + offset * canv.scaleFactor;
                }
            }
            else if(hit.transform.tag.Contains("Object"))
            {
                timer += Time.deltaTime;
                if (timer >= delayTime)
                {
                    objectTooltip.gameObject.SetActive(true);
                    objectTooltip.GetComponentInChildren<Text>().text = hit.transform.GetComponent<WorldObject>().entityName;
                    if ((Input.mousePosition.x + (offset.x + objectTooltip.GetComponent<RectTransform>().rect.width) * canv.scaleFactor) > Screen.width)
                    {
                        screenSizeCorrect.x = Screen.width - (Input.mousePosition.x + (offset.x + objectTooltip.GetComponent<RectTransform>().rect.width) * canv.scaleFactor);
                    }
                    if (Input.mousePosition.y - (objectTooltip.GetComponent<RectTransform>().rect.height * canv.scaleFactor) < 0)
                    {
                        screenSizeCorrect.y = Mathf.Abs(Input.mousePosition.y - objectTooltip.GetComponent<RectTransform>().rect.height * canv.scaleFactor);
                    }
                    GetComponent<RectTransform>().position = Input.mousePosition + screenSizeCorrect + offset * canv.scaleFactor;
                }
            }
            else if(hit.transform.tag.Contains("Item"))
            {
                timer += Time.deltaTime;
                if (timer >= delayTime)
                {
                    itemTooltip.gameObject.SetActive(true);
                    itemTooltip.GetComponentInChildren<Text>().text = hit.transform.GetComponent<WorldItem>().inventoryItem.itemName;
                    if ((Input.mousePosition.x + (offset.x + itemTooltip.GetComponent<RectTransform>().rect.width) * canv.scaleFactor) > Screen.width)
                    {
                        screenSizeCorrect.x = Screen.width - (Input.mousePosition.x + (offset.x + itemTooltip.GetComponent<RectTransform>().rect.width) * canv.scaleFactor);
                    }
                    if (Input.mousePosition.y - (itemTooltip.GetComponent<RectTransform>().rect.height * canv.scaleFactor) < 0)
                    {
                        screenSizeCorrect.y = Mathf.Abs(Input.mousePosition.y - itemTooltip.GetComponent<RectTransform>().rect.height * canv.scaleFactor);
                    }
                    GetComponent<RectTransform>().position = Input.mousePosition + screenSizeCorrect + offset * canv.scaleFactor;
                }
            }
            else if(!hit.transform.tag.Contains("Character") || !hit.transform.tag.Contains("Object") || !hit.transform.tag.Contains("Item"))
            {
                Clear();
            }
        }
        else
        {
            Clear();
        }
    }
}