using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectAllOfTag : ScriptableWizard {

    [Tooltip("Insert the tag you are looking for")]
    public string searchTag = "Your Tag Here";

    [Tooltip("If this is empty, no new material will be applied")]
    public Material NewMaterial;

    [Tooltip("If this is empty, no new scripts will be added")]
    public MonoScript scriptToApply;

    [Tooltip("Is this is true, all found objects will be selected")]
    public bool selectObjects = false;

	[MenuItem("My Tools/Select All of Tag...")]
    static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelectAllOfTag>("Change all tag materials...", "Done");
    }

    void OnWizardUpdate()
    {
        if (searchTag == "Your Tag Here")
            isValid = false;
        else
            isValid = true;        
    }

    void OnWizardCreate()
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);

        if (NewMaterial != null)
        {
            foreach (GameObject o in gameObjects)
                o.GetComponent<Renderer>().material = NewMaterial;

        }

        if (scriptToApply != null)
        {
            //foreach (GameObject o in gameObjects)
                
        }

        if (selectObjects)                   
            Selection.objects = gameObjects;
        
    }
}
