﻿using StateMachineKT.StateMachine.Data;

namespace StateMachineKT.Player.PlayerStates
{
    public class InvisibleState : AState
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerAbilities _playerAbilities;
        
        private bool _isInvisible;
        
        public InvisibleState(IStateMachine owner, PlayerInput input, PlayerAbilities playerAbilities) : base(owner)
        {
            _playerInput = input;
            _playerAbilities = playerAbilities;
        }

        private void OnAttack()
        {
            _isInvisible = !_isInvisible;
            _playerAbilities.SetPlayerInvisibleStatus(_isInvisible);
        }
        
        public override void Enter()
        {
            _playerInput.OnAttack += OnAttack;
        }

        public override void Exit()
        {
            _playerInput.OnAttack -= OnAttack;
            _isInvisible = false;
            _playerAbilities.SetPlayerInvisibleStatus(false);
        }
    }
}