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
        headerImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/gogoloco/Runtime/GoGo/GoLoco/Icons/icon_Go_Loco.png");

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

        GUI.color = Color.yellow;
        GUILayout.Label("This project is not in use anymore,\nplease use directly the menu entry\n[Tool/GoGoLoco/Add Prefabs].");
        GUI.color = Color.white;
        GUI.enabled = true;
    }
}

#endif