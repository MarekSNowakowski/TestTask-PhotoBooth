﻿using System.IO;
using UnityEditor;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{
    public string[] filePaths;

    public int currentModelIndex;
    public int startingIndex = 0;

    public Object currentModel;

    public string modelType = "fbx"; //To get prefabs change to "prefab"

    private static string pathIn = "Assets/In/";
    private static string pathOut = "Assets/Out";


    void Start()
    {
        currentModelIndex = startingIndex;

        filePaths = Directory.GetFiles(pathIn, "*." + modelType + " ");

        LoadModel();
    }

    public void Next()
    {
        if(currentModelIndex == filePaths.Length - 1)
        {
            currentModelIndex = 0;
        }else
        {
            currentModelIndex += 1;
        }
        Destroy(currentModel);
        LoadModel();
    }

    public void Back()
    {
        if(currentModelIndex == 0)
        {
            currentModelIndex = filePaths.Length - 1;
        }else
        {
            currentModelIndex -= 1;
        }
        Destroy(currentModel);
        LoadModel();
    }

    public void LoadModel()
    {
        currentModel = AssetDatabase.LoadMainAssetAtPath(filePaths[currentModelIndex]);
        if (currentModel != null) currentModel = Instantiate(currentModel);
    }
}
