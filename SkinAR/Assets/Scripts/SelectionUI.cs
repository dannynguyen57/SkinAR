
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectionUI : MonoBehaviour
{
    public GameObject optionPrefab;

    public Transform prevPopupcode;
    public Transform selectedPopupcode;

    private void Start()
    {
        foreach (Popupcode c in GameManager.instance.popupcodes)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                GameManager.instance.SetPopupcode(c);
                if(selectedPopupcode != null)
                {
                    prevPopupcode = selectedPopupcode;
                }

                selectedPopupcode = option.transform;
            });

            TextMeshProUGUI texts = option.GetComponentInChildren<TextMeshProUGUI>();
            texts.text = c.name;

            Image image = option.GetComponentInChildren<Image>();
            image.sprite = c.icon;
            
        }
    }

    private void Update()
    {
        if(selectedPopupcode != null)
        {
            selectedPopupcode.localScale = Vector3.Lerp(selectedPopupcode.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);
        }
        if(prevPopupcode != null)
        {
            prevPopupcode.localScale = Vector3.Lerp(prevPopupcode.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }
    }
}
