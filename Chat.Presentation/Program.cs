using Chat.Presentation.Factories;
using Chat.Presentation.Extensions;


var mainMenuActions = MainMenuFactory.CreateActions();
mainMenuActions.PrintActionsAndOpen();