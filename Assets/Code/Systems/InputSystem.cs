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
    
    
    public partial class InputSystem
    {

        public SteamVR_TrackedObject trackedObj;
        private SteamVR_Controller.Device controller;

        //k_EButton_System = 0,
	    //k_EButton_ApplicationMenu = 1,
	    //k_EButton_Grip = 2,
	    //k_EButton_DPad_Left = 3,
	    //k_EButton_DPad_Up = 4,
	    //k_EButton_DPad_Right = 5,
	    //k_EButton_DPad_Down = 6,
	    //k_EButton_A = 7,
	    //k_EButton_ProximitySensor = 31,
	    //k_EButton_Axis0 = 32,
	    //k_EButton_Axis1 = 33,
	    //k_EButton_Axis2 = 34,
	    //k_EButton_Axis3 = 35,
	    //k_EButton_Axis4 = 36,
	    //k_EButton_SteamVR_Touchpad = 32,
	    //k_EButton_SteamVR_Trigger = 33,
	    //k_EButton_Dashboard_Back = 2,
	    //k_EButton_Max = 64,

        private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
        private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

        protected override void InputSystemKernelLoadedHandler(KernelLoadedEvent data, Wand group)
        {
            base.InputSystemKernelLoadedHandler(data, group);
            trackedObj = group.GetComponent<SteamVR_TrackedObject>();
            //controller = SteamVR_Controller.Input((int)trackedObj.index);
        }

        protected override void InputSystemUpdateHandler(Wand @group)
        {
            base.InputSystemUpdateHandler(@group);

            //if (controller.GetPress(gripButton))
            //{
            //    Debug.Log("GripButton Pressed");
            //}
            //if (controller.GetPress(triggerButton))
            //{
            //    Debug.Log("TriggerButton Pressed");
            //}
            Publish(new TriggerEvent());
        }
    }
}
