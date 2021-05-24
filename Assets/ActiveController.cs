using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActiveController : MonoBehaviour
{
	private Rigidbody rb;
	private Collider currentCollider;
	public GameObject text_;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		text_ = GetComponent<GameObject>();
	}

	// Update is called once per frame
	void Update()
	{
		if (OVRInput.Get(OVRInput.Button.One))
		{
			rb.constraints = RigidbodyConstraints.None;


		}

	}

	void OnCollisionEnter(Collision other)
	{
		text_.SetActive(false);
	}
}
