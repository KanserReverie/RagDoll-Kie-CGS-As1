using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace RagDollGame
{
	public class RotateBox : MonoBehaviour
	{
		private enum Rotation {Left, Right, None};
		[SerializeField] private float speed = 14f;

		private Rotation boxRotation = Rotation.None;
		public bool boxRotatable;

		private void Update()
		{
			if(boxRotatable)
			{
				boxRotation = Rotation.None;

				if(Input.GetKey(KeyCode.RightArrow))
				{
					boxRotation = Rotation.Right;
				}

				if(Input.GetKey(KeyCode.LeftArrow))
				{
					boxRotation = boxRotation == Rotation.Right
						? Rotation.None
						: Rotation.Left;
				}
			}
		}

		private void FixedUpdate()
		{
			switch(boxRotation)
			{
				case Rotation.Left:
					transform.Rotate(Vector3.forward * speed * Time.deltaTime);
					break;
				case Rotation.Right:
					transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
					break;
				case Rotation.None:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}