using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GameTimeConverter
{
    public class LanguageManager
    {
        private readonly ComboBox languageComboBox;
        private readonly Form mainForm;
        private readonly Dictionary<string, Dictionary<string, string>> translations;

        private readonly HashSet<string> excludedLabels = new()
        {
            "labelTaipeiTimeResult",
            "labelNewYorkTimeResult",
        };
        public string CurrentLanguage { get; private set; } = "zh-TW";

        public LanguageManager(ComboBox comboBox, Form form)
        {
            languageComboBox = comboBox;
            mainForm = form;
            translations = LoadTranslations();

            InitializeLanguageComboBox();
            languageComboBox.SelectedIndexChanged += LanguageChanged;
        }

        private void InitializeLanguageComboBox()
        {
            languageComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.ItemHeight = 20;

            languageComboBox.Items.AddRange(
                new object[]
                {
                    new LanguageItem("zh-TW", "繁體中文", LoadImage("Flag_TW.png")),
                    new LanguageItem("zh-CN", "简体中文", LoadImage("Flag_CN.png")),
                    new LanguageItem("en", "English", LoadImage("Flag_GB.png")),
                    new LanguageItem("es", "Español", LoadImage("Flag_ES.png")),
                    new LanguageItem("fr", "Français", LoadImage("Flag_FR.png")),
                    new LanguageItem("de", "Deutsch", LoadImage("Flag_DE.png")),
                    new LanguageItem("ja", "日本語", LoadImage("Flag_JP.png")),
                    new LanguageItem("ko", "한국어", LoadImage("Flag_KR.png")),
                    new LanguageItem("ru", "Русский", LoadImage("Flag_RU.png")),
                    new LanguageItem("pt", "Português", LoadImage("Flag_PT.png")),
                }
            );

            languageComboBox.SelectedIndex = 0;
            languageComboBox.DrawItem += DrawLanguageItem;
        }

        private Image LoadImage(string fileName)
        {
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Resources",
                fileName
            );
            return File.Exists(path) ? Image.FromFile(path) : null;
        }

        private void DrawLanguageItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();

            ComboBox cb = (ComboBox)sender;
            LanguageItem item = (LanguageItem)cb.Items[e.Index];

            int imageSize = 16;
            int textXOffset = imageSize + 5;

            if (item.Flag != null)
                e.Graphics.DrawImage(
                    item.Flag,
                    e.Bounds.Left + 2,
                    e.Bounds.Top + 2,
                    imageSize,
                    imageSize
                );

            using Font font = new("Segoe UI", 9);
            e.Graphics.DrawString(
                item.DisplayText,
                font,
                Brushes.Black,
                e.Bounds.Left + textXOffset,
                e.Bounds.Top + 2
            );
            e.DrawFocusRectangle();
        }

        private void LanguageChanged(object sender, EventArgs e)
        {
            CurrentLanguage = ((LanguageItem)languageComboBox.SelectedItem).LanguageCode;
            ApplyTranslations();
        }

        private void ApplyTranslations()
        {
            if (!translations.ContainsKey(CurrentLanguage))
                return;

            foreach (Control ctrl in mainForm.Controls)
            {
                if (excludedLabels.Contains(ctrl.Name))
                    continue;
                if (translations[CurrentLanguage].ContainsKey(ctrl.Name))
                {
                    ctrl.Text = translations[CurrentLanguage][ctrl.Name];
                    if (ctrl is Label lbl)
                        UIHelper.AutoResizeLabelFont(lbl);
                }
            }
        }

        private Dictionary<string, Dictionary<string, string>> LoadTranslations() =>
            new()
            {
                {
                    "zh-TW",
                    new()
                    {
                        { "labelGame", "遊戲" },
                        { "labelLanguage", "語言" },
                        { "labelGameTime", "遊戲時間" },
                        { "labelTaipei", "台北" },
                        { "labelSeoul", "首爾" },
                        { "labelNewYork", "紐約" },
                        { "labelLosAngeles", "洛杉磯" },
                    }
                },
                {
                    "zh-CN",
                    new()
                    {
                        { "labelGame", "游戏" },
                        { "labelLanguage", "语言" },
                        { "labelGameTime", "游戏时间" },
                        { "labelTaipei", "台北" },
                        { "labelSeoul", "首尔" },
                        { "labelNewYork", "纽约" },
                        { "labelLosAngeles", "洛杉矶" },
                    }
                },
                {
                    "en",
                    new()
                    {
                        { "labelGame", "Game" },
                        { "labelLanguage", "Language" },
                        { "labelGameTime", "Game Time" },
                        { "labelTaipei", "Taipei" },
                        { "labelSeoul", "Seoul" },
                        { "labelNewYork", "New York" },
                        { "labelLosAngeles", "Los Angeles" },
                    }
                },
                {
                    "es",
                    new()
                    {
                        { "labelGame", "Juego" },
                        { "labelLanguage", "Idioma" },
                        { "labelGameTime", "Hora del Juego" },
                        { "labelTaipei", "Taipéi" },
                        { "labelSeoul", "Seúl" },
                        { "labelNewYork", "Nueva York" },
                        { "labelLosAngeles", "Los Ángeles" },
                    }
                },
                {
                    "fr",
                    new()
                    {
                        { "labelGame", "Jeu" },
                        { "labelLanguage", "Langue" },
                        { "labelGameTime", "Temps de Jeu" },
                        { "labelTaipei", "Taipei" },
                        { "labelSeoul", "Séoul" },
                        { "labelNewYork", "New York" },
                        { "labelLosAngeles", "Los Angeles" },
                    }
                },
                {
                    "de",
                    new()
                    {
                        { "labelGame", "Spiel" },
                        { "labelLanguage", "Sprache" },
                        { "labelGameTime", "Spielzeit" },
                        { "labelTaipei", "Taipeh" },
                        { "labelSeoul", "Seoul" },
                        { "labelNewYork", "New York" },
                        { "labelLosAngeles", "Los Angeles" },
                    }
                },
                {
                    "ja",
                    new()
                    {
                        { "labelGame", "ゲーム" },
                        { "labelLanguage", "言語" },
                        { "labelGameTime", "ゲーム時間" },
                        { "labelTaipei", "台北" },
                        { "labelSeoul", "ソウル" },
                        { "labelNewYork", "ニューヨーク" },
                        { "labelLosAngeles", "ロサンゼルス" },
                    }
                },
                {
                    "ko",
                    new()
                    {
                        { "labelGame", "게임" },
                        { "labelLanguage", "언어" },
                        { "labelGameTime", "게임 시간" },
                        { "labelTaipei", "타이베이" },
                        { "labelSeoul", "서울" },
                        { "labelNewYork", "뉴욕" },
                        { "labelLosAngeles", "로스앤젤레스" },
                    }
                },
                {
                    "ru",
                    new()
                    {
                        { "labelGame", "Игра" },
                        { "labelLanguage", "Язык" },
                        { "labelGameTime", "Время игры" },
                        { "labelTaipei", "Тайбэй" },
                        { "labelSeoul", "Сеул" },
                        { "labelNewYork", "Нью-Йорк" },
                        { "labelLosAngeles", "Лос-Анджелес" },
                    }
                },
                {
                    "pt",
                    new()
                    {
                        { "labelGame", "Jogo" },
                        { "labelLanguage", "Idioma" },
                        { "labelGameTime", "Hora do Jogo" },
                        { "labelTaipei", "Taipé" },
                        { "labelSeoul", "Seul" },
                        { "labelNewYork", "Nova Iorque" },
                        { "labelLosAngeles", "Los Angeles" },
                    }
                },
            };
    }

    public class LanguageItem
    {
        public string LanguageCode { get; }
        public string DisplayText { get; }
        public Image Flag { get; }

        public LanguageItem(string code, string text, Image flag)
        {
            LanguageCode = code;
            DisplayText = text;
            Flag = flag;
        }

        public override string ToString() => DisplayText;
    }
}
