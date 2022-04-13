using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public delegate void OnFire(Vector3 size);
	public static event OnFire OnHit;

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
				anim.SetInteger ("AnimationPar", 1);
				SoundManager.Instance().Footsteps();
		}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
			if (OnHit != null)
            {
				OnHit(new Vector3(2, 2, 2));
            }
        }
    }
}
