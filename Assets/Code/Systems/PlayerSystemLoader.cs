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
    
    
    [uFrame.Attributes.uFrameIdentifier("d549aa45-7425-4a1b-af59-82c8d6e66a22")]
    public partial class PlayerSystemLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            this.AddSystem<PlayerSystem>();
        }
    }
}