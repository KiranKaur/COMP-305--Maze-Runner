using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
    //PUBLIC INSTANCE VARIABLE
    public Transform spawnPoint;
    public GameObject muzzleFlash;
    public GameObject Explosion;
  
    //PRIVATE INSTANCE VARIABLE
    private Transform _transform;
    private GameController _gameController;
    // Use this for initialization
    void Start () {

        this._transform = gameObject.GetComponent<Transform>();
        this._gameController = GameObject.FindWithTag("GameController").GetComponent("GameController") as GameController;
	}
	
	// Update is called once per frame
	void Update () {

       
	}// end Update

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(this.muzzleFlash, spawnPoint.position, Quaternion.identity);

            RaycastHit hit;// stores information from Ray;

            if(Physics.Raycast(this._transform.position,this._transform.forward,out hit, 50f))
            {
                if (hit.transform.gameObject.CompareTag("Barrel"))
                {
                    Instantiate(this.Explosion, hit.point, Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                    this._gameController.ScoreValue += 100;
                }
                else {
                    Instantiate(this.muzzleFlash, hit.point, Quaternion.identity);
                }
                
              
            }
        }// If Statement
    }// end Fixed Update
}
