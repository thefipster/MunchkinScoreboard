﻿using TheFipster.Munchkin.GameDomain;
using TheFipster.Munchkin.GameDomain.Exceptions;
using TheFipster.Munchkin.GameDomain.Messages;

namespace TheFipster.Munchkin.GameEngine.Actions
{
    public class FightStartAction : GameAction
    {
        public FightStartAction(GameMessage message, Game game) 
            : base(message, game) { }

        public new FightStartMessage Message => (FightStartMessage)base.Message;

        public override Game Do()
        {
            var hero = Game.GetHero(Message.PlayerId);
            var fight = new Fight(hero, Message.Monster);
            Game.Score.Fight = fight;

            return base.Do();
        }

        public override void Validate()
        {
            base.Validate();

            if (!IsGameStarted)
                throw new InvalidActionException("Perfect, not even in the dungeon but still starting a fight.");

            if (Game.Score.Fight != null)
                throw new InvalidActionException("Let's finish the current fight first... then maybe.");
        }
    }
}
