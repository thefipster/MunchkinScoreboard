﻿using System;
using TheFipster.Munchkin.GameDomain.Messages;
using TheFipster.Munchkin.GamePersistance;
using TheFipster.Munchkin.GameStorageVolatile;

namespace TheFipster.Munchkin.GameEngine.UnitTest.Helper
{
    public class QuestFactory
    {
        public static Quest Create(IGameStore gameStore)
        {
            var actionInventory = new ActionInventory();
            var actionFactory = new ReflectedActionFactory(actionInventory);
            return new Quest(gameStore, actionFactory);
        }

        public static Quest CreateStored(out IGameStore gameStore, out Guid gameId)
        {
            gameStore = new MockedGameStore();
            var quest = Create(gameStore);
            gameId = quest.StartJourney();
            return quest;
        }

        public static Quest CreateStarted(out IGameStore gameStore, out Guid gameId, out Sequence sequence)
        {
            var quest = CreateStored(out gameStore, out gameId);
            sequence = new Sequence();
            startQuest(quest, sequence, gameId);
            return quest;
        }

        public static Quest CreateStartedWithMaleHero(out IGameStore gameStore, out Guid gameId, out Guid playerId, out Sequence sequence)
        {
            var quest = CreateStarted(out gameStore, out gameId, out sequence);
            addMaleHeroToQuest(quest, sequence, gameId, out playerId);
            return quest;
        }

        private static void startQuest(Quest quest, Sequence sequence, Guid gameId)
        {
            var startMsg = StartMessage.Create(sequence.Next);
            quest.AddMessage(gameId, startMsg);
        }

        private static void addMaleHeroToQuest(Quest quest, Sequence sequence, Guid gameId, out Guid playerId)
        {
            var player = PlayerFactory.CreateMale("John Doe");
            var heroAddMsg = PlayerMessage.CreateAdd(sequence.Next, new[] { player });
            quest.AddMessage(gameId, heroAddMsg);
            playerId = player.Id;
        }
    }
}
