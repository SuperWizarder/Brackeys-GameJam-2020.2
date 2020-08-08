using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
	private LineRenderer lr;
	private Vector3 grapplePoint;
	public LayerMask whatIsGrapplable;
	public Transform gunTip, mainCamera, player;
	float maxDistance = 100f;
	private SpringJoint joint;

		private void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			StartGrapple();
		}
		else if (Input.GetButtonUp("Fire2"))
		{
			StopGrapple();
		}
	}

	private void LateUpdate()
	{
		DrawRope();
	}

	void StartGrapple()
	{
		RaycastHit hit;
		if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, maxDistance))
		{
			grapplePoint = hit.point;
			joint = player.gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = grapplePoint;

			float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

			joint.maxDistance = distanceFromPoint * .8f;
			joint.minDistance = distanceFromPoint * .25f;

			joint.spring = 4.5f;
			joint.damper = 7f;
			joint.massScale = 4.5f;

			lr.positionCount = 2;
		}
	}

	void DrawRope()
	{
		if (!joint) return;

		lr.SetPosition(0, gunTip.position);
		lr.SetPosition(1, grapplePoint);
	}

	void StopGrapple()
	{
		lr.positionCount = 0;
		Destroy(joint);
	}
}
