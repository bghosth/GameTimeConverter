using System;
using System.Windows.Forms;

namespace GameTimeConverter
{
    public partial class MainForm : Form
    {
        private readonly TimeConverter timeConverter;
        private readonly LanguageManager languageManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeDropdowns();

            timeConverter = new TimeConverter(
                labelTaipeiTime,
                labelSeoulTime,
                labelNewYorkTime,
                labelLosAngelesTime
            );
            languageManager = new LanguageManager(comboBoxLanguage, this);

            this.Resize += MainForm_Resize;
        }

        private void InitializeDropdowns()
        {
            UIHelper.PopulateGameSelection(comboBoxGame);
            UIHelper.PopulateDateTimeControls(
                comboBoxYear,
                comboBoxMonth,
                comboBoxDay,
                comboBoxHour,
                comboBoxMinute
            );

            comboBoxGame.SelectedIndexChanged += (s, e) =>
                timeConverter.UpdateGameTimeZone(comboBoxGame.SelectedItem.ToString());

            comboBoxYear.SelectedIndexChanged += UpdateTime;
            comboBoxMonth.SelectedIndexChanged += UpdateTime;
            comboBoxDay.SelectedIndexChanged += UpdateTime;
            comboBoxHour.SelectedIndexChanged += UpdateTime;
            comboBoxMinute.SelectedIndexChanged += UpdateTime;
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            timeConverter.ConvertAndDisplayTime(
                comboBoxGame.SelectedItem.ToString(),
                Convert.ToInt32(comboBoxYear.SelectedItem),
                Convert.ToInt32(comboBoxMonth.SelectedItem),
                Convert.ToInt32(comboBoxDay.SelectedItem),
                Convert.ToInt32(comboBoxHour.SelectedItem),
                Convert.ToInt32(comboBoxMinute.SelectedItem)
            );
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UIHelper.CenterControls(this);
            UIHelper.CustomizeComboBoxes(this);
            UpdateTime(null, EventArgs.Empty);
        }

        private void MainForm_Shown(object sender, EventArgs e) => this.ActiveControl = null;

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UIHelper.CenterControls(this);
            UIHelper.AutoResizeLabelFont(labelTaipei);
            UIHelper.AutoResizeLabelFont(labelNewYork);
        }
    }
}
