﻿using UnityEngine;
using System.Collections;

public class RewindGun : MonoBehaviour
{
	#region Variables
	public static bool isRewinding = false;
	public float rewindTime = 5f;
	#endregion

	#region Unity Methods
	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			StartCoroutine(Rewind());
		}
	}
	#endregion

	#region Methods
	IEnumerator Rewind()
	{
		FindObjectOfType<AudioManager>().Play("Rewind");

		isRewinding = true;
		yield return new WaitForSeconds(rewindTime);
		isRewinding = false;

		gameObject.SetActive(false);
	}
	#endregion
}
