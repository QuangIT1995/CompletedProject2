using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Update(){
        float moveX = Input.GetAxis("Horizontal"); //di chuyen theo chieu ngang
        float moveY = Input.GetAxis("Vertical"); //di chuyen theo chieu doc
        Vector2 movement = new Vector2(moveX,moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
