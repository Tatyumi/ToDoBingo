

namespace CommonConstans
{
    // シーン名
    public static class SceneName
    {
        /// <summary>タイトルシーン</summary>
        public const string TITLE_SCENE_NAME = "TitleScene";
        /// <summary>ビンゴシーン</summary>
        public const string BINGO_SCENE_NAME = "BingoScene";
    }

    // SEまたはBGM名
    public static class SoundName
    {
        /// <summary>タイトルシーンBGM</summary>
        public const string TITLE_SCENE_BGM = "TitleSceneBGM";
        /// <summary>ビンゴシーンBGM</summary>
        public const string BINGO_SCENE_BGM = "BingoSceneBGM";
        /// <summary>バックボタンSE</summary>
        public const string BACK_BUTTON_SE = "BackButtonSE";
        /// <summary>ビンゴチェック時のSE</summary>
        public const string CHECK_BINGO_SE = "CheckBingoSE";
        /// <summary>パネル表示SE</summary>
        public const string DISPLAY_PANEL_SE = "DisplayPanelSE";
        /// <summary>シーン遷移時のSE</summary>
        public const string MOVE_SCENE_SE = "MoveSceneSE";
        /// <summary>NOボタンSE</summary>
        public const string NO_BUTTON_SE = "NoButtonSE";
        /// <summary>TODOリストセーブ時のSE</summary>
        public const string SAVE_TODOLIST_SE = "SaveTodoListSE";
        /// <summary>ビンゴマス選択時のSE</summary>
        public const string SELECT_MASS_SE = "SelectMassSE";
        /// <summary>穴の状態を切り替える時のSE</summary>
        public const string SWITCH_HOLL_SE = "SwitchHollSE";
    }

    // オブジェクト名
    public static class ObjectName
    {
        /// <summary>オーディオマネージャー</summary>
        public const string AUDIO_MANAGER = "AudioManager";
        /// <summary>穴の画像</summary>
        public const string HOLL_IMAGE = "HollImage";
    }

    // 値
    public static class Value
    {
        /// <summary>横マスの数</summary>
        public const int BINGO_SHEET_LENGTH = 3;
        /// <summary>縦マスの数</summary>
        public const int BINGO_SHEET_RANK = 3;
    }

    // セーブする際に用いるキー
    public static class SaveKey
    {
        /// <summary>初回起動判別キー</summary>
        public const string FIRST_START_KEY = "FIRSTSTART";
        /// <summary>ビンゴ数</summary>
        public const string BINGO_COUNT_KEY = "BINGOCOUNT";
    }
}
