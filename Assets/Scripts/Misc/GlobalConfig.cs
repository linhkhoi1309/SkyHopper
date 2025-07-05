public static class GlobalConfig {
    // Game object tags
    public const string PLAYER_TAG = "Player";

    // UI toolkit element names

    public const string START_BUTTON_NAME = "StartButton";
    public const string SETTINGS_BUTTON_NAME = "SettingsButton";
    public const string POPUP_SETTINGS_NAME = "SettingsPopup";
    public const string POPUP_SETTINGS_CLOSE_BUTTON_NAME = "CloseSettingsButton";
    public const string MUSIC_VOLUME_SLIDER_NAME = "MusicSlider";
    public const string SOUND_VOLUME_SLIDER_NAME = "SfxSlider";
    public const string LANGUAGE_DROPDOWN_NAME = "LanguageDropdown";

    // PlayerPrefs keys

    public const string MUSIC_VOLUME_PREFS_KEY = "MusicVolume";
    public const string SOUND_VOLUME_PREFS_KEY = "SfxVolume";
    public const string LANGUAGE_PREFS_KEY = "Language";

    // Scene build indices

    public const int MAIN_MENU_SCENE_BUILD_INDEX = 0;
    public const int LEVEL_SCENE_BUILD_INDEX = 1;
    public const int GAME_OVER_SCENE_BUILD_INDEX = 2;
}