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

        protected override void Start()
        {
            base.Start();
            jumpCount = 0;
        }

        protected override void PlayerSystemPlayerMoveEventHandler(PlayerMoveEvent data, Player group)
        {
            base.PlayerSystemPlayerMoveEventHandler(data, group);
            group.transform.Translate(new Vector3(data.movement.x, 0, data.movement.y) * 0.75f, Space.Self);
            group.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            //vllt lieber ins update
        }

        protected override void PlayerSystemJumpEventHandler(JumpEvent data, Player @group)
        {
            base.PlayerSystemJumpEventHandler(data, @group);
            float temp = group.GetComponent<Collider>().bounds.extents.y + 0.01f;

            if (jumpCount < 2) {
                jumpCount++;
                group.GetComponent<Rigidbody>().velocity = new Vector3();
                group.GetComponent<Rigidbody>().AddForce(new Vector3(0,100,0));
            } else if (Physics.Raycast(group.transform.position, -Vector3.up, temp))
            {
                jumpCount = 1;
                group.GetComponent<Rigidbody>().velocity = new Vector3();
                group.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
            }
        }
    }
}
