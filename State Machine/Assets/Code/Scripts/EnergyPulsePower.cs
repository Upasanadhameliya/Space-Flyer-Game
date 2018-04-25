using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPulsePower : MonoBehaviour {

	public float pulseDuration = 1f;

    public Transform GoodOrb;

	void Start () {
		
	}
	

	void Update () {
        pulseDuration -= Time.deltaTime;

        if (pulseDuration <= 0)
            Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BadOrb")
        {
            Instantiate(GoodOrb, other.transform.position, other.transform.rotation);
            GameObject.Find("GameManager").GetComponent<GameData>().playerLives += 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
