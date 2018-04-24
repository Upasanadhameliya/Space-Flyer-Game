using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;

public class StateManager : MonoBehaviour {

    private IStateBase activestate;
    private static StateManager instanceRef;

    [HideInInspector]
    public GameData gameDataRef;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = (this);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start () {
        activestate = new BeginState(this);
        gameDataRef = GetComponent<GameData>();
        Debug.Log("This object is of type : " + activestate);
	}

    private void OnGUI()
    {
        if (activestate != null)
            activestate.ShowIt();
    }
    // Update is called once per frame
    void Update () {
        if (activestate != null)
            activestate.StateUpdate();
		
	}

    public void SwitchState(IStateBase newstate)
    {
        activestate = newstate;
    }

    public void Restart()
    {
        Destroy(gameObject);
        Application.LoadLevel("Scene0");
    }
}
