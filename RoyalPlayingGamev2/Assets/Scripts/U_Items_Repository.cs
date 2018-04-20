using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Items_Repository : MonoBehaviour {

    [System.Serializable]
    public class KeyTexture
    {
        public string key;
        public Texture texture;
    }

    public List<KeyTexture> ItemTextures;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Texture GetTexture(string key)
    {
        var texture = ItemTextures.Find(kt => kt.key == key);
        if (texture != null)
            return texture.texture;
        return null;
    }
}
