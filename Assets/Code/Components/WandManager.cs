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
    using uFrame.ECS.Components;
    using uFrame.Json;
    using UniRx;
    using UnityEngine;
    using ViveDB;
    
    
    [uFrame.Attributes.ComponentId(5)]
    [uFrame.Attributes.uFrameIdentifier("7414e1c0-7a71-4f3a-a753-c59cb979f1b9")]
    public partial class WandManager : uFrame.ECS.Components.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private WandLeft _Left;
        
        [UnityEngine.SerializeField()]
        private WandRight _Right;
        
        private Subject<PropertyChangedEvent<WandLeft>> _LeftObservable;
        
        private PropertyChangedEvent<WandLeft> _LeftEvent;
        
        private Subject<PropertyChangedEvent<WandRight>> _RightObservable;
        
        private PropertyChangedEvent<WandRight> _RightEvent;
        
        public override int ComponentId {
            get {
                return 5;
            }
        }
        
        public IObservable<PropertyChangedEvent<WandLeft>> LeftObservable {
            get {
                return _LeftObservable ?? (_LeftObservable = new Subject<PropertyChangedEvent<WandLeft>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<WandRight>> RightObservable {
            get {
                return _RightObservable ?? (_RightObservable = new Subject<PropertyChangedEvent<WandRight>>());
            }
        }
        
        public WandLeft Left {
            get {
                return _Left;
            }
            set {
                SetLeft(value);
            }
        }
        
        public WandRight Right {
            get {
                return _Right;
            }
            set {
                SetRight(value);
            }
        }
        
        public virtual void SetLeft(WandLeft value) {
            SetProperty(ref _Left, value, ref _LeftEvent, _LeftObservable);
        }
        
        public virtual void SetRight(WandRight value) {
            SetProperty(ref _Right, value, ref _RightEvent, _RightObservable);
        }
    }
}