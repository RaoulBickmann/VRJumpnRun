using uFrame.ECS.UnityUtilities;

namespace ViveDB {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS.APIs;
    using uFrame.ECS.Components;
    using uFrame.ECS.Systems;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    using ViveDB;
    
    
    public partial class PlayerSystem {

        private int jumpCount;
        private Vector3 lastCheckPoint;

        protected override void Start()
        {
            base.Start();
            jumpCount = 0;
            lastCheckPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

        protected override void PlayerSystemPlayerMoveEventHandler(PlayerMoveEvent data, Player group)
        {
            base.PlayerSystemPlayerMoveEventHandler(data, group);
            group.transform.Translate(new Vector3(data.movement.x, 0, data.movement.y) * (float)group.moveSpeed, Space.Self);
            group.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        }

        protected override void PlayerSystemJumpEventHandler(JumpEvent data, Player @group)
        {
            base.PlayerSystemJumpEventHandler(data, @group);

            if (jumpCount < 2) {
                jumpCount++;
                group.GetComponent<Rigidbody>().velocity = new Vector3();
                group.GetComponent<Rigidbody>().AddForce(new Vector3(0,group.jumpForce,0));
            }
        }

        protected override void PlayerSystemOnCollisionEnterHandler(OnCollisionEnterDispatcher data, Bullet collider, Player source)
        {
            base.PlayerSystemOnCollisionEnterHandler(data, collider, source);
            Publish(new DeathEvent());
        }

        protected override void PlayerSystemOnTriggerEnterHandler(OnTriggerEnterDispatcher data, Checkpoint collider, Player source)
        {
            base.PlayerSystemOnTriggerEnterHandler(data, collider, source);
            lastCheckPoint = collider.transform.position;
            collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        protected override void PlayerSystemDeathEventHandler(DeathEvent data, Player @group)
        {
            base.PlayerSystemDeathEventHandler(data, @group);
            group.transform.position = lastCheckPoint;
        }

        protected override void PlayerSystemFeetOnTriggerEnterHandler(OnTriggerEnterDispatcher data, Feet source)
        {
            base.PlayerSystemFeetOnTriggerEnterHandler(data, source);
            Debug.Log("grounded");
            jumpCount = 0;
        }
    }
}
