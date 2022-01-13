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
                    ""name"": ""MouseDirection"",
                    ""type"": ""Value"",
                    ""id"": ""4d692f18-3d81-4f78-8f63-bbfffcdebaf3"",
                    ""expectedControlType"": ""Vector2"",
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
                    ""name"": ""MelleAttackSinglePlayer"",
                    ""type"": ""Button"",
                    ""id"": ""a7b896e3-26a1-4f64-a8fa-08fcd9c5a5af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Multiplayer1Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cdf15ea4-6124-4861-aac5-c220956d5d64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackGP"",
                    ""type"": ""Value"",
                    ""id"": ""84a06783-dec8-4073-b3c3-5d9be024446c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackPlayer1"",
                    ""type"": ""Value"",
                    ""id"": ""34a19aee-ae4a-4270-ac28-acdb8faedde7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackPlayer2"",
                    ""type"": ""Value"",
                    ""id"": ""dd580252-0b05-48f4-95a5-69912b5d1767"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a46efaac-8c61-4dec-850c-4d3ff20c2da3"",
                    ""expectedControlType"": ""Vector2"",
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
                },
                {
                    ""name"": ""Multiplayer1Movement"",
                    ""type"": ""Value"",
                    ""id"": ""51c5a356-112d-42b9-b736-dc13b1106f31"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Multiplayer2Movement"",
                    ""type"": ""Button"",
                    ""id"": ""1e862d4e-7c4a-48e8-ba36-0467a60e3547"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Multiplayer2Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ecf9adca-81e2-4c3e-93ca-97feb432831f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MelleAttackByKeyboard"",
                    ""type"": ""Button"",
                    ""id"": ""bcb0eebc-b2bf-43b6-98eb-dc11bd5a483f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MPPlayer1Dashmove"",
                    ""type"": ""Button"",
                    ""id"": ""e3c58dfb-f3ef-4b0a-81ba-44494e53e5f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MPPlayeer2Dashmove"",
                    ""type"": ""Button"",
                    ""id"": ""fc63e9bf-e454-4f99-847f-239e14c14907"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArrowShootP1"",
                    ""type"": ""Button"",
                    ""id"": ""30958a41-4ed8-40c4-8c8d-1d2f27084be5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArrowShootP2"",
                    ""type"": ""Button"",
                    ""id"": ""01e2951f-3445-4983-ac18-465017ff13e0"",
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
                    ""id"": ""1cc411d3-fe1a-4819-8a87-c13ccad93a61"",
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
                    ""id"": ""a9fda6ec-50f4-44ab-8c64-35605874c633"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackGP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Bow"",
                    ""id"": ""30b15449-a164-4cd2-afe3-0f188b6c1496"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackGP"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""c632a606-f12c-48cb-9416-74cfda36ed28"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackGP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""6c206f7f-176c-4502-a768-ab15e822280e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackGP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4b4b0ceb-6e95-46f7-b277-1bdeba56da8c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Movement"",
                    ""id"": ""81854ab4-af5a-4aa0-8121-ade7bf0d233a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""91d5d712-6a71-4058-863d-c5254619fc95"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""215a83b7-7924-42e5-bed4-397da6d70f0b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e64d127b-a7f6-48fb-9a56-b9c4e337607d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0f7a3108-a7f7-4656-b687-9efbf9217926"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""path"": ""<Keyboard>/o"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""2a06a470-f0c6-4ac8-bf9b-e57fab319c5c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e74776ad-f0d1-43a8-a363-554826d62673"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer2Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9d1dc019-90f6-477c-a12b-633590b0c5ac"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""898a0b9b-ceb2-4556-b85e-879e8cd297ff"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d872d0ad-19d6-4d1f-8d86-628078c9c4a9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6e2b172c-5f5b-4769-9599-d767929a8e85"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""37084a1b-01eb-4d26-ba21-f5a1487afa1a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer2Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""087f3248-0879-4b94-960f-c7faba72a692"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MelleAttackByKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20c6d516-3ee8-405d-baa4-8bf7775799bd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MPPlayer1Dashmove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6e22820-4039-436a-9189-8136338d1fdc"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MPPlayeer2Dashmove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a37e105-bc42-4c0e-9afb-f5f84bedb147"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackPlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Bow"",
                    ""id"": ""51a4c0e2-887a-42ac-b34c-106c4344a69a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackPlayer2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""5ff81b52-e3e7-4aaa-acf4-0a30a95d8a74"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackPlayer2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""13cec73f-327a-4a60-ae36-63e37cef42b0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackPlayer2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d43769c3-d10f-4bca-91c6-03d078be13ae"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowShootP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e05eaf8e-7d73-43f6-ae34-f686f2130dd2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowShootP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cefaeff-1341-4298-abef-223df06d7ccc"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multiplayer1Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ec88e6-ad7f-47ba-aa15-8fe41a227a95"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDirection"",
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
                    ""action"": ""MelleAttackSinglePlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee9c258e-7759-4f97-8dc7-62d343565740"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MelleAttackSinglePlayer"",
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
        m_Gameplay_MouseDirection = m_Gameplay.FindAction("MouseDirection", throwIfNotFound: true);
        m_Gameplay_DashMove = m_Gameplay.FindAction("DashMove", throwIfNotFound: true);
        m_Gameplay_MelleAttackSinglePlayer = m_Gameplay.FindAction("MelleAttackSinglePlayer", throwIfNotFound: true);
        m_Gameplay_Multiplayer1Jump = m_Gameplay.FindAction("Multiplayer1Jump", throwIfNotFound: true);
        m_Gameplay_RangeAttackGP = m_Gameplay.FindAction("RangeAttackGP", throwIfNotFound: true);
        m_Gameplay_RangeAttackPlayer1 = m_Gameplay.FindAction("RangeAttackPlayer1", throwIfNotFound: true);
        m_Gameplay_RangeAttackPlayer2 = m_Gameplay.FindAction("RangeAttackPlayer2", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_ArowHit = m_Gameplay.FindAction("ArowHit", throwIfNotFound: true);
        m_Gameplay_PauseGame = m_Gameplay.FindAction("PauseGame", throwIfNotFound: true);
        m_Gameplay_Shield = m_Gameplay.FindAction(" Shield", throwIfNotFound: true);
        m_Gameplay_Multiplayer1Movement = m_Gameplay.FindAction("Multiplayer1Movement", throwIfNotFound: true);
        m_Gameplay_Multiplayer2Movement = m_Gameplay.FindAction("Multiplayer2Movement", throwIfNotFound: true);
        m_Gameplay_Multiplayer2Jump = m_Gameplay.FindAction("Multiplayer2Jump", throwIfNotFound: true);
        m_Gameplay_MelleAttackByKeyboard = m_Gameplay.FindAction("MelleAttackByKeyboard", throwIfNotFound: true);
        m_Gameplay_MPPlayer1Dashmove = m_Gameplay.FindAction("MPPlayer1Dashmove", throwIfNotFound: true);
        m_Gameplay_MPPlayeer2Dashmove = m_Gameplay.FindAction("MPPlayeer2Dashmove", throwIfNotFound: true);
        m_Gameplay_ArrowShootP1 = m_Gameplay.FindAction("ArrowShootP1", throwIfNotFound: true);
        m_Gameplay_ArrowShootP2 = m_Gameplay.FindAction("ArrowShootP2", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_MouseDirection;
    private readonly InputAction m_Gameplay_DashMove;
    private readonly InputAction m_Gameplay_MelleAttackSinglePlayer;
    private readonly InputAction m_Gameplay_Multiplayer1Jump;
    private readonly InputAction m_Gameplay_RangeAttackGP;
    private readonly InputAction m_Gameplay_RangeAttackPlayer1;
    private readonly InputAction m_Gameplay_RangeAttackPlayer2;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_ArowHit;
    private readonly InputAction m_Gameplay_PauseGame;
    private readonly InputAction m_Gameplay_Shield;
    private readonly InputAction m_Gameplay_Multiplayer1Movement;
    private readonly InputAction m_Gameplay_Multiplayer2Movement;
    private readonly InputAction m_Gameplay_Multiplayer2Jump;
    private readonly InputAction m_Gameplay_MelleAttackByKeyboard;
    private readonly InputAction m_Gameplay_MPPlayer1Dashmove;
    private readonly InputAction m_Gameplay_MPPlayeer2Dashmove;
    private readonly InputAction m_Gameplay_ArrowShootP1;
    private readonly InputAction m_Gameplay_ArrowShootP2;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightMove => m_Wrapper.m_Gameplay_RightMove;
        public InputAction @LeftMove => m_Wrapper.m_Gameplay_LeftMove;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @MouseDirection => m_Wrapper.m_Gameplay_MouseDirection;
        public InputAction @DashMove => m_Wrapper.m_Gameplay_DashMove;
        public InputAction @MelleAttackSinglePlayer => m_Wrapper.m_Gameplay_MelleAttackSinglePlayer;
        public InputAction @Multiplayer1Jump => m_Wrapper.m_Gameplay_Multiplayer1Jump;
        public InputAction @RangeAttackGP => m_Wrapper.m_Gameplay_RangeAttackGP;
        public InputAction @RangeAttackPlayer1 => m_Wrapper.m_Gameplay_RangeAttackPlayer1;
        public InputAction @RangeAttackPlayer2 => m_Wrapper.m_Gameplay_RangeAttackPlayer2;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @ArowHit => m_Wrapper.m_Gameplay_ArowHit;
        public InputAction @PauseGame => m_Wrapper.m_Gameplay_PauseGame;
        public InputAction @Shield => m_Wrapper.m_Gameplay_Shield;
        public InputAction @Multiplayer1Movement => m_Wrapper.m_Gameplay_Multiplayer1Movement;
        public InputAction @Multiplayer2Movement => m_Wrapper.m_Gameplay_Multiplayer2Movement;
        public InputAction @Multiplayer2Jump => m_Wrapper.m_Gameplay_Multiplayer2Jump;
        public InputAction @MelleAttackByKeyboard => m_Wrapper.m_Gameplay_MelleAttackByKeyboard;
        public InputAction @MPPlayer1Dashmove => m_Wrapper.m_Gameplay_MPPlayer1Dashmove;
        public InputAction @MPPlayeer2Dashmove => m_Wrapper.m_Gameplay_MPPlayeer2Dashmove;
        public InputAction @ArrowShootP1 => m_Wrapper.m_Gameplay_ArrowShootP1;
        public InputAction @ArrowShootP2 => m_Wrapper.m_Gameplay_ArrowShootP2;
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
                @MouseDirection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDirection;
                @MouseDirection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDirection;
                @MouseDirection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDirection;
                @DashMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashMove;
                @DashMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashMove;
                @DashMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashMove;
                @MelleAttackSinglePlayer.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackSinglePlayer;
                @MelleAttackSinglePlayer.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackSinglePlayer;
                @MelleAttackSinglePlayer.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackSinglePlayer;
                @Multiplayer1Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer1Jump;
                @Multiplayer1Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer1Jump;
                @Multiplayer1Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer1Jump;
                @RangeAttackGP.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackGP;
                @RangeAttackGP.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackGP;
                @RangeAttackGP.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackGP;
                @RangeAttackPlayer1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackPlayer1;
                @RangeAttackPlayer1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackPlayer1;
                @RangeAttackPlayer1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackPlayer1;
                @RangeAttackPlayer2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackPlayer2;
                @RangeAttackPlayer2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackPlayer2;
                @RangeAttackPlayer2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRangeAttackPlayer2;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @ArowHit.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArowHit;
                @ArowHit.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArowHit;
                @ArowHit.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArowHit;
                @PauseGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @Shield.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShield;
                @Multiplayer1Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer1Movement;
                @Multiplayer1Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer1Movement;
                @Multiplayer1Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer1Movement;
                @Multiplayer2Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer2Movement;
                @Multiplayer2Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer2Movement;
                @Multiplayer2Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer2Movement;
                @Multiplayer2Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer2Jump;
                @Multiplayer2Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer2Jump;
                @Multiplayer2Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMultiplayer2Jump;
                @MelleAttackByKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackByKeyboard;
                @MelleAttackByKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackByKeyboard;
                @MelleAttackByKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelleAttackByKeyboard;
                @MPPlayer1Dashmove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMPPlayer1Dashmove;
                @MPPlayer1Dashmove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMPPlayer1Dashmove;
                @MPPlayer1Dashmove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMPPlayer1Dashmove;
                @MPPlayeer2Dashmove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMPPlayeer2Dashmove;
                @MPPlayeer2Dashmove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMPPlayeer2Dashmove;
                @MPPlayeer2Dashmove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMPPlayeer2Dashmove;
                @ArrowShootP1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArrowShootP1;
                @ArrowShootP1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArrowShootP1;
                @ArrowShootP1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArrowShootP1;
                @ArrowShootP2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArrowShootP2;
                @ArrowShootP2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArrowShootP2;
                @ArrowShootP2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArrowShootP2;
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
                @MouseDirection.started += instance.OnMouseDirection;
                @MouseDirection.performed += instance.OnMouseDirection;
                @MouseDirection.canceled += instance.OnMouseDirection;
                @DashMove.started += instance.OnDashMove;
                @DashMove.performed += instance.OnDashMove;
                @DashMove.canceled += instance.OnDashMove;
                @MelleAttackSinglePlayer.started += instance.OnMelleAttackSinglePlayer;
                @MelleAttackSinglePlayer.performed += instance.OnMelleAttackSinglePlayer;
                @MelleAttackSinglePlayer.canceled += instance.OnMelleAttackSinglePlayer;
                @Multiplayer1Jump.started += instance.OnMultiplayer1Jump;
                @Multiplayer1Jump.performed += instance.OnMultiplayer1Jump;
                @Multiplayer1Jump.canceled += instance.OnMultiplayer1Jump;
                @RangeAttackGP.started += instance.OnRangeAttackGP;
                @RangeAttackGP.performed += instance.OnRangeAttackGP;
                @RangeAttackGP.canceled += instance.OnRangeAttackGP;
                @RangeAttackPlayer1.started += instance.OnRangeAttackPlayer1;
                @RangeAttackPlayer1.performed += instance.OnRangeAttackPlayer1;
                @RangeAttackPlayer1.canceled += instance.OnRangeAttackPlayer1;
                @RangeAttackPlayer2.started += instance.OnRangeAttackPlayer2;
                @RangeAttackPlayer2.performed += instance.OnRangeAttackPlayer2;
                @RangeAttackPlayer2.canceled += instance.OnRangeAttackPlayer2;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ArowHit.started += instance.OnArowHit;
                @ArowHit.performed += instance.OnArowHit;
                @ArowHit.canceled += instance.OnArowHit;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @Multiplayer1Movement.started += instance.OnMultiplayer1Movement;
                @Multiplayer1Movement.performed += instance.OnMultiplayer1Movement;
                @Multiplayer1Movement.canceled += instance.OnMultiplayer1Movement;
                @Multiplayer2Movement.started += instance.OnMultiplayer2Movement;
                @Multiplayer2Movement.performed += instance.OnMultiplayer2Movement;
                @Multiplayer2Movement.canceled += instance.OnMultiplayer2Movement;
                @Multiplayer2Jump.started += instance.OnMultiplayer2Jump;
                @Multiplayer2Jump.performed += instance.OnMultiplayer2Jump;
                @Multiplayer2Jump.canceled += instance.OnMultiplayer2Jump;
                @MelleAttackByKeyboard.started += instance.OnMelleAttackByKeyboard;
                @MelleAttackByKeyboard.performed += instance.OnMelleAttackByKeyboard;
                @MelleAttackByKeyboard.canceled += instance.OnMelleAttackByKeyboard;
                @MPPlayer1Dashmove.started += instance.OnMPPlayer1Dashmove;
                @MPPlayer1Dashmove.performed += instance.OnMPPlayer1Dashmove;
                @MPPlayer1Dashmove.canceled += instance.OnMPPlayer1Dashmove;
                @MPPlayeer2Dashmove.started += instance.OnMPPlayeer2Dashmove;
                @MPPlayeer2Dashmove.performed += instance.OnMPPlayeer2Dashmove;
                @MPPlayeer2Dashmove.canceled += instance.OnMPPlayeer2Dashmove;
                @ArrowShootP1.started += instance.OnArrowShootP1;
                @ArrowShootP1.performed += instance.OnArrowShootP1;
                @ArrowShootP1.canceled += instance.OnArrowShootP1;
                @ArrowShootP2.started += instance.OnArrowShootP2;
                @ArrowShootP2.performed += instance.OnArrowShootP2;
                @ArrowShootP2.canceled += instance.OnArrowShootP2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnRightMove(InputAction.CallbackContext context);
        void OnLeftMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMouseDirection(InputAction.CallbackContext context);
        void OnDashMove(InputAction.CallbackContext context);
        void OnMelleAttackSinglePlayer(InputAction.CallbackContext context);
        void OnMultiplayer1Jump(InputAction.CallbackContext context);
        void OnRangeAttackGP(InputAction.CallbackContext context);
        void OnRangeAttackPlayer1(InputAction.CallbackContext context);
        void OnRangeAttackPlayer2(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnArowHit(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnMultiplayer1Movement(InputAction.CallbackContext context);
        void OnMultiplayer2Movement(InputAction.CallbackContext context);
        void OnMultiplayer2Jump(InputAction.CallbackContext context);
        void OnMelleAttackByKeyboard(InputAction.CallbackContext context);
        void OnMPPlayer1Dashmove(InputAction.CallbackContext context);
        void OnMPPlayeer2Dashmove(InputAction.CallbackContext context);
        void OnArrowShootP1(InputAction.CallbackContext context);
        void OnArrowShootP2(InputAction.CallbackContext context);
    }
}
