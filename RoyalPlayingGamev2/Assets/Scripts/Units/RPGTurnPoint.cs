using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace RoyalPlayingGamev2.Units
{
    public delegate void CollisionDetectedDelegate(Collider2D collision);


    /// <summary>
    /// вспомогательный класс для точки поворота - объекта, которым враг бьется 
    /// об препятствия и игрока
    /// </summary>
    public class RPGTurnPoint : MonoBehaviour
    {

        public event CollisionDetectedDelegate Turn;

        public float frozenTurnTime = 0.2f;
        float currentTurnTime = 0;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (currentTurnTime > 0)
                currentTurnTime -= Time.deltaTime;
            if (currentTurnTime < 0)
                currentTurnTime = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (currentTurnTime == 0 && Turn != null)
            {
                currentTurnTime = frozenTurnTime;
                Turn(collision);
            }
        }

        public void Disable()
        {
            Turn = null;
            enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}