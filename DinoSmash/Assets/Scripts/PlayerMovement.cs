using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform leftPivot, rightPivot;
    public float rotateSpeed;
    bool canPivotLeft = true, canPivotRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.A) && canPivotLeft)
        {
            canPivotRight = false;
            Vector3 pos = leftPivot.transform.position;
            transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime, Space.Self);
            pos -= leftPivot.transform.position;
            transform.position += pos;
        }

        if (Input.GetKey(KeyCode.D) && canPivotRight)
        {
            canPivotLeft = false;
            Vector3 pos = rightPivot.transform.position;
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.Self);
            pos -= rightPivot.transform.position;
            transform.position += pos;
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            canPivotRight = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            canPivotLeft = true;
        }

    }
}
