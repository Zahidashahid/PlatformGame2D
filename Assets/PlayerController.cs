// GENERATED AUTOMATICALLY FROM 'Assets/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""7e13e865-dbdc-4968-be66-2be62dec2a49"",
            ""actions"": [
                {
                    ""name"": ""RightMove"",
                    ""type"": ""Button"",
                    ""id"": ""504b0c5f-9af0-467b-8ab5-4a3f7465ec65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMove"",
                    ""type"": ""Button"",
                    ""id"": ""686922bd-8324-4559-9c87-33dc990d5fb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2834dd03-21b9-486c-bd3a-8674c9f0f480"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MelleAttackGP"",
                    ""type"": ""Button"",
                    ""id"": ""a7b896e3-26a1-4f64-a8fa-08fcd9c5a5af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackGP"",
                    ""type"": ""Button"",
                    ""id"": ""84a06783-dec8-4073-b3c3-5d9be024446c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""a46efaac-8c61-4dec-850c-4d3ff20c2da3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DashMove"",
                    ""type"": ""Button"",
                    ""id"": ""60bc66c6-3b18-461c-8be0-e96e83f4c729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArowHit"",
                    ""type"": ""Button"",
                    ""id"": ""d2478ee7-ccb3-4cb8-a660-ee3153ce16c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""2266e04c-2f3c-42ae-a4be-956ff407942a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": "" Shield"",
                    ""type"": ""Button"",
                    ""id"": ""0681b884-a49f-4429-8d07-af4484170a7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""22e3aa51-ac89-415a-b1e8-836afccb062d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b62f796-6ff5-44b1-a52a-8ff2a3cd67b3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da2ce488-8446-43c3-8739-a2e18bb26827"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56858809-943e-4709-aa63-3f29da25bd72"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cbbd603-3ee2-4f8f-87eb-1429ef70da89"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7255c37-8bf5-4957-9ab1-a95f9ccf0644"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de655bb6-755a-4c5c-b85c-68079390d416"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3e38b09-865b-496e-8883-2e8f57260d15"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89475d0a-7a81-4060-8a92-72c1add8dbf5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MelleAttackGP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e4bac4c-be63-4bf5-b6bb-93794a66ee70"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MelleAttackGP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9fda6ec-50f4-44ab-8c64-35605874c633"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackGP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b4b0ceb-6e95-46f7-b277-1bdeba56da8c"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e539adb5-d71e-43f8-8a3a-e47f161a003e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4431da22-5c98-4c22-a4d8-29e8f9ad1f0b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62133045-a964-49c3-87e2-ffcdd6a86bdf"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArowHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fcad6e7-0c81-4771-a56d-499bfe5b6966"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArowHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0220a277-343e-4093-94c7-e5bd5ca94165"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2f0329c-4c6e-4780-b429-925f7cbfd8c4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": "" Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adcf3a7b-8821-47ae-b37f-d41fb5dd7253"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": "" Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_RightMove = m_Gameplay.FindAction("RightMove", throwIfNotFound: true);
        m_Gameplay_LeftMove = m_Gameplay.FindAction("LeftMove", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_MelleAttackGP = m_Gameplay.FindAction("MelleAttackGP", throwIfNotFound: true);
        m_Gameplay_RangeAttackGP = m_Gameplay.FindAction("RangeAttackGP", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_DashMove = m_Gameplay.FindAction("DashMove", throwIfNotFound: true);
        m_Gameplay_ArowHit = m_Gameplay.FindAction("ArowHit", throwIfNotFound: true);
        m_Gameplay_PauseGame = m_Gameplay.FindAction("PauseGame", throwIfNotFound: true);
        m_Gameplay_Shield = m_Gameplay.FindAction(" Shield", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_RightMove;
    private readonly InputAction m_Gameplay_LeftMove;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_MelleAttackGP;
    private readonly InputAction m_Gameplay_RangeAttackGP;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_DashMove;
    private readonly InputAction m_Gameplay_ArowHit;
    private readonly InputAction m_Gameplay_PauseGame;
    private readonly InputAction m_Gameplay_Shield;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightMove => m_Wrapper.m_Gameplay_RightMove;
        public InputAction @LeftMove => m_Wrapper.m_Gameplay_LeftMove;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @MelleAttackGP => m_Wrapper.m_Gameplay_MelleAttackGP;
        public InputAction @RangeAttackGP => m_Wrapper.m_Gameplay_RangeAttackGP;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @DashMove => m_Wrapper.m_Gameplay_DashMove;
        public InputAction @ArowHit => m_Wrapper.m_Gameplay_ArowHit;
        public InputAction @PauseGame => m_Wrapper.m_Gameplay_PauseGame;
        public InputAction @Shield => m_Wrapper.m_Gameplay_Shield;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @RightMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMove;
                @RightMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMove;
                @RightMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMove;
                @LeftMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMove;
                @LeftMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMove;
                @LeftMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @MelleAttackGP.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackGP;
                @MelleAttackGP.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackGP;
                @MelleAttackGP.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackGP;
                @RangeAttackGP.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackGP;
                @RangeAttackGP.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackGP;
                @RangeAttackGP.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackGP;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @DashMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashMove;
                @DashMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashMove;
                @DashMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashMove;
                @ArowHit.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArowHit;
                @ArowHit.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArowHit;
                @ArowHit.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArowHit;
                @PauseGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @Shield.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShield;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightMove.started += instance.OnRightMove;
                @RightMove.performed += instance.OnRightMove;
                @RightMove.canceled += instance.OnRightMove;
                @LeftMove.started += instance.OnLeftMove;
                @LeftMove.performed += instance.OnLeftMove;
                @LeftMove.canceled += instance.OnLeftMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MelleAttackGP.started += instance.OnMelleAttackGP;
                @MelleAttackGP.performed += instance.OnMelleAttackGP;
                @MelleAttackGP.canceled += instance.OnMelleAttackGP;
                @RangeAttackGP.started += instance.OnRangeAttackGP;
                @RangeAttackGP.performed += instance.OnRangeAttackGP;
                @RangeAttackGP.canceled += instance.OnRangeAttackGP;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @DashMove.started += instance.OnDashMove;
                @DashMove.performed += instance.OnDashMove;
                @DashMove.canceled += instance.OnDashMove;
                @ArowHit.started += instance.OnArowHit;
                @ArowHit.performed += instance.OnArowHit;
                @ArowHit.canceled += instance.OnArowHit;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnRightMove(InputAction.CallbackContext context);
        void OnLeftMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMelleAttackGP(InputAction.CallbackContext context);
        void OnRangeAttackGP(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnDashMove(InputAction.CallbackContext context);
        void OnArowHit(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
    }
}
