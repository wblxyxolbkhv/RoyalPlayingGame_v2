using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_UIManager : MonoBehaviour {

    public bool isScalesHidden = false;
    public bool isInventoryShown = false;


    public static Texture2D greenTexture;
    public static Texture2D blueTexture;
    public static Texture2D blackTexture;
    public static Texture2D transparentTexture;
    


    // Use this for initialization
    void Start () {
        greenTexture = new Texture2D(1, 1);
        greenTexture.SetPixel(0, 0, new Color(0f, 175.0f/255.0f, 0f, 1f));
        greenTexture.Apply();

        blackTexture = new Texture2D(1, 1);
        blackTexture.SetPixel(0, 0, Color.black);
        blackTexture.Apply();

        transparentTexture = new Texture2D(1, 1);
        transparentTexture.SetPixel(0, 0, new Color(0, 0, 0, 0));
        transparentTexture.Apply();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (!isScalesHidden)
        {
            int health = U_GameManager.Instance.Player.GetHealth();
            int maxHealth = U_GameManager.Instance.Player.GetMaxHealth();

            float healthBarWidth = 140 * (float)health / (float)maxHealth;
            

            var style = GUI.skin.GetStyle("Label");
            style.normal.background = blackTexture;
            GUI.Label(new Rect(9, 9, 142, 22), GUIContent.none, style);
            style.normal.background = greenTexture;
            GUI.Label(new Rect(10, 10, healthBarWidth, 20), GUIContent.none, style);
            style.normal.background = transparentTexture;
            style.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(10, 10, 142, 20), health + "/" + maxHealth, style);
            
        }
        if (isInventoryShown)
        {
        }
    }

}
