﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder : MonoBehaviour {

    public GameObject plane;
    public GameObject cube;

    public IEnumerator BuildCodeCity(JsonProject JsonProjectToBuild)
    {
        Debug.Log(JsonProjectToBuild.views[0].href);
        WWW complexityUrl = new WWW(JsonProjectToBuild.views[0].href);
        yield return complexityUrl;

        if (complexityUrl.error != null)
        {
            Debug.Log("ERROR: " + complexityUrl.error);
        }
        else
        {
            Debug.Log("No Error");
            Debug.Log(complexityUrl.text);

            ProjectView projectView = ProcessProjectData(complexityUrl.text);
            /*foreach (ProjectData projectdata in projectView.data)
            {
                CreateGameObjectFromProjectData(projectdata);
            }*/
            CreateGameObjectFromProjectData(projectView.data[0]);
        }
    }

    private ProjectView ProcessProjectData(string jsonString)
    {
        ProjectView parsejson = JsonUtility.FromJson<ProjectView>(jsonString);
        return parsejson;
    }

    private void CreateGameObjectFromProjectData(ProjectData projectData) {
        //projectData.setParents(projectData);
        switch (projectData.type)
        {
            case "block": /*GameObject planes = Instantiate(plane);
                planes.transform.localScale = new Vector3((float)0.8, (float)0.8, (float)0.8);*/ Debug.Log("cube" + projectData.id); break;

            case "scope": Debug.Log("plane" + projectData.id); break;

            default: break;
        }

        if (projectData.children != null)
        {
            Debug.Log(projectData.children[0].id);
            foreach (ProjectData data in projectData.children)
            {
                CreateGameObjectFromProjectData(data);
            }
        }
    }
}
