using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

using CampusQ.MVP.Models;
using CampusQ.MVP.Presenters;
using CampusQ.MVP.Views;

namespace CampusQ
{
    public partial class Staff : Form, IStaffView
    {
        // =========================================================
        // PRESENTER
        // =========================================================

        private readonly StaffPresenter _presenter;

        // =========================================================
        // CURRENT QUEUE
        // =========================================================

        private BindingList<QueueEntry>? currentView;

        // =========================================================
        // PANELS
        // =========================================================

        private Panel? panelQueueAnalytics;
        private Panel? panelActiveStatus;

        // =========================================================
        // WINDOW STATUS
        // =========================================================

        // =========================================================
        // STAFF ASSIGNMENTS
        // =========================================================

        private const string Window1Staff =
            "Juan Dela Cruz";

        private const string Window2Staff =
            "Maria Santos";

        private const string Window3Staff =
            "Joshua Gonzales";

        private const string Window4Staff =
            "Pedro Reyes";

        // =========================================================
        // COLORS
        // =========================================================

        private static readonly Color Green =
            Color.FromArgb(
                0,
                105,
                55);

        private static readonly Color DarkGreen =
            Color.FromArgb(
                0,
                92,
                48);

        private static readonly Color LightGreen =
            Color.FromArgb(
                220,
                245,
                226);

        private static readonly Color GridLine =
            Color.FromArgb(
                230,
                235,
                232);

        private static readonly Color DarkGray =
            Color.FromArgb(
                90,
                100,
                95);

        private static readonly Color Red =
            Color.FromArgb(
                205,
                45,
                45);

        private static readonly Color LightRed =
            Color.FromArgb(
                250,
                225,
                225);

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public Staff()
        {
            InitializeComponent();

            _presenter =
                new StaffPresenter(this);

            InitializeStaffControls();

            CreateAnalyticsPanel();

            CreateActiveStatusPanel();

            UpdateAllWindowStatuses(
                _presenter.GetAllWindowStatuses());

            UpdateQueueAnalytics();
        }

        // =========================================================
        // REMOVE FOCUS RECTANGLE
        // =========================================================

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        // =========================================================
        // INITIALIZE STAFF CONTROLS
        // =========================================================

        private void InitializeStaffControls()
        {
            // =====================================================
            // SERVICE COMBO BOX
            // =====================================================

            comboBoxService.Items.Clear();

            comboBoxService.Items.Add("All");
            comboBoxService.Items.Add("Registrar - W1");
            comboBoxService.Items.Add("Registrar - W2");
            comboBoxService.Items.Add("Registrar - W3");
            comboBoxService.Items.Add("Registrar - W4");

            comboBoxService.SelectedIndex = 0;

            comboBoxService.SelectedIndexChanged -=
                ComboBoxService_SelectedIndexChanged;

            comboBoxService.SelectedIndexChanged +=
                ComboBoxService_SelectedIndexChanged;

            // =====================================================
            // REFRESH
            // =====================================================

            buttonRefresh.Click -=
                ButtonRefresh_Click;

            buttonRefresh.Click +=
                ButtonRefresh_Click;

            // =====================================================
            // SERVE NEXT
            // =====================================================

            buttonServeNext.Click -=
                ButtonServeNext_Click;

            buttonServeNext.Click +=
                ButtonServeNext_Click;

            // =====================================================
            // WINDOW BUTTONS
            // =====================================================

            btnWindow1.Click -=
                BtnWindow1_Click;

            btnWindow1.Click +=
                BtnWindow1_Click;

            btnWindow2.Click -=
                BtnWindow2_Click;

            btnWindow2.Click +=
                BtnWindow2_Click;

            btnWindow3.Click -=
                BtnWindow3_Click;

            btnWindow3.Click +=
                BtnWindow3_Click;

            btnWindow4.Click -=
                BtnWindow4_Click;

            btnWindow4.Click +=
                BtnWindow4_Click;

            ConfigureMainButtons();

            ConfigureWindowButtons();

            ConfigureQueueGrid();
        }

        // =========================================================
        // MAIN BUTTONS
        // =========================================================

        private void ConfigureMainButtons()
        {
            // =====================================================
            // REFRESH
            // =====================================================

            buttonRefresh.Text =
                "↻   Refresh Queue";

            buttonRefresh.BackColor =
                Green;

            buttonRefresh.ForeColor =
                Color.White;

            buttonRefresh.FlatStyle =
                FlatStyle.Flat;

            buttonRefresh.FlatAppearance.BorderSize =
                0;

            buttonRefresh.FlatAppearance.MouseOverBackColor =
                Green;

            buttonRefresh.FlatAppearance.MouseDownBackColor =
                Green;

            buttonRefresh.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            buttonRefresh.Cursor =
                Cursors.Hand;

            buttonRefresh.TabStop =
                false;

            MakeButtonRounded(
                buttonRefresh,
                18);

            // =====================================================
            // SERVE NEXT
            // =====================================================

            buttonServeNext.Text =
                "▶   Serve Next";

            buttonServeNext.BackColor =
                Green;

            buttonServeNext.ForeColor =
                Color.White;

            buttonServeNext.FlatStyle =
                FlatStyle.Flat;

            buttonServeNext.FlatAppearance.BorderSize =
                0;

            buttonServeNext.FlatAppearance.MouseOverBackColor =
                Green;

            buttonServeNext.FlatAppearance.MouseDownBackColor =
                Green;

            buttonServeNext.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            buttonServeNext.Cursor =
                Cursors.Hand;

            buttonServeNext.TabStop =
                false;

            MakeButtonRounded(
                buttonServeNext,
                18);

            // =====================================================
            // SERVICE
            // =====================================================

            btn_service.Text =
                "✓   Service";

            btn_service.BackColor =
                Color.White;

            btn_service.ForeColor =
                DarkGreen;

            btn_service.FlatStyle =
                FlatStyle.Flat;

            btn_service.FlatAppearance.BorderColor =
                Green;

            btn_service.FlatAppearance.BorderSize =
                1;

            btn_service.FlatAppearance.MouseOverBackColor =
                Color.White;

            btn_service.FlatAppearance.MouseDownBackColor =
                Color.White;

            btn_service.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            btn_service.Cursor =
                Cursors.Hand;

            btn_service.TabStop =
                false;

            MakeButtonRounded(
                btn_service,
                18);
        }

        // =========================================================
        // WINDOW BUTTON STYLE
        // =========================================================

        private void ConfigureWindowButtons()
        {
            ConfigureWindowButton(btnWindow1);
            ConfigureWindowButton(btnWindow2);
            ConfigureWindowButton(btnWindow3);
            ConfigureWindowButton(btnWindow4);
        }

        // =========================================================
        // CONFIGURE WINDOW BUTTON
        // =========================================================

        private void ConfigureWindowButton(
            Button button)
        {
            if (button == null)
                return;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                0;

            button.FlatAppearance.MouseOverBackColor =
                button.BackColor;

            button.FlatAppearance.MouseDownBackColor =
                button.BackColor;

            button.UseVisualStyleBackColor =
                false;

            button.Cursor =
                Cursors.Hand;

            button.Font =
                new Font(
                    "Segoe UI",
                    7.5F,
                    FontStyle.Bold);

            button.TabStop =
                false;

            MakeButtonRounded(
                button,
                10);
        }

        // =========================================================
        // DATA GRID
        // =========================================================

        private void ConfigureQueueGrid()
        {
            if (dataGridViewQueue == null ||
                dataGridViewQueue.IsDisposed)
            {
                return;
            }

            dataGridViewQueue.AutoGenerateColumns =
                false;

            dataGridViewQueue.EnableHeadersVisualStyles =
                false;

            dataGridViewQueue.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewQueue.MultiSelect =
                false;

            dataGridViewQueue.AllowUserToAddRows =
                false;

            dataGridViewQueue.AllowUserToDeleteRows =
                false;

            dataGridViewQueue.AllowUserToResizeRows =
                false;

            dataGridViewQueue.RowHeadersVisible =
                false;

            dataGridViewQueue.ReadOnly =
                true;

            dataGridViewQueue.BorderStyle =
                BorderStyle.None;

            dataGridViewQueue.BackgroundColor =
                Color.White;

            dataGridViewQueue.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridViewQueue.GridColor =
                GridLine;

            dataGridViewQueue.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dataGridViewQueue.ScrollBars =
                ScrollBars.Horizontal;

            dataGridViewQueue.ColumnHeadersHeight =
                38;

            dataGridViewQueue.RowTemplate.Height =
                38;

            // =====================================================
            // HEADER
            // =====================================================

            dataGridViewQueue.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.White,

                    ForeColor =
                        Color.FromArgb(
                            25,
                            35,
                            30),

                    Font =
                        new Font(
                            "Segoe UI",
                            8.5F,
                            FontStyle.Bold),

                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    SelectionBackColor =
                        Color.White,

                    SelectionForeColor =
                        Color.FromArgb(
                            25,
                            35,
                            30),

                    Padding =
                        new Padding(
                            6,
                            0,
                            4,
                            0)
                };

            // =====================================================
            // NORMAL ROW
            // =====================================================

            dataGridViewQueue.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.White,

                    ForeColor =
                        Color.FromArgb(
                            45,
                            55,
                            50),

                    Font =
                        new Font(
                            "Segoe UI",
                            8.5F),

                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    SelectionBackColor =
                        Color.FromArgb(
                            220,
                            245,
                            226),

                    SelectionForeColor =
                        DarkGreen,

                    Padding =
                        new Padding(
                            6,
                            0,
                            4,
                            0),

                    WrapMode =
                        DataGridViewTriState.False
                };

            // =====================================================
            // ALTERNATING ROW
            // =====================================================

            dataGridViewQueue.AlternatingRowsDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(
                            252,
                            253,
                            252),

                    ForeColor =
                        Color.FromArgb(
                            45,
                            55,
                            50),

                    SelectionBackColor =
                        Color.FromArgb(
                            220,
                            245,
                            226),

                    SelectionForeColor =
                        DarkGreen
                };

            // =====================================================
            // CLEAR OLD COLUMNS
            // =====================================================

            dataGridViewQueue.Columns.Clear();

            // =====================================================
            // TICKET NUMBER
            // =====================================================

            DataGridViewTextBoxColumn ticketColumn =
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "TicketNumber",

                    DataPropertyName =
                        nameof(
                            QueueEntry.TicketLabel),

                    HeaderText =
                        "TicketNumber",

                    Width =
                        105,

                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dataGridViewQueue.Columns.Add(
                ticketColumn);

            // =====================================================
            // SERVICE TICKET
            // =====================================================

            DataGridViewTextBoxColumn serviceTicketColumn =
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "ServiceTicketNumber",

                    DataPropertyName =
                        nameof(
                            QueueEntry.ServiceTicketNumber),

                    HeaderText =
                        "ServiceTicket...",

                    Width =
                        105,

                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dataGridViewQueue.Columns.Add(
                serviceTicketColumn);

            // =====================================================
            // PURPOSE
            // =====================================================

            DataGridViewTextBoxColumn purposeColumn =
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "Purpose",

                    DataPropertyName =
                        nameof(
                            QueueEntry.Purpose),

                    HeaderText =
                        "Purpose",

                    Width =
                        170,

                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dataGridViewQueue.Columns.Add(
                purposeColumn);

            // =====================================================
            // SERVICE
            // =====================================================

            DataGridViewTextBoxColumn serviceColumn =
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "Service",

                    DataPropertyName =
                        nameof(
                            QueueEntry.Service),

                    HeaderText =
                        "Service",

                    Width =
                        170,

                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dataGridViewQueue.Columns.Add(
                serviceColumn);

            // =====================================================
            // TIME ADDED
            // =====================================================

            DataGridViewTextBoxColumn timeAddedColumn =
                new DataGridViewTextBoxColumn
                {
                    Name =
                        "TimeAdded",

                    DataPropertyName =
                        nameof(
                            QueueEntry.TimeAdded),

                    HeaderText =
                        "TimeAdded",

                    Width =
                        125,

                    SortMode =
                        DataGridViewColumnSortMode.NotSortable,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format =
                                "g"
                        }
                };

            dataGridViewQueue.Columns.Add(
                timeAddedColumn);
        }

        // =========================================================
        // SERVICE FILTER
        // =========================================================

        private void ComboBoxService_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            try
            {
                _presenter.RefreshQueueView();

                UpdateQueueAnalytics();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    $"Failed to refresh queue:\n\n{ex.Message}",
                    "Registrar Error",
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // REFRESH QUEUE
        // =========================================================

        private void ButtonRefresh_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                _presenter.RefreshQueueView();

                UpdateQueueAnalytics();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    $"Failed to refresh queue:\n\n{ex.Message}",
                    "Refresh Error",
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SERVE NEXT
        // =========================================================

        private void ButtonServeNext_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                _presenter.ServeNext();

                _presenter.RefreshQueueView();

                UpdateQueueAnalytics();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    $"Failed to serve next:\n\n{ex.Message}",
                    "Serve Error",
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // BIND QUEUE
        // =========================================================

        public void BindQueue(
            BindingList<QueueEntry> view)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        () => BindQueue(view)));

                return;
            }

            currentView =
                view;

            if (dataGridViewQueue == null ||
                dataGridViewQueue.IsDisposed)
            {
                return;
            }

            dataGridViewQueue.DataSource =
                null;

            dataGridViewQueue.DataSource =
                currentView;

            labelTotal.Text =
                $"Total: {currentView.Count}";

            if (dataGridViewQueue.Rows.Count > 0)
            {
                dataGridViewQueue.ClearSelection();

                dataGridViewQueue.Rows[0]
                    .Selected = true;
            }

            UpdateQueueAnalytics();
        }

        // =========================================================
        // SELECTED SERVICE
        // =========================================================

        public string SelectedService
        {
            get
            {
                if (comboBoxService == null)
                    return "All";

                return
                    comboBoxService.SelectedItem?
                        .ToString()
                    ?? "All";
            }
        }

        // =========================================================
        // SET SELECTED SERVICE
        // =========================================================

        public void SetSelectedService(
            string service)
        {
            if (string.IsNullOrWhiteSpace(service))
                return;

            if (
                string.Equals(
                    service,
                    "Registrar",
                    StringComparison.OrdinalIgnoreCase))
            {
                SelectComboBoxItem(
                    "All");

                return;
            }

            SelectComboBoxItem(
                service);
        }

        // =========================================================
        // SELECT COMBO ITEM
        // =========================================================

        private void SelectComboBoxItem(
            string item)
        {
            for (
                int i = 0;
                i < comboBoxService.Items.Count;
                i++)
            {
                if (
                    string.Equals(
                        comboBoxService.Items[i]?.ToString(),
                        item,
                        StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxService.SelectedIndex =
                        i;

                    return;
                }
            }
        }

        // =========================================================
        // MESSAGE
        // =========================================================

        public void ShowMessage(
            string text,
            string caption,
            MessageBoxIcon icon)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        () =>
                            ShowMessage(
                                text,
                                caption,
                                icon)));

                return;
            }

            MessageBox.Show(
                this,
                text,
                caption,
                MessageBoxButtons.OK,
                icon);
        }

        // =========================================================
        // ANALYTICS PANEL
        // =========================================================

        private void CreateAnalyticsPanel()
        {
            panelQueueAnalytics =
                new Panel();

            panelQueueAnalytics.Name =
                "panelQueueAnalytics";

            panelQueueAnalytics.BackColor =
                Color.White;

            panelQueueAnalytics.BorderStyle =
                BorderStyle.FixedSingle;

            panelQueueAnalytics.Location =
                new Point(
                    565,
                    168);

            panelQueueAnalytics.Size =
                new Size(
                    470,
                    265);

            panelQueueAnalytics.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            panelQueueAnalytics.Paint +=
                PanelQueueAnalytics_Paint;

            panelQueueAnalytics.Resize +=
                PanelQueueAnalytics_Resize;

            Controls.Add(
                panelQueueAnalytics);

            panelQueueAnalytics.BringToFront();
        }

        // =========================================================
        // UPDATE ANALYTICS
        // =========================================================

        private void UpdateQueueAnalytics()
        {
            if (panelQueueAnalytics == null ||
                panelQueueAnalytics.IsDisposed)
            {
                return;
            }

            panelQueueAnalytics.Invalidate();
        }

        // =========================================================
        // ANALYTICS RESIZE
        // =========================================================

        private void PanelQueueAnalytics_Resize(
            object? sender,
            EventArgs e)
        {
            UpdateQueueAnalytics();
        }

        // =========================================================
        // ANALYTICS GRAPH
        // =========================================================

        private void PanelQueueAnalytics_Paint(
            object? sender,
            PaintEventArgs e)
        {
            if (panelQueueAnalytics == null)
                return;

            Graphics g =
                e.Graphics;

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            g.Clear(
                Color.White);

            // =====================================================
            // GET DATA
            // =====================================================

            int[] values;

            try
            {
                values =
                    _presenter.GetWeeklyQueueAnalytics();
            }
            catch
            {
                values =
                    new int[]
                    {
                        0,
                        0,
                        0,
                        0
                    };
            }

            int[] windowValues =
            {
                values.Length > 0
                    ? values[0]
                    : 0,

                values.Length > 1
                    ? values[1]
                    : 0,

                values.Length > 2
                    ? values[2]
                    : 0,

                values.Length > 3
                    ? values[3]
                    : 0
            };

            string[] labels =
            {
                "W1",
                "W2",
                "W3",
                "W4"
            };

            // =====================================================
            // SIZE
            // =====================================================

            int width =
                panelQueueAnalytics.ClientSize.Width;

            int height =
                panelQueueAnalytics.ClientSize.Height;

            if (width <= 0 ||
                height <= 0)
            {
                return;
            }

            // =====================================================
            // HEADER
            // =====================================================

            using Font titleFont =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            using Brush greenBrush =
                new SolidBrush(
                    Green);

            g.DrawString(
                "▥  QUEUE ANALYTICS",
                titleFont,
                greenBrush,
                25,
                12);

            // =====================================================
            // CHART TITLE
            // =====================================================

            using Font chartTitleFont =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            using Brush darkBrush =
                new SolidBrush(
                    Color.FromArgb(
                        30,
                        30,
                        30));

            string chartTitle =
                "Customers Served";

            SizeF titleSize =
                g.MeasureString(
                    chartTitle,
                    chartTitleFont);

            g.DrawString(
                chartTitle,
                chartTitleFont,
                darkBrush,
                (width -
                    titleSize.Width) / 2F,
                58);

            // =====================================================
            // GRAPH AREA
            // =====================================================

            int left = 55;
            int right = 20;
            int top = 95;
            int bottom = 60;

            int graphWidth =
                width -
                left -
                right;

            int graphHeight =
                height -
                top -
                bottom;

            if (graphWidth <= 0 ||
                graphHeight <= 0)
            {
                return;
            }

            // =====================================================
            // AXIS
            // =====================================================
            //
            // IMPORTANT:
            // NO HORIZONTAL GRID LINES
            // =====================================================

            using Pen axisPen =
                new Pen(
                    Color.FromArgb(
                        140,
                        145,
                        142),
                    1);

            using Font axisFont =
                new Font(
                    "Segoe UI",
                    7.5F);

            using Brush axisBrush =
                new SolidBrush(
                    Color.FromArgb(
                        95,
                        105,
                        100));

            // =====================================================
            // FIXED SCALE
            //
            // Labels only:
            //
            // 100
            // 80
            // 60
            // 40
            // 20
            // 0
            //
            // NO HORIZONTAL LINES
            // =====================================================

            for (
                int value = 0;
                value <= 100;
                value += 20)
            {
                float percentage =
                    value / 100F;

                float y =
                    top +
                    graphHeight -
                    graphHeight *
                    percentage;

                string valueText =
                    value.ToString();

                SizeF valueSize =
                    g.MeasureString(
                        valueText,
                        axisFont);

                g.DrawString(
                    valueText,
                    axisFont,
                    axisBrush,
                    left -
                    valueSize.Width -
                    7,
                    y -
                    valueSize.Height / 2F);
            }

            // =====================================================
            // Y-AXIS ONLY
            //
            // The horizontal bottom line is removed.
            // =====================================================

            float bottomY =
                top +
                graphHeight;

            g.DrawLine(
                axisPen,
                left,
                top,
                left,
                bottomY);

            // =====================================================
            // BAR SETTINGS
            // =====================================================

            float slotWidth =
                graphWidth / 4F;

            int barWidth =
                Math.Min(
                    58,
                    Math.Max(
                        25,
                        (int)(
                            slotWidth *
                            0.48F)));

            using Brush barBrush =
                new SolidBrush(
                    Color.FromArgb(
                        0,
                        125,
                        55));

            using Font valueFont =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold);

            using Font labelFont =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold);

            // =====================================================
            // BARS
            // =====================================================

            for (
                int i = 0;
                i < 4;
                i++)
            {
                int value =
                    Math.Max(
                        0,
                        windowValues[i]);

                int displayValue =
                    Math.Min(
                        value,
                        100);

                float percentage =
                    displayValue /
                    100F;

                int barHeight =
                    (int)(
                        percentage *
                        graphHeight);

                float centerX =
                    left +
                    slotWidth * i +
                    slotWidth / 2F;

                float x =
                    centerX -
                    barWidth / 2F;

                float y =
                    bottomY -
                    barHeight;

                // =================================================
                // BAR
                // =================================================

                if (barHeight > 0)
                {
                    g.FillRectangle(
                        barBrush,
                        x,
                        y,
                        barWidth,
                        barHeight);
                }

                // =================================================
                // VALUE
                // =================================================

                string valueText =
                    value.ToString();

                SizeF valueSize =
                    g.MeasureString(
                        valueText,
                        valueFont);

                float valueY =
                    y -
                    valueSize.Height -
                    3;

                if (valueY < top)
                    valueY =
                        top;

                g.DrawString(
                    valueText,
                    valueFont,
                    darkBrush,
                    centerX -
                    valueSize.Width / 2F,
                    valueY);

                // =================================================
                // WINDOW LABEL
                // =================================================

                SizeF labelSize =
                    g.MeasureString(
                        labels[i],
                        labelFont);

                g.DrawString(
                    labels[i],
                    labelFont,
                    darkBrush,
                    centerX -
                    labelSize.Width / 2F,
                    bottomY + 7);
            }

            // =====================================================
            // X AXIS TITLE
            // =====================================================

            using Font xAxisFont =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            string xAxisText =
                "Service Window";

            SizeF xAxisSize =
                g.MeasureString(
                    xAxisText,
                    xAxisFont);

            g.DrawString(
                xAxisText,
                xAxisFont,
                darkBrush,
                (width -
                    xAxisSize.Width) / 2F,
                height -
                25);
        }

        // =========================================================
        // ACTIVE STATUS PANEL
        // =========================================================

        private void CreateActiveStatusPanel()
        {
            panelActiveStatus =
                new Panel();

            panelActiveStatus.Name =
                "panelActiveStatus";

            panelActiveStatus.BackColor =
                Color.White;

            panelActiveStatus.BorderStyle =
                BorderStyle.FixedSingle;

            panelActiveStatus.Location =
                new Point(
                    565,
                    440);

            panelActiveStatus.Size =
                new Size(
                    470,
                    210);

            panelActiveStatus.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            Controls.Add(
                panelActiveStatus);

            panelActiveStatus.BringToFront();

            // =====================================================
            // HEADER
            // =====================================================

            Label header =
                new Label();

            header.Text =
                "●  ACTIVE STATUS";

            header.AutoSize =
                true;

            header.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            header.ForeColor =
                Green;

            header.Location =
                new Point(
                    25,
                    10);

            panelActiveStatus.Controls.Add(
                header);

            // =====================================================
            // STATUS ROWS
            // =====================================================

            CreateStatusRow(
                1,
                Window1Staff,
                48);

            CreateStatusRow(
                2,
                Window2Staff,
                86);

            CreateStatusRow(
                3,
                Window3Staff,
                124);

            CreateStatusRow(
                4,
                Window4Staff,
                162);
        }

        // =========================================================
        // CREATE STATUS ROW
        // =========================================================

        private void CreateStatusRow(
            int window,
            string staffName,
            int y)
        {
            if (panelActiveStatus == null)
                return;

            // =====================================================
            // DOT
            // =====================================================

            Label dot =
                new Label();

            dot.Name =
                $"lblStatusDot{window}";

            dot.Text =
                "●";

            dot.AutoSize =
                true;

            dot.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold);

            dot.Location =
                new Point(
                    25,
                    y + 1);

            panelActiveStatus.Controls.Add(
                dot);

            // =====================================================
            // NAME
            // =====================================================

            Label name =
                new Label();

            name.Name =
                $"lblWindowName{window}";

            name.Text =
                staffName;

            name.AutoSize =
                true;

            name.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold);

            name.ForeColor =
                DarkGreen;

            name.Location =
                new Point(
                    42,
                    y);

            panelActiveStatus.Controls.Add(
                name);

            // =====================================================
            // WINDOW STATE
            // =====================================================

            Label state =
                new Label();

            state.Name =
                $"lblWindowState{window}";

            state.AutoSize =
                true;

            state.Font =
                new Font(
                    "Segoe UI",
                    7.5F);

            state.Location =
                new Point(
                    42,
                    y + 17);

            panelActiveStatus.Controls.Add(
                state);

            // =====================================================
            // DESCRIPTION
            // =====================================================

            Label description =
                new Label();

            description.Name =
                $"lblWindowDescription{window}";

            description.AutoSize =
                true;

            description.Font =
                new Font(
                    "Segoe UI",
                    7.5F);

            description.Location =
                new Point(
                    190,
                    y + 8);

            panelActiveStatus.Controls.Add(
                description);

            // =====================================================
            // WINDOW BUTTON
            // =====================================================

            Button? statusButton =
                window switch
                {
                    1 => btnWindow1,
                    2 => btnWindow2,
                    3 => btnWindow3,
                    4 => btnWindow4,
                    _ => null
                };

            if (statusButton == null)
                return;

            if (statusButton.Parent !=
                panelActiveStatus)
            {
                panelActiveStatus.Controls.Add(
                    statusButton);
            }

            statusButton.Size =
                new Size(
                    55,
                    27);

            statusButton.Location =
                new Point(
                    panelActiveStatus.Width - 75,
                    y - 2);

            statusButton.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            statusButton.Font =
                new Font(
                    "Segoe UI",
                    7.5F,
                    FontStyle.Bold);

            statusButton.Cursor =
                Cursors.Hand;

            // =====================================================
            // NO OUTLINE
            // =====================================================

            statusButton.FlatStyle =
                FlatStyle.Flat;

            statusButton.FlatAppearance.BorderSize =
                0;

            statusButton.FlatAppearance.MouseOverBackColor =
                statusButton.BackColor;

            statusButton.FlatAppearance.MouseDownBackColor =
                statusButton.BackColor;

            statusButton.UseVisualStyleBackColor =
                false;

            statusButton.TabStop =
                false;

            MakeButtonRounded(
                statusButton,
                10);

            // =====================================================
            // INITIAL STATUS
            // =====================================================

            UpdateWindowStatus(
                window,
                _presenter.GetWindowStatus(window));
        }

        // =========================================================
        // WINDOW 1
        // =========================================================

        private void BtnWindow1_Click(
            object? sender,
            EventArgs e)
        {
            ToggleWindowStatus(1);
        }

        // =========================================================
        // WINDOW 2
        // =========================================================

        private void BtnWindow2_Click(
            object? sender,
            EventArgs e)
        {
            ToggleWindowStatus(2);
        }

        // =========================================================
        // WINDOW 3
        // =========================================================

        private void BtnWindow3_Click(
            object? sender,
            EventArgs e)
        {
            ToggleWindowStatus(3);
        }

        // =========================================================
        // WINDOW 4
        // =========================================================

        private void BtnWindow4_Click(
            object? sender,
            EventArgs e)
        {
            ToggleWindowStatus(4);
        }

        // =========================================================
        // TOGGLE WINDOW STATUS
        // =========================================================

        private void ToggleWindowStatus(
            int windowNumber)
        {
            try
            {
                bool currentStatus =
                    _presenter.GetWindowStatus(
                        windowNumber);

                if (!_presenter.SetWindowStatus(
                        windowNumber,
                        !currentStatus))
                {
                    ShowMessage(
                        $"Unable to update Window {windowNumber} status.",
                        "Window Status",
                        MessageBoxIcon.Warning);

                    return;
                }

                UpdateWindowStatus(
                    windowNumber,
                    !currentStatus);

                ActiveControl = null;
            }
            catch (Exception ex)
            {
                ShowMessage(
                    $"Failed to update Window {windowNumber} status:\n\n{ex.Message}",
                    "Window Status Error",
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // UPDATE ALL WINDOW STATUS
        // =========================================================

        public void UpdateAllWindowStatuses(
            Dictionary<int, bool> statuses)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        () => UpdateAllWindowStatuses(statuses)));

                return;
            }

            foreach (var status in statuses)
            {
                UpdateWindowStatus(
                    status.Key,
                    status.Value);
            }
        }

        // =========================================================
        // UPDATE WINDOW STATUS
        // =========================================================

        public void UpdateWindowStatus(
            int windowNumber,
            bool isActive)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        () => UpdateWindowStatus(
                            windowNumber,
                            isActive)));

                return;
            }

            if (panelActiveStatus == null)
                return;

            Label? dot =
                panelActiveStatus.Controls
                    .Find(
                        $"lblStatusDot{windowNumber}",
                        true)
                    .FirstOrDefault()
                    as Label;

            Label? name =
                panelActiveStatus.Controls
                    .Find(
                        $"lblWindowName{windowNumber}",
                        true)
                    .FirstOrDefault()
                    as Label;

            Label? state =
                panelActiveStatus.Controls
                    .Find(
                        $"lblWindowState{windowNumber}",
                        true)
                    .FirstOrDefault()
                    as Label;

            Label? description =
                panelActiveStatus.Controls
                    .Find(
                        $"lblWindowDescription{windowNumber}",
                        true)
                    .FirstOrDefault()
                    as Label;

            Button? button =
                windowNumber switch
                {
                    1 => btnWindow1,
                    2 => btnWindow2,
                    3 => btnWindow3,
                    4 => btnWindow4,
                    _ => null
                };

            if (dot == null ||
                name == null ||
                state == null ||
                description == null ||
                button == null)
            {
                return;
            }

            string staffName =
                windowNumber switch
                {
                    1 => Window1Staff,
                    2 => Window2Staff,
                    3 => Window3Staff,
                    4 => Window4Staff,
                    _ => "Unassigned"
                };

            if (isActive)
            {
                name.Text = staffName;
                name.ForeColor = DarkGreen;
                dot.ForeColor = Green;
                state.Text = $"WINDOW {windowNumber}   OPEN";
                state.ForeColor = Green;
                description.Text = "Available for transaction";
                description.ForeColor = DarkGray;
                button.Text = "ON";
                button.BackColor = LightGreen;
                button.ForeColor = Green;
            }
            else
            {
                name.Text = "Unassigned";
                name.ForeColor = Red;
                dot.ForeColor = Red;
                state.Text = $"WINDOW {windowNumber}   CLOSED";
                state.ForeColor = Red;
                description.Text = "Temporarily unavailable";
                description.ForeColor =
                    Color.FromArgb(165, 90, 90);
                button.Text = "OFF";
                button.BackColor = LightRed;
                button.ForeColor = Red;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor =
                button.BackColor;
            button.FlatAppearance.MouseDownBackColor =
                button.BackColor;
            button.UseVisualStyleBackColor = false;
            button.TabStop = false;

            MakeButtonRounded(button, 10);
            button.BringToFront();
        }

        // =========================================================
        // ROUNDED BUTTON
        // =========================================================

        private static void MakeButtonRounded(
            Button button,
            int radius = 18)
        {
            if (button == null ||
                button.IsDisposed)
            {
                return;
            }

            if (button.Width <= 0 ||
                button.Height <= 0)
            {
                return;
            }

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                0;

            button.UseVisualStyleBackColor =
                false;

            button.Cursor =
                Cursors.Hand;

            button.TabStop =
                false;

            UpdateButtonRegion(
                button,
                radius);

            button.Resize -=
                RoundedButton_Resize;

            button.Resize +=
                RoundedButton_Resize;

            button.Tag =
                new RoundedButtonInfo
                {
                    Radius = radius
                };
        }

        // =========================================================
        // BUTTON RESIZE
        // =========================================================

        private static void RoundedButton_Resize(
            object? sender,
            EventArgs e)
        {
            if (sender is not Button button)
                return;

            int radius = 18;

            if (button.Tag is RoundedButtonInfo info)
            {
                radius =
                    info.Radius;
            }

            UpdateButtonRegion(
                button,
                radius);
        }

        // =========================================================
        // BUTTON REGION
        // =========================================================

        private static void UpdateButtonRegion(
            Button button,
            int radius)
        {
            if (button.Width <= 0 ||
                button.Height <= 0)
            {
                return;
            }

            Rectangle rect =
                new Rectangle(
                    0,
                    0,
                    button.Width,
                    button.Height);

            using GraphicsPath path =
                CreateRoundedPath(
                    rect,
                    radius);

            button.Region =
                new Region(path);
        }

        // =========================================================
        // ROUNDED PATH
        // =========================================================

        private static GraphicsPath CreateRoundedPath(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path =
                new GraphicsPath();

            int diameter =
                radius * 2;

            if (diameter > rect.Width)
                diameter =
                    rect.Width;

            if (diameter > rect.Height)
                diameter =
                    rect.Height;

            Rectangle arc =
                new Rectangle(
                    rect.X,
                    rect.Y,
                    diameter,
                    diameter);

            path.AddArc(
                arc,
                180,
                90);

            arc.X =
                rect.Right -
                diameter;

            path.AddArc(
                arc,
                270,
                90);

            arc.Y =
                rect.Bottom -
                diameter;

            path.AddArc(
                arc,
                0,
                90);

            arc.X =
                rect.X;

            path.AddArc(
                arc,
                90,
                90);

            path.CloseFigure();

            return path;
        }

        // =========================================================
        // ROUNDED BUTTON INFO
        // =========================================================

        private sealed class RoundedButtonInfo
        {
            public int Radius { get; set; }
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void Staff_Load(
            object? sender,
            EventArgs e)
        {
            try
            {
                UpdateAllWindowStatuses(
                    _presenter.GetAllWindowStatuses());

                ConfigureMainButtons();

                ConfigureWindowButtons();

                ConfigureQueueGrid();

                _presenter.RefreshQueueView();

                UpdateQueueAnalytics();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    $"Failed to load Registrar Dashboard:\n\n{ex.Message}",
                    "Registrar Error",
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SERVICE BUTTON
        // =========================================================

        private void btn_service_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                _presenter.ServiceWindow();

                ActiveControl = null;
            }
            catch (Exception ex)
            {
                ShowMessage(
                    $"Failed to open service window:\n\n{ex.Message}",
                    "Service Error",
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DATA GRID CLICK
        // =========================================================

        private void dataGridViewQueue_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            // Existing behavior preserved.
        }

        // =========================================================
        // ADD TO QUEUE
        // =========================================================

        public void AddToQueue(
            string purpose,
            string service)
        {
            _presenter.AddToQueue(
                purpose,
                service);
        }

        // =========================================================
        // FORM RESIZE
        // =========================================================

        protected override void OnResize(
            EventArgs e)
        {
            if (
                WindowState ==
                FormWindowState.Minimized)
            {
                Hide();

                trayIcon.Visible =
                    true;

                trayIcon.BalloonTipTitle =
                    "CampusQ - Registrar";

                trayIcon.BalloonTipText =
                    "Registrar Dashboard is still running.";

                trayIcon.ShowBalloonTip(
                    1000);
            }

            base.OnResize(e);
        }

        // =========================================================
        // FORM CLOSING
        // =========================================================

        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            trayIcon.Visible =
                false;

            base.OnFormClosing(e);
        }

        // =========================================================
        // TRAY DOUBLE CLICK
        // =========================================================

        private void trayIcon_MouseDoubleClick(
            object? sender,
            MouseEventArgs e)
        {
            if (
                e.Button !=
                MouseButtons.Left)
            {
                return;
            }

            Show();

            WindowState =
                FormWindowState.Normal;

            trayIcon.Visible =
                false;

            BringToFront();

            Activate();

            ActiveControl =
                null;
        }
    }
}