using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectManager : MonoBehaviour {

    public ButtonCreator buttonCreator;

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
            //for (int i = 0; i < startProject.projects.Length; i += 1) {
               StartCoroutine( GetUrl(startProject.projects[0].href));
            //}
            //Debug.Log(projectList[0].name);
        }
    }

    IEnumerator GetUrl(string myUrl) {
        WWW newUrl = new WWW(myUrl);
        yield return newUrl;
        Debug.Log(newUrl.text);
        LoadProjects(newUrl);
    }

    void LoadProjects(WWW url) {
        JsonProject jsonProjectToLoad = ProcessJson(url.text);
        /*projectList[counter] = new ProjectList(jsonProject);
        counter +=  1;
        //Debug.Log(projectList[0].name);

        Debug.Log(counter);*/
        Debug.Log(jsonProjectToLoad.name);
        buttonCreator.createButtons(jsonProjectToLoad);
    }

        private JsonProject ProcessJson(string jsonString)
    {
        JsonProject parsejson = JsonUtility.FromJson<JsonProject>(jsonString);
        return parsejson;
    }

    private Root ProcessStart(string jsonString)
    {
        Root startProject = JsonUtility.FromJson<Root>(jsonString);
        return startProject;
    }
}

public class ProjectList {
    public JsonProject project;

    public ProjectList(JsonProject jsonProject) {
        project = jsonProject;
    }
}
