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

        protected override void PlayerSystemPlayerMoveEventHandler(PlayerMoveEvent data, Player group)
        {
            base.PlayerSystemPlayerMoveEventHandler(data, group);
            group.transform.Translate(new Vector3(data.movement.x, 0, data.movement.y), Space.Self);
            group.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            //vllt lieber ins update
            group.transform.Translate(new Vector3(data.movement.x, 0, data.movement.y), Space.Self);
        }

        protected override void PlayerSystemJumpEventHandler(JumpEvent data, Player @group)
        {
            base.PlayerSystemJumpEventHandler(data, @group);
            Debug.Log("123");
            group.GetComponent<Rigidbody>().velocity = new Vector3();
            group.GetComponent<Rigidbody>().AddForce(new Vector3(0,200,0));
        }
    }
}
