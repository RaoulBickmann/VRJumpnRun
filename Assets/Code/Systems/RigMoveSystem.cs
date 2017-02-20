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
    
    
    public partial class RigMoveSystem {

        protected override void RigMoveSystemRigMoveEventHandler(RigMoveEvent data, Rig group)
        {
            base.RigMoveSystemRigMoveEventHandler(data, group);
            //group.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            //group.transform.Translate (new Vector3(group.transform.forward.x * data.movement.x, 0, group.transform.forward.y * data.movement.y), Space.World);
            Vector2 temp = Camera.main.transform.rotation * data.movement;
            group.transform.Translate(new Vector3(temp.x, 0, temp.y) , Space.Self);
        }
    }
}
