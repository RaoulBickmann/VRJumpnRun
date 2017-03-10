using uFrame.ECS.UnityUtilities;
using UnityEngine.SceneManagement;

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

        private SteamVR_Controller.Device leftController;
        private SteamVR_Controller.Device rightController;
        private GameObject grabbedGameObjectLeft;
        private GameObject grabbedGameObjectRight;

        private GameObject Menu;



		public int i = 0;

		protected LineRenderer lineRenderer;
		protected Vector3[] lineRendererVertices;

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
		private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
        private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;


        protected override void InputSystemKernelLoadedHandler(KernelLoadedEvent data, WandManager group)
        {
            base.InputSystemKernelLoadedHandler(data, group);
            leftController = SteamVR_Controller.Input ((int)group.Left.GetComponent<SteamVR_TrackedObject>().index);
			rightController = SteamVR_Controller.Input ((int)group.Right.GetComponent<SteamVR_TrackedObject>().index);
            Menu = GameObject.FindGameObjectWithTag("Menu");
            Publish(new MenuEvent());
        }

        protected override void InputSystemUpdateLeftHandler(WandLeft group)
        {
            base.InputSystemUpdateLeftHandler(group);
            if (leftController.GetTouch(touchPad))
            {
                var moveEvent = new RigMoveEvent();
                moveEvent.movement = leftController.GetAxis(touchPad) * Time.deltaTime;
                Publish(moveEvent);
            }
            if (leftController.GetPressDown(menuButton))
            {
                Publish(new MenuEvent());
            }
        }

        protected override void InputSystemUpdateRightHandler(WandRight group)
        {
            base.InputSystemUpdateRightHandler(group);
            if (rightController.GetTouch(touchPad))
            {
                var moveEvent = new PlayerMoveEvent();
                moveEvent.movement = rightController.GetAxis(touchPad) * Time.deltaTime;
                Publish(moveEvent);
            }
            if (!rightController.GetPress(triggerButton) && grabbedGameObjectRight != null)
            {
                grabbedGameObjectRight.transform.SetParent(null);
            }
            if (rightController.GetPressDown(touchPad))
            {
                Publish(new JumpEvent());
            }
        }

        protected override void InputSystemOnTriggerEnterHandler(OnTriggerEnterDispatcher data, Grabable collider, WandRight source)
        {
            base.InputSystemOnTriggerEnterHandler(data, collider, source);
            Debug.Log("Enter");
            Debug.Log(collider + "" + source);

        }

        protected override void InputSystemOnTriggerStayHandler(OnTriggerStayDispatcher data, Grabable collider, WandRight source)
        {
            base.InputSystemOnTriggerStayHandler(data, collider, source);
            if (grabbedGameObjectRight == null)
            {
                grabbedGameObjectRight = collider.gameObject;
                grabbedGameObjectRight.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if (rightController.GetPress(triggerButton) && grabbedGameObjectRight.transform.parent != source.gameObject.transform)
            {
                grabbedGameObjectRight.transform.SetParent(source.transform, true);
            }
        }


        protected override void InputSystemOnTriggerExitHandler(OnTriggerExitDispatcher data, Grabable collider, WandRight source)
        {
            base.InputSystemOnTriggerExitHandler(data, collider, source);
            Debug.Log("Exit");
            if(grabbedGameObjectRight != null)
            {
                if(grabbedGameObjectRight.transform.parent != source.gameObject.transform)
                {
                    grabbedGameObjectRight.GetComponent<MeshRenderer>().material.color = Color.green;
                    grabbedGameObjectRight = null;
                }

            }

        }

        protected override void InputSystemMenuEventHandler(MenuEvent data, WandRight group)
        {
            base.InputSystemMenuEventHandler(data, group);
            Menu.SetActive(!Menu.activeSelf);

        }

        protected override void InputSystemMenuOnTriggerEnterHandler(OnTriggerEnterDispatcher data, Menu collider, WandRight source)
        {
            base.InputSystemMenuOnTriggerEnterHandler(data, collider, source);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Restart");
        }
    }
}


