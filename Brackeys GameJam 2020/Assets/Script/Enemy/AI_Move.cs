using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Move: MonoBehaviour
{
	#region Variables
	private Transform target;
    public float speed;

    private Rigidbody rb;
	#endregion

	#region Unity Methods
	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
	#endregion
}
