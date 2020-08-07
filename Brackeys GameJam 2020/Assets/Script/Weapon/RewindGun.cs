using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RewindGun : MonoBehaviour
{
	#region Variables
	public static bool isRewinding = false;
	public Material material;
	#endregion

	#region Unity Methods
	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			isRewinding = true;
		}
		else
		{
			isRewinding = false;
		}

		Debug.Log(isRewinding);
	}
	#endregion

	#region Methods

	#endregion
}
