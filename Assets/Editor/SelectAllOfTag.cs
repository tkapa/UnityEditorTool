using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectAllOfTag : ScriptableWizard {

    [Tooltip("Insert the tag you are looking for")]
    public string searchTag = "Your Tag Here";
    public Material NewMaterial;

	[MenuItem("My Tools/Select All of Tag...")]
    static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelectAllOfTag>("Change all tag materials...", "Change Materials");
    }

    void OnWizardCreate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);

        foreach(GameObject o in gameObjects)
        {
            o.GetComponent<Renderer>().material = NewMaterial;
        }
    }

    void OnWizardUpdate()
    {
        if (searchTag == "Your Tag Here" || NewMaterial == null)
            isValid = false;
        else
            isValid = true;
    }
}
