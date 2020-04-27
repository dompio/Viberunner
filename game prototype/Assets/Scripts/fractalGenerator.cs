using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractalGenerator : MonoBehaviour
{
    public int multiply = 5;
    public int split = 2;

    // Start is called before the first frame update
    void Start()
    {
        multiply--;
        for(int i = 0; i < split; ++i){
            if(multiply > 0){
                var duplicate = Instantiate(gameObject);
                var recursive = duplicate.GetComponent<fractalGenerator>();
                //
                //this.transform.position += this.transform.up;
                //
                //this.transform.rotation *= Quaternion.Euler(30, 0, 0);
                //this.transform.rotation *= Quaternion.Euler(30 * ((i * 2) - 1), 0, 0);
                recursive.SendMessage("Instantiated", i);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
