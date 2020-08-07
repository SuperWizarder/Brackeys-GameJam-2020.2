using UnityEngine;

public class AI_Look : MonoBehaviour
{
	#region Variables
	public float speed;

	private GameObject target;
	#endregion

	#region Unity Methods
	void Start()
    {
		target = GameObject.FindWithTag("Player");
    }
	void FixedUpdate()
    {
		Vector3 direction = target.transform.position - this.transform.position;
		direction.y = 0;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), speed);

	}
	#endregion
}
