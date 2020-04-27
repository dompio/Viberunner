using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractalBuilder : MonoBehaviour
{
    public float rotate = 30;
    public float scale = 0.7f;
    public void Instantiated(int i){
        //this.transform.position += Vector3.up;
        this.transform.position += this.transform.up * this.transform.localScale.y;
        this.transform.rotation *= Quaternion.Euler(rotate * ((i * 2) - 1), 0, 0);
        //this.transform.localScale *= scale; 
    }
}
