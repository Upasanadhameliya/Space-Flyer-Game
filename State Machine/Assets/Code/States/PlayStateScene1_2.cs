using UnityEngine;
using Assets.Code.Interfaces;
//using System.Collections;

namespace Assets.Code.States
{
    public class PlayStateScene1_2 : IStateBase
    {
        private StateManager manager;
        public PlayStateScene1_2(StateManager managerRef)
        {
            manager = managerRef;
            if (Application.loadedLevelName != "Scene1")
                Application.LoadLevel("Scene1");
            Debug.Log("Constructing PlayStateScene1_2");

            foreach (GameObject camera in manager.gameDataRef.cameras)
            {
                if (camera.name != "FollowingCamera")
                    camera.SetActive(false);
                else
                    camera.SetActive(true);
            }
        }

        public void StateUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                manager.SwitchState(new WonStateScene1(manager));
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                manager.SwitchState(new LostStateScene1(manager));
            }
        }

        public void ShowIt()
        {
            Debug.Log("In PlayStateScene1_2");
        }
    }
}
