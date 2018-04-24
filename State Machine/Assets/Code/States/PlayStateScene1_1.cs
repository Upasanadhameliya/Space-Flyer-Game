using UnityEngine;
using Assets.Code.Interfaces;
//using System.Collections;

namespace Assets.Code.States
{
    public class PlayStateScene1_1 : IStateBase
    {
        private StateManager manager;
        private GameObject player;
        private Rigidbody rb;

        public PlayStateScene1_1(StateManager managerRef)
        {
            manager = managerRef;
            if (Application.loadedLevelName != "Scene1")
                Application.LoadLevel("Scene1");

            player = GameObject.Find("Player");
            rb = player.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            foreach(GameObject camera in manager.gameDataRef.cameras)
            {
                if (camera.name != "LookAtCamera")
                    camera.SetActive(false);
                else
                    camera.SetActive(true);
            }
        }

        public void StateUpdate()
        {
            if (manager.gameDataRef.playerLives >= 2)
            {
                manager.SwitchState(new WonStateScene1(manager));
                rb.isKinematic = true;
                player.transform.position = new Vector3(50, .5f, 40);
            }
            if(Input.GetKeyUp(KeyCode.Return))
            {
                manager.SwitchState(new LostStateScene1(manager));
                manager.gameDataRef.ResetPlayer();
                rb.isKinematic = true;
                player.transform.position = new Vector3(50, .5f, 40);
            }
        }

        public void ShowIt()
        {
            Debug.Log("In PlayStateScene1_1");
        }
    }
}
