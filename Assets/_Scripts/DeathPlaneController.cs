using UnityEngine;
using System.Collections;

public class DeathPlaneController : MonoBehaviour {

    //PUBLIC INSTANCE VARIABLE
    public Transform spawnPoint;
    public GameController gameController;

	// Use this for initialization
	void Start () {

     
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = other.gameObject.GetComponent<Transform>();
            playerTransform.position = this.spawnPoint.position;
            gameController.LivesValue -= 1;
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }
}
