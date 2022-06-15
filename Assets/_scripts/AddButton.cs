using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    [SerializeField]
    private Transform twinsField;

    [SerializeField]
    private GameObject btn;

    void Awake() 
    {
        for(int i =0; i < 8; i++ )
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(twinsField, false);
            //set button image
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/image/" + i);
        }    
    }
}
