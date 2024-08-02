using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    void Start(){
        Invoke("DestroyMe",0.2f);
    }
    void DestroyMe(){
        Destroy(gameObject);
    }
}
