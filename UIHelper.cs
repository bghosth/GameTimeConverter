using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameTimeConverter
{
    public static class UIHelper
    {
        public static void PopulateGameSelection(ComboBox comboBox)
        {
            comboBox.Items.Add("Last Z: Survival Shooter");
            comboBox.SelectedIndex = 0;
        }

        public static void PopulateDateTimeControls(
            ComboBox year,
            ComboBox month,
            ComboBox day,
            ComboBox hour,
            ComboBox minute
        )
        {
            TimeZoneInfo greenlandZone = TimeZoneInfo.FindSystemTimeZoneById(
                "Greenland Standard Time"
            );
            DateTime nowUTC = DateTime.UtcNow;
            DateTime nowEGT = TimeZoneInfo.ConvertTimeFromUtc(nowUTC, greenlandZone);

            if (nowEGT.Day != DateTime.UtcNow.Day)
            {
                nowEGT = nowEGT.AddDays(1);
            }

            year.Items.Add(nowEGT.Year);
            year.Items.Add(nowEGT.Year + 1);
            year.SelectedIndex = 0;

            for (int i = 1; i <= 12; i++)
                month.Items.Add(i);
            month.SelectedIndex = nowEGT.Month - 1;

            year.SelectedIndexChanged += (s, e) =>
                UpdateDaysDropdown(day, (int)month.SelectedItem, (int)year.SelectedItem);
            month.SelectedIndexChanged += (s, e) =>
                UpdateDaysDropdown(day, (int)month.SelectedItem, (int)year.SelectedItem);

            UpdateDaysDropdown(day, nowEGT.Month, nowEGT.Year);
            day.SelectedIndex = nowEGT.Day - 1;

            for (int i = 0; i < 24; i++)
                hour.Items.Add(i.ToString("D2"));
            hour.SelectedIndex = nowEGT.Hour;

            for (int i = 0; i < 60; i++)
                minute.Items.Add(i.ToString("D2"));
            minute.SelectedIndex = nowEGT.Minute;
        }

        public static void UpdateDaysDropdown(ComboBox day, int month, int year)
        {
            day.Items.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
                day.Items.Add(i);
            day.SelectedIndex = 0;
        }

        public static void AutoResizeLabelFont(Label label)
        {
            if (string.IsNullOrEmpty(label.Text) || label.Width <= 0)
                return;

            label.BeginInvoke(
                (MethodInvoker)
                    delegate
                    {
                        using (Graphics g = label.CreateGraphics())
                        {
                            if (label.Tag == null)
                                label.Tag = label.Font.Size;

                            float originalFontSize = (float)label.Tag;
                            float minFontSize = 7f;
                            float maxFontSize = originalFontSize;
                            Size layoutSize = new Size(label.Width - 3, label.Height);

                            SizeF textSize = g.MeasureString(label.Text, label.Font);
                            if (textSize.Width <= layoutSize.Width)
                            {
                                label.Font = new Font(
                                    label.Font.FontFamily,
                                    originalFontSize,
                                    label.Font.Style
                                );
                                return;
                            }

                            Font resizedFont = FlexFont(
                                g,
                                minFontSize,
                                maxFontSize,
                                layoutSize,
                                label.Text,
                                label.Font,
                                out textSize
                            );
                            label.Font = resizedFont;
                        }
                    }
            );
        }

        private static Font FlexFont(
            Graphics g,
            float minFontSize,
            float maxFontSize,
            Size layoutSize,
            string s,
            Font f,
            out SizeF extent
        )
        {
            extent = g.MeasureString(s, f);
            if (maxFontSize <= minFontSize)
                return new Font(f.FontFamily, minFontSize, f.Style);

            float hRatio = layoutSize.Height / extent.Height;
            float wRatio = layoutSize.Width / extent.Width;
            float ratio = Math.Min(hRatio, wRatio);

            float newSize = (f.Size * ratio) - 1;
            newSize = Clamp(newSize, minFontSize, maxFontSize);

            return new Font(f.FontFamily, newSize, f.Style);
        }

        private const int LabelOffset = 0;

        public static void CenterControls(Form form)
        {
            string[] excludedControls =
            {
                "labelGame",
                "comboBoxGame",
                "labelLanguage",
                "comboBoxLanguage",
            };

            var groupedControls = form
                .Controls.Cast<Control>()
                .Where(ctrl => ctrl.Visible && !excludedControls.Contains(ctrl.Name))
                .OrderBy(ctrl => ctrl.Top)
                .ThenBy(ctrl => ctrl.Left)
                .GroupBy(ctrl => ctrl.Top);

            foreach (var group in groupedControls)
            {
                Control[] rowControls = group.OrderBy(ctrl => ctrl.Left).ToArray();
                if (rowControls.Length == 0)
                    continue;

                int rowSpacing = 10;
                if (rowControls.Length > 1)
                {
                    int totalSpacing = 0;
                    for (int i = 1; i < rowControls.Length; i++)
                    {
                        totalSpacing +=
                            rowControls[i].Left
                            - (rowControls[i - 1].Left + rowControls[i - 1].Width);
                    }
                    rowSpacing = totalSpacing / (rowControls.Length - 1);
                }

                int totalWidth =
                    rowControls.Sum(ctrl => ctrl.Width) + ((rowControls.Length - 1) * rowSpacing);
                int startX = (form.ClientSize.Width - totalWidth) / 2;

                int currentX = startX;
                foreach (Control ctrl in rowControls)
                {
                    string[] excludedLabels =
                    {
                        "labelGameTime",
                        "labelYear",
                        "labelMonth",
                        "labelDay",
                        "labelHour",
                        "labelMinute",
                    };

                    ctrl.Left =
                        currentX
                        - (ctrl is Label && !excludedLabels.Contains(ctrl.Name) ? LabelOffset : 0);
                    currentX += ctrl.Width + rowSpacing;
                }
            }
        }

        public static void CustomizeComboBoxes(Form form)
        {
            string[] excludedComboBoxes = { "comboBoxGame", "comboBoxLanguage" };

            foreach (var comboBox in form.Controls.OfType<ComboBox>())
            {
                comboBox.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox.DrawItem += (sender, e) =>
                {
                    if (e.Index < 0)
                        return;

                    ComboBox cb = (ComboBox)sender;
                    bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                    Color backgroundColor = isSelected ? Color.LightBlue : cb.BackColor;
                    Color textColor = isSelected ? Color.Black : cb.ForeColor;

                    e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

                    bool isExcluded = excludedComboBoxes.Contains(cb.Name);

                    if (cb.Name == "comboBoxLanguage")
                    {
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
                            new SolidBrush(textColor),
                            e.Bounds.Left + textXOffset,
                            e.Bounds.Top + 2
                        );
                    }
                    else
                    {
                        using StringFormat sf = new();
                        sf.Alignment = isExcluded ? StringAlignment.Near : StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        using SolidBrush textBrush = new(textColor);
                        e.Graphics.DrawString(
                            cb.Items[e.Index].ToString(),
                            cb.Font,
                            textBrush,
                            e.Bounds,
                            sf
                        );
                    }

                    e.DrawFocusRectangle();
                };
            }
        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min
                : (value > max) ? max
                : value;
        }
    }
}
