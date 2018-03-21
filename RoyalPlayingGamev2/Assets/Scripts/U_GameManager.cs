using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public enum Directions { Left, Right, NoneLeft, NoneRight }
public class U_GameManager : MonoBehaviour
{


    public static U_GameManager Instance;
    public PlayerScript Player;

    float fps;

    // Use this for initialization
    void Start()
    {
        EditorApplication.playModeStateChanged += (playmode) =>
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                Debug.Log("Auto-Saving scene before entering Play mode: " + EditorApplication.currentScene);

                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        };
        U_GameManager.Instance = this;
    }
    float dTime = 0;
    // Update is called once per frame
    void Update()
    {
        dTime += (Time.deltaTime - dTime) * 0.1f;
        fps = 1.0f / dTime;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 10, Screen.height - 10, 80, 30), fps.ToString());
    }
    /// <summary>
    /// включает/выключает возможность управление
    /// </summary>
    /// <param name="active"></param>
    public void SetPlayerInteraction(bool active)
    {
        Player.interactionEnabled = active;
    }
}

