using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraTransistion : MonoBehaviour
{
    public Vector3 offset;
    public float moveSpeed;

    public Transform target;
    private TransisitionTrigger tT;
    private int index = 0;

    private void Awake()
    {
        tT = transform.GetChild(index).GetComponent<TransisitionTrigger>();
    }

    private void Update()
    {
        if (tT.isTriggered)
        {
            Debug.Log(target);
            Transistion();
        }
    }

    public void Transistion()
    {
        Vector3 movePosition = target.position + offset;
        if (transform.localPosition.x == movePosition.x)
        {
            index++;
            tT = transform.GetChild(index).GetComponent<TransisitionTrigger>();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
        }
    }
}
