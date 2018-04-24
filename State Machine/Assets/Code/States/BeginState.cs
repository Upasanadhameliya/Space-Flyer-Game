using UnityEngine;
using Assets.Code.Interfaces;
//using System.Collections;

namespace Assets.Code.States
{
    public class BeginState : IStateBase
    {
        private StateManager manager;

        public BeginState(StateManager managerRef)
        {
            manager = managerRef;
            if (Application.loadedLevelName != "Scene0")
                Application.LoadLevel("Scene0");
            Debug.Log("Constructing BeginState");
        }

        public void StateUpdate()
        {
           
        }

        public void ShowIt()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), manager.gameDataRef.beginStateSplash, ScaleMode.StretchToFill);

            if(GUI.Button(new Rect (((Screen.width)/2)-150,((Screen.height)/2)-30,300,60),"Press this button or press any key to play") || Input.anyKeyDown)
            {
                Switch();
            }
        }

        void Switch()
        {
            manager.SwitchState(new SetupState(manager));
        }
    }
}
