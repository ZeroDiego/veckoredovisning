using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraTransistion : MonoBehaviour
{
    public EventCallbacks.PlayerController playerController;
    public Vector3 offset;
    public float moveSpeed;

    public GameObject[] targets;

    private TransisitionTrigger[] tTS;

    private void Awake()
    {
        targets = GameObject.FindGameObjectsWithTag("CameraTarget");
        tTS = GetComponentsInChildren<TransisitionTrigger>();

        for (int i = 0; i < tTS.Length; i++)
        {
            targets[i].transform.parent = null;
            tTS[i].gameObject.transform.parent = null;
        }
    }

    private void Update()
    {
        for (int i = 0; i < tTS.Length; i++)
        {
            if (tTS[i].isTriggered)
            {
                Transistion(tTS[i], targets[i].transform);
            }
        }
    }

    public void Transistion(TransisitionTrigger tT, Transform target)
    {
        Vector3 movePosition = target.position + offset;

        if (transform.position == movePosition)
        {
            tT.isTriggered = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
    }

    public IEnumerator TeleportCamera()
    {
        moveSpeed *= 1000f;
        playerController.movespeed = 0f;
        yield return new WaitForSeconds(0.75f);
        moveSpeed /= 1000f;
        playerController.movespeed = 5f;
        yield return null;
    }
}
