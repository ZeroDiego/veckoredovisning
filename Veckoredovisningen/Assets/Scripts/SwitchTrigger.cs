using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public bool isTriggered;

    public SwitchController switchController;

    private Animator animator;

    private void Awake()
    {
        switchController = GetComponent<SwitchController>();
        animator = GetComponent<Animator>();
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        isTriggered = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isTriggered = false;
    }

    public IEnumerator Deactivation()
    {
        animator.SetBool("isTriggered", true);
        yield return new WaitForSeconds(0.75f);
        animator.SetBool("isTriggered", false);
        yield return null;
    }
}
