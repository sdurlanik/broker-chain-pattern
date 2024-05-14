using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDurlanik.BrokerChain
{
    public class SimplePlayerController : Entity
    {
        public float speed = 5.0f;


        public new void Update()
        {
            base.Update();
            Move();
        }

        private void Move()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}