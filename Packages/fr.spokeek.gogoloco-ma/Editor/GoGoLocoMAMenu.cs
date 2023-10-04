#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using VRC.SDK3.Avatars.Components;

public class GoGoLocoMAMenu : EditorWindow
{
    private GameObject avatarTarget;

    private GameObject gogolocoAllMAPrefab;
    private GameObject gogolocoBeyondMAPrefab;

    private string errorLabel = "";

    private Texture2D headerImage;

    /**
    *  Load the GoGoLoco Prefab Window
    */
    [MenuItem("Tools/GoGoLoco (Modular Avatar)/Add Prefabs")]
    public static void ShowWindow()
    {
        GetWindow<GoGoLocoMAMenu>("GoGoLoco (MA) Prefabs");
    }

    /**
    *  Load the GoGoLoco ressources
    */
    private void OnEnable()
    {
        headerImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/gogoloco/Runtime/GoLoco/Icons/icon_Go_Loco.png");

        gogolocoAllMAPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/fr.spokeek.gogoloco-ma/Prefabs/GoGoLoco_All_MA.prefab");
        gogolocoBeyondMAPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/fr.spokeek.gogoloco-ma/Prefabs/GoGoLoco_Beyond_MA.prefab");

        avatarTarget = Selection.activeGameObject;
    }

    /**
    *  Flow of the GoGoLoco Prefab Window
    */
    private void OnGUI()
    {
        // GoGoLoco Logo
        GUILayout.Label("Modular Avatar Integration");
        GUILayout.Label(headerImage, GUILayout.ExpandWidth(true), GUILayout.MaxHeight(headerImage.height));

        // Help Box
        GUILayout.Label("Select your avatar in the hierarchy");
        // Avatar Selector 
        avatarTarget = EditorGUILayout.ObjectField(avatarTarget, typeof(GameObject), true) as GameObject;

        if (avatarTarget == null)
        {
            errorLabel = "Error: No object selected in the Hierarchy.";
            GUI.color = Color.red;
            GUILayout.Label(errorLabel);
            GUI.color = Color.white;
        }
        else if (avatarTarget.GetComponent<VRCAvatarDescriptor>() == null)
        {
            errorLabel = "Error: Selected object isn't an avatar (Doesn't have an AvatarDescriptor Component).";
            GUI.color = Color.red;
            GUILayout.Label(errorLabel);
            GUI.color = Color.white;
        }
        else{
            errorLabel = "";
        }

        // Disable buttons if wrong avatar selected
        GUI.enabled = errorLabel == "";
        
        if (GUILayout.Button("Add GoGoLoco All (Modular Avatar) Prefab"))
        {
            GameObject instantiatedPrefab = PrefabUtility.InstantiatePrefab(gogolocoAllMAPrefab) as GameObject;
            instantiatedPrefab.transform.SetParent(avatarTarget.transform);
        }
        if (GUILayout.Button("Add GoGoLoco Beyond (Modular Avatar) Prefab"))
        {
            GameObject instantiatedPrefab = PrefabUtility.InstantiatePrefab(gogolocoBeyondMAPrefab) as GameObject;
            instantiatedPrefab.transform.SetParent(avatarTarget.transform);
        }
        GUI.enabled = true;
    }
}

#endif