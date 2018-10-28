using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Dialogs;

namespace RoyalPlayingGamev2.Units
{
    /// <summary>
    /// персонаж, с которым можно поговорить
    /// </summary>
    public class RPGTalker : MonoBehaviour
    {

        public Dialog currentDialog;

        public string Name
        {
            get { return GetComponent<RPGUnit>().Name; }
        }

        // Use this for initialization
        void Start()
        {
            currentDialog = new DebugBearDialog();
            currentDialog.LoadDialog(null);
        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// актирирует диалог с персонажем
        /// </summary>
        public void Activate()
        {
            currentDialog.GoToDialogBeginning();
        }
    }
}