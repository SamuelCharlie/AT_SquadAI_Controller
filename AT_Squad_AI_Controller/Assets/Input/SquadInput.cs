//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Input/SquadInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @SquadInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SquadInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SquadInput"",
    ""maps"": [
        {
            ""name"": ""SquadController"",
            ""id"": ""98bc655a-168a-4216-b265-4f8c0701bb64"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""58a0d349-2941-4e05-a904-e8c352f67ffb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f47c29e-f5bf-4a7d-8c36-aee132816efd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // SquadController
        m_SquadController = asset.FindActionMap("SquadController", throwIfNotFound: true);
        m_SquadController_Move = m_SquadController.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // SquadController
    private readonly InputActionMap m_SquadController;
    private ISquadControllerActions m_SquadControllerActionsCallbackInterface;
    private readonly InputAction m_SquadController_Move;
    public struct SquadControllerActions
    {
        private @SquadInput m_Wrapper;
        public SquadControllerActions(@SquadInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_SquadController_Move;
        public InputActionMap Get() { return m_Wrapper.m_SquadController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SquadControllerActions set) { return set.Get(); }
        public void SetCallbacks(ISquadControllerActions instance)
        {
            if (m_Wrapper.m_SquadControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_SquadControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_SquadControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_SquadControllerActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_SquadControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public SquadControllerActions @SquadController => new SquadControllerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface ISquadControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
