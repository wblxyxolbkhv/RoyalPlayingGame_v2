using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions { Left, Right, NoneLeft, NoneRight }
public class U_GameManager : MonoBehaviour
{


    public static U_GameManager Instance;
    public PlayerScript Player;

    // Use this for initialization
    void Start()
    {
        U_GameManager.Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

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

