using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonCreator : MonoBehaviour {

    public GameObject menu;
    public Button prefab;
    public Text text;
    
    public void createButtons(JsonProject projectToCreateButtonOf)
    {
        Button mybutton = Instantiate(prefab);
        mybutton.GetComponentInChildren<Text>().text = projectToCreateButtonOf.name;
        //Text myText = Instantiate(text);
        mybutton.transform.SetParent(menu.transform);
        /*myText.transform.SetParent(mybutton.transform);
        myText.text = projectToCreateButtonOf.name;*/

    }
}
