﻿using TheFipster.Munchkin.GameDomain;
using TheFipster.Munchkin.GameDomain.Exceptions;
using TheFipster.Munchkin.GameDomain.Messages;

namespace TheFipster.Munchkin.GameEngine.Actions
{
    public class StartAction : MessageAction
    {
        public StartAction(GameMessage message, Game game)
            : base(message, game) { }

        public new StartMessage Message => (StartMessage)base.Message;

        public override Game Do()
        {
            base.Do();
            Game.Score.Begin = Message.Timestamp;
            return Game;
        }

        public override Game Undo()
        {
            base.Undo();
            Game.Score.Begin = null;
            return Game;
        }

        public override void Validate()
        {
            if (IsGameStarted)
                throw new InvalidActionException("The adventure has already begun my young hero.");
        }
    }
}
