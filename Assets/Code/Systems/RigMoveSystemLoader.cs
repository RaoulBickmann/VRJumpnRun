// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace ViveDB {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.ECS.UnityUtilities;
    using uFrame.Kernel;
    
    
    [uFrame.Attributes.uFrameIdentifier("34f3c15a-b548-4ee1-8a0d-2595341c0c9a")]
    public partial class RigMoveSystemLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            this.AddSystem<RigMoveSystem>();
        }
    }
}
