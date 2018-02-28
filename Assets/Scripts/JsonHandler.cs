using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JsonHandler : MonoBehaviour {

    public GameObject menu;
    public Button prefab;
    public Text text;
   


   /* [RuntimeInitializeOnLoadMethod]
    IEnumerator Start()
    {
        string url = "https://raw.githubusercontent.com/Vincethevince/CodeCityVR/master/data/projects/project1/index.json";
        WWW www = new WWW(url);
        yield return www;
        
        if (www.error != null)
        {
            Debug.Log("ERROR: " + www.error);
        }
        else
        {
            Debug.Log("No Error");
            Debug.Log(www.text);
            //Debug.Log(ProcessJson(www.text));
            JsonClass jsonClass = ProcessJson(www.text);
            Debug.Log(jsonClass.views[0].href);
            Button mybutton = Instantiate(prefab);
            Text myText = Instantiate(text);
            mybutton.transform.SetParent(menu.transform);
            myText.transform.SetParent(mybutton.transform);
            myText.text = jsonClass.name;
        }
        //LoadProjects();
        
    }*/

   [RuntimeInitializeOnLoadMethod]
    IEnumerator Start()
    {
        string startingUrl = "https://raw.githubusercontent.com/Vincethevince/CodeCityVR/master/data/projects/index.json";
        WWW myUrl = new WWW(startingUrl);
        yield return myUrl;

        if (myUrl.error != null)
        {
            Debug.Log("ERROR: " + myUrl.error);
        }
        else
        {
            Debug.Log("No Error");
            Debug.Log(myUrl.text);

            Root startProject = ProcessStart(myUrl.text);
            Debug.Log(startProject.projects[0].href);
        }
    }

    
    
    

    private JsonProject ProcessJson(string jsonString) {
        JsonProject parsejson = JsonUtility.FromJson<JsonProject>(jsonString);
        return parsejson;
    }

    private Root ProcessStart(string jsonString)
    {
        Root startProject = JsonUtility.FromJson<Root>(jsonString);
        return startProject;
    }
}


