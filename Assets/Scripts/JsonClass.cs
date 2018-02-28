using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Root
{
    public Views[] projects;
}


[System.Serializable]
public class JsonProject
{
    public string name;
    public Views[] views;
}

[System.Serializable]
public class Views
{
    public string href;
}

[System.Serializable]
public class ProjectView
{
    public string visualization;
    public string name;
    public ProjectData[] data;
}

[System.Serializable]
public class ProjectData
{
    public int id;
    public string type;
    public int width;
    public int height;
    public int value;
    public ProjectData[] children;

    public void setParents(ProjectData parent)
    {
        foreach (ProjectData c in children)
        {
            c.setParents(this);
        }
    }
}






