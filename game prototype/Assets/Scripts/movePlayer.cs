using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public float horizontalVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-4,0,horizontalVelocity);
        if(Input.GetKeyDown(left)){
            horizontalVelocity = -2;
            StartCoroutine(stopSlide());
        }
        if(Input.GetKeyDown(right)){
            horizontalVelocity = 2;
            StartCoroutine(stopSlide());
        }
    }

    IEnumerator stopSlide(){
        yield return new WaitForSeconds (.5f);
        horizontalVelocity = 0;
    }

    private void OnCollisionEnter(Collision coll) {
        if(coll.gameObject.name == "EnergyPill" || coll.gameObject.name == "EnergyPill3" || coll.gameObject.name == "EnergyPill5"){
            Destroy (coll.gameObject);
        }
        
    }
}
