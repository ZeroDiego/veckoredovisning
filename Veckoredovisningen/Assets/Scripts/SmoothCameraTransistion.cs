using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraTransistion : MonoBehaviour
{
    public Vector3 offset;
    public float moveSpeed;

    private Transform target;
    private TransisitionTrigger tT;

    private void Awake()
    {
        target = GameObject.Find("TargetPosition").GetComponent<Transform>();
        target.parent = null;
        tT = GetComponentInChildren<TransisitionTrigger>();
    }

    private void Update()
    {
        if (tT.isTriggered)
        {
            Transistion();
        }
    }

    public void Transistion()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
    }
}
