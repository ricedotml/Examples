﻿using UnityEngine;

namespace SceneAssets.Games.Creatures2 {
	public class NormalBounce : MonoBehaviour{

		[SerializeField] float _reflection_factor = 1.1f;

		void OnCollisionEnter(Collision collision){
			var contact_point = collision.contacts[0];
			var rigbody = collision.rigidbody;
			var laser = rigbody.GetComponent<LaserBehaviour>();
			if(laser!=null){		
				this.BouncyReflection(contact_point, laser);
			}
		}

		void BouncyReflection(ContactPoint contact_point, LaserBehaviour laser){
			var rb = laser.GetComponent<Rigidbody>();
			//var point_velocity = rb.GetPointVelocity(contact_point.point);
			//var speed = point_velocity.magnitude * _dampening_factor;
		
			//var direction = Vector3.Reflect(rb.velocity.normalized, contact_point.normal);

			var speed = laser.oldVelocity.magnitude * this._reflection_factor;
			var direction = Vector3.Reflect(
					laser.oldVelocity.normalized,
					contact_point.normal);  

			var reflection = direction * speed;

			Debug.DrawRay(contact_point.point, reflection, Color.white, 4.0f);

			rb.velocity = reflection;
			//rb.AddForceAtPosition(reflection, contact_point.point);
		}
	}
}
