using System;
using System.Globalization;
using System.Windows.Forms;

namespace GameTimeConverter
{
    public partial class GameTimeConverterForm : Form
    {
        private readonly string defaultText = "yyyy-MM-dd HH:mm";

        public GameTimeConverterForm()
        {
            InitializeComponent();

            textBoxGameTime.Text = defaultText;

            buttonConvertTime.Click += new EventHandler(ConvertTime);
        }

        private void ConvertTime(object sender, EventArgs e)
        {
            string input = textBoxGameTime.Text;

            if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime gameTime))
            {
                // Convert Game Time (EGT, UTC-2) to UTC
                TimeZoneInfo egtZone = TimeZoneInfo.CreateCustomTimeZone("EGT", TimeSpan.FromHours(-2), "Eastern Greenland Time", "EGT");
                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(gameTime, egtZone);

                // Convert UTC to Taipei Time (TST, UTC+8)
                TimeZoneInfo tstZone = TimeZoneInfo.CreateCustomTimeZone("TST", TimeSpan.FromHours(8), "Taiwan Standard Time", "TST");
                DateTime taipeiTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tstZone);

                // Convert UTC to New York Time (EST/EDT, UTC-5/UTC-4 depending on DST)
                TimeZoneInfo newYorkZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, newYorkZone);

                // Display results
                labelTaipeiTimeResult.Text = $"{taipeiTime:yyyy-MM-dd HH:mm}";
                labelNewYorkTimeResult.Text = $"{newYorkTime:yyyy-MM-dd HH:mm}";
            }
            else
            {
                labelTaipeiTimeResult.Text = "格式錯誤！[ yyyy-MM-dd HH:mm ]";
                labelNewYorkTimeResult.Text = "格式錯誤！[ yyyy-MM-dd HH:mm ]";
            }
        }

        private void textBoxGameTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ConvertTime(sender, e);
            }
        }

        private void textBoxGameTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGameTime.Text != defaultText && textBoxGameTime.ForeColor == System.Drawing.Color.Gray)
            {
                textBoxGameTime.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxGameTime_Click(object sender, EventArgs e)
        {
            textBoxGameTime.Text = "";
        }
    }
}
