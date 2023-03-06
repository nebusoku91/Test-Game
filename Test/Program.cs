GameEvents gameEvents = new GameEvents();
Game newGame = new Game(gameEvents);
Player player = gameEvents.PlayerCreateEvent();

gameEvents.ExperienceGainEvent(player, 100);

newGame.LaunchMenu(player);