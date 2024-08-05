Load order: BootstrapLoader(editor only) -> ProjectInstaller -> BootstrapInstaller -> AutoStartupperGlobal -> ProjectLoadState -> HubStateGlobal -> HubLoadState -> HubState  ->:
    -> HubUnLoadState (anyway)
    
    -> GameplayStateGlobal -> GameplayLoadState -> GameplayState ->:
        -> GameplayUnLoadState(anyway)
        -> GameplayGameOverState
    
    -> GameplayOnlineStateGlobal -> GameplayOnlineLoadState -> GameplayOnlineState ->:
        -> GameplayOnlineUnLoadState(anyway)
    
    -> ProjectUnloadState(anyway)

Assemdefs connections: 
    Common <- nothing. -> everything
    CompositionRoot <- everything. -> nothing
    Gameplay <- Common. -> GameplayOnline, CompositionRoot
    GameplayOnline <- Common, Gameplay. -> CompositionRoot
    
Problems:
    Audio bug when camera closing.
    SaveLoader the same place to save the editor and the Windows progress.
    Car spawn bug.
    Android iap bug (iap is not fully configured?).
    UI layout items are not updated on time (unity bug ?).
    I can load offline scene when loading network scene (make loadingScreen?).

Discarded:
        Important: Network
        Optional SDKs: Facebook SDK, FirebaseSDK, GameAnalytics SDK    
        Optional tyres sound system & engine sound system
        Optional Leaderboard in room (All players drift points)
        Optional Web request (ex: get image from url and place on car body, or ex: stream radio music into the game)

Errors:
    Win32Exception: https://stackoverflow.com/a/77072270/23794352
