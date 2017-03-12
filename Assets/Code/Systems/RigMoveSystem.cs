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
            Vector3 temp = new Vector3(data.movement.x, 0, data.movement.y);
            temp = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * temp;
            group.transform.Translate(temp * 1.5f , Space.Self);
        }
    }
}
