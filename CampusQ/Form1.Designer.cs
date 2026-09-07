using System;
using System.Drawing;
using System.Windows.Forms;

namespace CampusQ
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblWelcome;
        private Label lblChooseService;
        private Label lblMotto;

        private Panel pnlNowServing;
        private Panel pnlEstimatedWait;
        private Panel pnlHowItWorks;
        private Panel pnlAnnouncements;

        private Label lblNowServingTitle;
        private Panel cardRegistrarNow;
        private Panel cardCashierNow;
        private Panel cardAdmissionNow;
        private Panel iconRegistrarNow;
        private Panel iconCashierNow;
        private Panel iconAdmissionNow;
        private Label lblRegistrarIcon;
        private Label lblCashierIcon;
        private Label lblAdmissionIcon;
        private Label lblRegistrarTitle;
        private Label lblCashierTitle;
        private Label lblAdmissionTitle;
        private Label lblRegistrarNowTicket;
        private Label lblCashierNowTicket;
        private Label lblAdmissionNowTicket;

        private Label lblEstimatedWaitTitle;
        private Panel cardRegistrarWait;
        private Panel cardCashierWait;
        private Panel cardAdmissionWait;
        private Panel iconRegistrarWait;
        private Panel iconCashierWait;
        private Panel iconAdmissionWait;
        private Label lblRegistrarWaitIcon;
        private Label lblCashierWaitIcon;
        private Label lblAdmissionWaitIcon;
        private Label lblRegistrarWaitTitle;
        private Label lblCashierWaitTitle;
        private Label lblAdmissionWaitTitle;
        private Label lblRegistrarAverage;
        private Label lblCashierAverage;
        private Label lblAdmissionAverage;
        private Label lblRegistrarMins;
        private Label lblCashierMins;
        private Label lblAdmissionMins;
        private Label lblRegistrarWaitValue;
        private Label lblCashierWaitValue;
        private Label lblAdmissionWaitValue;

        private Label lblHowItWorksTitle;
        private Panel step1Icon;
        private Panel step2Icon;
        private Panel step3Icon;
        private Panel step4Icon;
        private Panel stepLine1;
        private Panel stepLine2;
        private Panel stepLine3;
        private Label lblStep1Number;
        private Label lblStep2Number;
        private Label lblStep3Number;
        private Label lblStep4Number;
        private Label lblStep1Title;
        private Label lblStep2Title;
        private Label lblStep3Title;
        private Label lblStep4Title;
        private Label lblStep1Description;
        private Label lblStep2Description;
        private Label lblStep3Description;
        private Label lblStep4Description;

        private Label lblAnnouncementsTitle;
        private Panel pnlAnnouncementArea;

        private PictureBox btn_cashier;
        private PictureBox btn_registrar;
        private PictureBox btn_admission;

        private Panel registrarIconCircle;
        private Label registrarIconText;
        private Label registrarButtonTitle;
        private Label registrarButtonDescription;
        private Label registrarButtonArrow;

        private Panel cashierIconCircle;
        private Label cashierIconText;
        private Label cashierButtonTitle;
        private Label cashierButtonDescription;
        private Label cashierButtonArrow;

        private Panel admissionIconCircle;
        private Label admissionIconText;
        private Label admissionButtonTitle;
        private Label admissionButtonDescription;
        private Label admissionButtonArrow;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        // ============================================================
        // ROUNDED CORNERS ONLY
        // No layout, size, position, font, color, or text is changed.
        // ============================================================
        private static void ApplyRounded(Control control, int radius)
        {
            if (control == null || control.Width <= 1 || control.Height <= 1)
                return;

            int r = Math.Min(radius, Math.Min(control.Width, control.Height) / 2);
            int d = Math.Max(1, r * 2);

            Rectangle rect = new Rectangle(
                0, 0,
                control.Width - 1,
                control.Height - 1);

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                Region old = control.Region;
                control.Region = new Region(path);
                old?.Dispose();
            }
        }

        private void RoundedControl_Resize(object sender, EventArgs e)
        {
            if (sender is not Control c)
                return;

            int radius = 18;

            if (c == pnlNowServing || c == pnlEstimatedWait ||
                c == pnlHowItWorks || c == pnlAnnouncements)
                radius = 28;
            else if (c == btn_registrar || c == btn_cashier || c == btn_admission)
                radius = 22;

            ApplyRounded(c, radius);
        }

        private void RoundedControl_Paint(object sender, PaintEventArgs e)
        {
            // No visible border. Curves come from the rounded Region.
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblChooseService = new Label();
            lblMotto = new Label();
            pnlNowServing = new Panel();
            lblNowServingTitle = new Label();
            cardRegistrarNow = new Panel();
            iconRegistrarNow = new Panel();
            lblRegistrarIcon = new Label();
            lblRegistrarTitle = new Label();
            lblRegistrarNowTicket = new Label();
            cardCashierNow = new Panel();
            iconCashierNow = new Panel();
            lblCashierIcon = new Label();
            lblCashierTitle = new Label();
            lblCashierNowTicket = new Label();
            cardAdmissionNow = new Panel();
            iconAdmissionNow = new Panel();
            lblAdmissionIcon = new Label();
            lblAdmissionTitle = new Label();
            lblAdmissionNowTicket = new Label();
            pnlEstimatedWait = new Panel();
            lblEstimatedWaitTitle = new Label();
            cardRegistrarWait = new Panel();
            iconRegistrarWait = new Panel();
            lblRegistrarWaitIcon = new Label();
            lblRegistrarWaitTitle = new Label();
            lblRegistrarAverage = new Label();
            lblRegistrarWaitValue = new Label();
            lblRegistrarMins = new Label();
            cardCashierWait = new Panel();
            iconCashierWait = new Panel();
            lblCashierWaitIcon = new Label();
            lblCashierWaitTitle = new Label();
            lblCashierAverage = new Label();
            lblCashierWaitValue = new Label();
            lblCashierMins = new Label();
            cardAdmissionWait = new Panel();
            iconAdmissionWait = new Panel();
            lblAdmissionWaitIcon = new Label();
            lblAdmissionWaitTitle = new Label();
            lblAdmissionAverage = new Label();
            lblAdmissionWaitValue = new Label();
            lblAdmissionMins = new Label();
            pnlHowItWorks = new Panel();
            lblHowItWorksTitle = new Label();
            stepLine1 = new Panel();
            stepLine2 = new Panel();
            stepLine3 = new Panel();
            lblStep1Number = new Label();
            lblStep2Number = new Label();
            lblStep3Number = new Label();
            lblStep4Number = new Label();
            step1Icon = new Panel();
            step1Glyph = new Label();
            step2Icon = new Panel();
            step2Glyph = new Label();
            step3Icon = new Panel();
            step3Glyph = new Label();
            step4Icon = new Panel();
            step4Glyph = new Label();
            lblStep1Title = new Label();
            lblStep2Title = new Label();
            lblStep3Title = new Label();
            lblStep4Title = new Label();
            lblStep1Description = new Label();
            lblStep2Description = new Label();
            lblStep3Description = new Label();
            lblStep4Description = new Label();
            pnlAnnouncements = new Panel();
            lblAnnouncementsTitle = new Label();
            pnlAnnouncementArea = new Panel();
            btn_registrar = new PictureBox();
            registrarIconCircle = new Panel();
            registrarIconText = new Label();
            registrarButtonTitle = new Label();
            registrarButtonDescription = new Label();
            registrarButtonArrow = new Label();
            btn_cashier = new PictureBox();
            cashierIconCircle = new Panel();
            cashierIconText = new Label();
            cashierButtonTitle = new Label();
            cashierButtonDescription = new Label();
            cashierButtonArrow = new Label();
            btn_admission = new PictureBox();
            admissionIconCircle = new Panel();
            admissionIconText = new Label();
            admissionButtonTitle = new Label();
            admissionButtonDescription = new Label();
            admissionButtonArrow = new Label();
            pnlNowServing.SuspendLayout();
            cardRegistrarNow.SuspendLayout();
            iconRegistrarNow.SuspendLayout();
            cardCashierNow.SuspendLayout();
            iconCashierNow.SuspendLayout();
            cardAdmissionNow.SuspendLayout();
            iconAdmissionNow.SuspendLayout();
            pnlEstimatedWait.SuspendLayout();
            cardRegistrarWait.SuspendLayout();
            iconRegistrarWait.SuspendLayout();
            cardCashierWait.SuspendLayout();
            iconCashierWait.SuspendLayout();
            cardAdmissionWait.SuspendLayout();
            iconAdmissionWait.SuspendLayout();
            pnlHowItWorks.SuspendLayout();
            step1Icon.SuspendLayout();
            step2Icon.SuspendLayout();
            step3Icon.SuspendLayout();
            step4Icon.SuspendLayout();
            pnlAnnouncements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_registrar).BeginInit();
            btn_registrar.SuspendLayout();
            registrarIconCircle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_cashier).BeginInit();
            btn_cashier.SuspendLayout();
            cashierIconCircle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_admission).BeginInit();
            btn_admission.SuspendLayout();
            admissionIconCircle.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(126, 190, 126);
            lblWelcome.Location = new Point(45, 179);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(430, 45);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "WELCOME!";
            lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblChooseService
            // 
            lblChooseService.BackColor = Color.Transparent;
            lblChooseService.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            lblChooseService.ForeColor = Color.White;
            lblChooseService.Location = new Point(35, 224);
            lblChooseService.Name = "lblChooseService";
            lblChooseService.Size = new Size(430, 165);
            lblChooseService.TabIndex = 1;
            lblChooseService.Text = "CHOOSE A\r\nSERVICE";
            lblChooseService.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMotto
            // 
            lblMotto.BackColor = Color.Transparent;
            lblMotto.Font = new Font("Segoe UI", 12F);
            lblMotto.ForeColor = Color.White;
            lblMotto.Location = new Point(43, 389);
            lblMotto.Name = "lblMotto";
            lblMotto.Size = new Size(430, 35);
            lblMotto.TabIndex = 2;
            lblMotto.Text = "\"Excellence. Integrity. Service.\"";
            lblMotto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlNowServing
            // 
            pnlNowServing.BackColor = Color.White;
            pnlNowServing.Controls.Add(lblNowServingTitle);
            pnlNowServing.Controls.Add(cardRegistrarNow);
            pnlNowServing.Controls.Add(cardCashierNow);
            pnlNowServing.Controls.Add(cardAdmissionNow);
            pnlNowServing.Location = new Point(660, 108);
            pnlNowServing.Name = "pnlNowServing";
            pnlNowServing.Size = new Size(641, 414);
            ApplyRounded(pnlNowServing, 28);
            pnlNowServing.Resize += RoundedControl_Resize;
            pnlNowServing.TabIndex = 6;
            // 
            // lblNowServingTitle
            // 
            lblNowServingTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblNowServingTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblNowServingTitle.Location = new Point(15, 5);
            lblNowServingTitle.Name = "lblNowServingTitle";
            lblNowServingTitle.Size = new Size(600, 45);
            lblNowServingTitle.TabIndex = 0;
            lblNowServingTitle.Text = "🔊  NOW SERVING";
            lblNowServingTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardRegistrarNow
            // 
            cardRegistrarNow.BackColor = Color.White;
            cardRegistrarNow.Controls.Add(iconRegistrarNow);
            cardRegistrarNow.Controls.Add(lblRegistrarTitle);
            cardRegistrarNow.Controls.Add(lblRegistrarNowTicket);
            cardRegistrarNow.Location = new Point(15, 60);
            cardRegistrarNow.Name = "cardRegistrarNow";
            cardRegistrarNow.Size = new Size(609, 110);
            ApplyRounded(cardRegistrarNow, 18);
            cardRegistrarNow.Resize += RoundedControl_Resize;
            cardRegistrarNow.TabIndex = 1;
            // 
            // iconRegistrarNow
            // 
            iconRegistrarNow.BackColor = Color.FromArgb(239, 247, 238);
            iconRegistrarNow.Controls.Add(lblRegistrarIcon);
            iconRegistrarNow.Enabled = true;
            iconRegistrarNow.Location = new Point(25, 20);
            iconRegistrarNow.Name = "iconRegistrarNow";
            iconRegistrarNow.Size = new Size(84, 70);
            iconRegistrarNow.TabIndex = 0;
            // 
            // lblRegistrarIcon
            // 
            lblRegistrarIcon.Dock = DockStyle.Fill;
            lblRegistrarIcon.Font = new Font("Segoe UI Symbol", 27F, FontStyle.Bold);
            lblRegistrarIcon.ForeColor = Color.FromArgb(10, 70, 45);
            lblRegistrarIcon.Location = new Point(0, 0);
            lblRegistrarIcon.Name = "lblRegistrarIcon";
            lblRegistrarIcon.Size = new Size(84, 70);
            lblRegistrarIcon.TabIndex = 0;
            lblRegistrarIcon.Text = "♟";
            lblRegistrarIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegistrarTitle
            // 
            lblRegistrarTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRegistrarTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblRegistrarTitle.Location = new Point(115, 32);
            lblRegistrarTitle.Name = "lblRegistrarTitle";
            lblRegistrarTitle.Size = new Size(250, 40);
            lblRegistrarTitle.TabIndex = 1;
            lblRegistrarTitle.Text = "REGISTRAR";
            lblRegistrarTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRegistrarNowTicket
            // 
            lblRegistrarNowTicket.BackColor = Color.Transparent;
            lblRegistrarNowTicket.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblRegistrarNowTicket.ForeColor = Color.FromArgb(126, 190, 126);
            lblRegistrarNowTicket.Location = new Point(345, 20);
            lblRegistrarNowTicket.Name = "lblRegistrarNowTicket";
            lblRegistrarNowTicket.Size = new Size(245, 65);
            lblRegistrarNowTicket.TabIndex = 2;
            lblRegistrarNowTicket.Text = "RO-001";
            lblRegistrarNowTicket.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardCashierNow
            // 
            cardCashierNow.BackColor = Color.White;
            cardCashierNow.Controls.Add(iconCashierNow);
            cardCashierNow.Controls.Add(lblCashierTitle);
            cardCashierNow.Controls.Add(lblCashierNowTicket);
            cardCashierNow.Location = new Point(15, 180);
            cardCashierNow.Name = "cardCashierNow";
            cardCashierNow.Size = new Size(609, 110);
            ApplyRounded(cardCashierNow, 18);
            cardCashierNow.Resize += RoundedControl_Resize;
            cardCashierNow.TabIndex = 2;
            // 
            // iconCashierNow
            // 
            iconCashierNow.BackColor = Color.FromArgb(239, 247, 238);
            iconCashierNow.Controls.Add(lblCashierIcon);
            iconCashierNow.Enabled = true;
            iconCashierNow.Location = new Point(25, 20);
            iconCashierNow.Name = "iconCashierNow";
            iconCashierNow.Size = new Size(84, 70);
            iconCashierNow.TabIndex = 0;
            // 
            // lblCashierIcon
            // 
            lblCashierIcon.Dock = DockStyle.Fill;
            lblCashierIcon.Font = new Font("Segoe UI Symbol", 27F, FontStyle.Bold);
            lblCashierIcon.ForeColor = Color.FromArgb(10, 70, 45);
            lblCashierIcon.Location = new Point(0, 0);
            lblCashierIcon.Name = "lblCashierIcon";
            lblCashierIcon.Size = new Size(84, 70);
            lblCashierIcon.TabIndex = 0;
            lblCashierIcon.Text = "$";
            lblCashierIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCashierTitle
            // 
            lblCashierTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCashierTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblCashierTitle.Location = new Point(115, 32);
            lblCashierTitle.Name = "lblCashierTitle";
            lblCashierTitle.Size = new Size(250, 40);
            lblCashierTitle.TabIndex = 1;
            lblCashierTitle.Text = "CASHIER";
            lblCashierTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCashierNowTicket
            // 
            lblCashierNowTicket.BackColor = Color.Transparent;
            lblCashierNowTicket.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblCashierNowTicket.ForeColor = Color.FromArgb(126, 190, 126);
            lblCashierNowTicket.Location = new Point(345, 20);
            lblCashierNowTicket.Name = "lblCashierNowTicket";
            lblCashierNowTicket.Size = new Size(245, 65);
            lblCashierNowTicket.TabIndex = 2;
            lblCashierNowTicket.Text = "CM-001";
            lblCashierNowTicket.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardAdmissionNow
            // 
            cardAdmissionNow.BackColor = Color.White;
            cardAdmissionNow.Controls.Add(iconAdmissionNow);
            cardAdmissionNow.Controls.Add(lblAdmissionTitle);
            cardAdmissionNow.Controls.Add(lblAdmissionNowTicket);
            cardAdmissionNow.Location = new Point(15, 300);
            cardAdmissionNow.Name = "cardAdmissionNow";
            cardAdmissionNow.Size = new Size(609, 110);
            ApplyRounded(cardAdmissionNow, 18);
            cardAdmissionNow.Resize += RoundedControl_Resize;
            cardAdmissionNow.TabIndex = 3;
            // 
            // iconAdmissionNow
            // 
            iconAdmissionNow.BackColor = Color.FromArgb(239, 247, 238);
            iconAdmissionNow.Controls.Add(lblAdmissionIcon);
            iconAdmissionNow.Enabled = true;
            iconAdmissionNow.Location = new Point(25, 20);
            iconAdmissionNow.Name = "iconAdmissionNow";
            iconAdmissionNow.Size = new Size(84, 70);
            iconAdmissionNow.TabIndex = 0;
            // 
            // lblAdmissionIcon
            // 
            lblAdmissionIcon.Dock = DockStyle.Fill;
            lblAdmissionIcon.Font = new Font("Segoe UI Symbol", 27F, FontStyle.Bold);
            lblAdmissionIcon.ForeColor = Color.FromArgb(10, 70, 45);
            lblAdmissionIcon.Location = new Point(0, 0);
            lblAdmissionIcon.Name = "lblAdmissionIcon";
            lblAdmissionIcon.Size = new Size(84, 70);
            lblAdmissionIcon.TabIndex = 0;
            lblAdmissionIcon.Text = "🎓";
            lblAdmissionIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdmissionTitle
            // 
            lblAdmissionTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAdmissionTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblAdmissionTitle.Location = new Point(115, 32);
            lblAdmissionTitle.Name = "lblAdmissionTitle";
            lblAdmissionTitle.Size = new Size(250, 40);
            lblAdmissionTitle.TabIndex = 1;
            lblAdmissionTitle.Text = "ADMISSION";
            lblAdmissionTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAdmissionNowTicket
            // 
            lblAdmissionNowTicket.BackColor = Color.Transparent;
            lblAdmissionNowTicket.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblAdmissionNowTicket.ForeColor = Color.FromArgb(126, 190, 126);
            lblAdmissionNowTicket.Location = new Point(345, 20);
            lblAdmissionNowTicket.Name = "lblAdmissionNowTicket";
            lblAdmissionNowTicket.Size = new Size(245, 65);
            lblAdmissionNowTicket.TabIndex = 2;
            lblAdmissionNowTicket.Text = "AA-001";
            lblAdmissionNowTicket.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEstimatedWait
            // 
            pnlEstimatedWait.BackColor = Color.White;
            pnlEstimatedWait.Controls.Add(lblEstimatedWaitTitle);
            pnlEstimatedWait.Controls.Add(cardRegistrarWait);
            pnlEstimatedWait.Controls.Add(cardCashierWait);
            pnlEstimatedWait.Controls.Add(cardAdmissionWait);
            pnlEstimatedWait.Location = new Point(1307, 108);
            pnlEstimatedWait.Name = "pnlEstimatedWait";
            pnlEstimatedWait.Size = new Size(553, 413);
            ApplyRounded(pnlEstimatedWait, 28);
            pnlEstimatedWait.Resize += RoundedControl_Resize;
            pnlEstimatedWait.TabIndex = 7;
            // 
            // lblEstimatedWaitTitle
            // 
            lblEstimatedWaitTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblEstimatedWaitTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblEstimatedWaitTitle.Location = new Point(5, 5);
            lblEstimatedWaitTitle.Name = "lblEstimatedWaitTitle";
            lblEstimatedWaitTitle.Size = new Size(538, 45);
            lblEstimatedWaitTitle.TabIndex = 0;
            lblEstimatedWaitTitle.Text = "◷  ESTIMATED WAIT TIME";
            lblEstimatedWaitTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardRegistrarWait
            // 
            cardRegistrarWait.BackColor = Color.White;
            cardRegistrarWait.Controls.Add(iconRegistrarWait);
            cardRegistrarWait.Controls.Add(lblRegistrarWaitTitle);
            cardRegistrarWait.Controls.Add(lblRegistrarAverage);
            cardRegistrarWait.Controls.Add(lblRegistrarWaitValue);
            cardRegistrarWait.Controls.Add(lblRegistrarMins);
            cardRegistrarWait.Location = new Point(5, 60);
            cardRegistrarWait.Name = "cardRegistrarWait";
            cardRegistrarWait.Size = new Size(538, 110);
            ApplyRounded(cardRegistrarWait, 18);
            cardRegistrarWait.Resize += RoundedControl_Resize;
            cardRegistrarWait.TabIndex = 1;
            // 
            // iconRegistrarWait
            // 
            iconRegistrarWait.BackColor = Color.FromArgb(239, 247, 238);
            iconRegistrarWait.Controls.Add(lblRegistrarWaitIcon);
            iconRegistrarWait.Enabled = true;
            iconRegistrarWait.Location = new Point(25, 20);
            iconRegistrarWait.Name = "iconRegistrarWait";
            iconRegistrarWait.Size = new Size(64, 70);
            iconRegistrarWait.TabIndex = 0;
            // 
            // lblRegistrarWaitIcon
            // 
            lblRegistrarWaitIcon.Dock = DockStyle.Fill;
            lblRegistrarWaitIcon.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold);
            lblRegistrarWaitIcon.ForeColor = Color.FromArgb(10, 70, 45);
            lblRegistrarWaitIcon.Location = new Point(0, 0);
            lblRegistrarWaitIcon.Name = "lblRegistrarWaitIcon";
            lblRegistrarWaitIcon.Size = new Size(64, 70);
            lblRegistrarWaitIcon.TabIndex = 0;
            lblRegistrarWaitIcon.Text = "♟";
            lblRegistrarWaitIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegistrarWaitTitle
            // 
            lblRegistrarWaitTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblRegistrarWaitTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblRegistrarWaitTitle.Location = new Point(95, 20);
            lblRegistrarWaitTitle.Name = "lblRegistrarWaitTitle";
            lblRegistrarWaitTitle.Size = new Size(220, 35);
            lblRegistrarWaitTitle.TabIndex = 1;
            lblRegistrarWaitTitle.Text = "REGISTRAR";
            lblRegistrarWaitTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRegistrarAverage
            // 
            lblRegistrarAverage.Font = new Font("Segoe UI", 10F);
            lblRegistrarAverage.ForeColor = Color.FromArgb(45, 90, 70);
            lblRegistrarAverage.Location = new Point(95, 55);
            lblRegistrarAverage.Name = "lblRegistrarAverage";
            lblRegistrarAverage.Size = new Size(220, 25);
            lblRegistrarAverage.TabIndex = 2;
            lblRegistrarAverage.Text = "Average Wait";
            lblRegistrarAverage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRegistrarWaitValue
            // 
            lblRegistrarWaitValue.BackColor = Color.Transparent;
            lblRegistrarWaitValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblRegistrarWaitValue.ForeColor = Color.FromArgb(126, 190, 126);
            lblRegistrarWaitValue.Location = new Point(350, 22);
            lblRegistrarWaitValue.Name = "lblRegistrarWaitValue";
            lblRegistrarWaitValue.Size = new Size(70, 60);
            lblRegistrarWaitValue.TabIndex = 3;
            lblRegistrarWaitValue.Text = "20";
            lblRegistrarWaitValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegistrarMins
            // 
            lblRegistrarMins.Font = new Font("Segoe UI", 10F);
            lblRegistrarMins.ForeColor = Color.FromArgb(45, 90, 70);
            lblRegistrarMins.Location = new Point(435, 40);
            lblRegistrarMins.Name = "lblRegistrarMins";
            lblRegistrarMins.Size = new Size(70, 30);
            lblRegistrarMins.TabIndex = 4;
            lblRegistrarMins.Text = "mins";
            lblRegistrarMins.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardCashierWait
            // 
            cardCashierWait.BackColor = Color.White;
            cardCashierWait.Controls.Add(iconCashierWait);
            cardCashierWait.Controls.Add(lblCashierWaitTitle);
            cardCashierWait.Controls.Add(lblCashierAverage);
            cardCashierWait.Controls.Add(lblCashierWaitValue);
            cardCashierWait.Controls.Add(lblCashierMins);
            cardCashierWait.Location = new Point(5, 180);
            cardCashierWait.Name = "cardCashierWait";
            cardCashierWait.Size = new Size(538, 110);
            ApplyRounded(cardCashierWait, 18);
            cardCashierWait.Resize += RoundedControl_Resize;
            cardCashierWait.TabIndex = 2;
            // 
            // iconCashierWait
            // 
            iconCashierWait.BackColor = Color.FromArgb(239, 247, 238);
            iconCashierWait.Controls.Add(lblCashierWaitIcon);
            iconCashierWait.Enabled = true;
            iconCashierWait.Location = new Point(25, 20);
            iconCashierWait.Name = "iconCashierWait";
            iconCashierWait.Size = new Size(64, 70);
            iconCashierWait.TabIndex = 0;
            // 
            // lblCashierWaitIcon
            // 
            lblCashierWaitIcon.Dock = DockStyle.Fill;
            lblCashierWaitIcon.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold);
            lblCashierWaitIcon.ForeColor = Color.FromArgb(10, 70, 45);
            lblCashierWaitIcon.Location = new Point(0, 0);
            lblCashierWaitIcon.Name = "lblCashierWaitIcon";
            lblCashierWaitIcon.Size = new Size(64, 70);
            lblCashierWaitIcon.TabIndex = 0;
            lblCashierWaitIcon.Text = "$";
            lblCashierWaitIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCashierWaitTitle
            // 
            lblCashierWaitTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCashierWaitTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblCashierWaitTitle.Location = new Point(95, 20);
            lblCashierWaitTitle.Name = "lblCashierWaitTitle";
            lblCashierWaitTitle.Size = new Size(220, 35);
            lblCashierWaitTitle.TabIndex = 1;
            lblCashierWaitTitle.Text = "CASHIER";
            lblCashierWaitTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCashierAverage
            // 
            lblCashierAverage.Font = new Font("Segoe UI", 10F);
            lblCashierAverage.ForeColor = Color.FromArgb(45, 90, 70);
            lblCashierAverage.Location = new Point(95, 55);
            lblCashierAverage.Name = "lblCashierAverage";
            lblCashierAverage.Size = new Size(220, 25);
            lblCashierAverage.TabIndex = 2;
            lblCashierAverage.Text = "Average Wait";
            lblCashierAverage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCashierWaitValue
            // 
            lblCashierWaitValue.BackColor = Color.Transparent;
            lblCashierWaitValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblCashierWaitValue.ForeColor = Color.FromArgb(126, 190, 126);
            lblCashierWaitValue.Location = new Point(350, 22);
            lblCashierWaitValue.Name = "lblCashierWaitValue";
            lblCashierWaitValue.Size = new Size(70, 60);
            lblCashierWaitValue.TabIndex = 3;
            lblCashierWaitValue.Text = "0";
            lblCashierWaitValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCashierMins
            // 
            lblCashierMins.Font = new Font("Segoe UI", 10F);
            lblCashierMins.ForeColor = Color.FromArgb(45, 90, 70);
            lblCashierMins.Location = new Point(435, 40);
            lblCashierMins.Name = "lblCashierMins";
            lblCashierMins.Size = new Size(70, 30);
            lblCashierMins.TabIndex = 4;
            lblCashierMins.Text = "mins";
            lblCashierMins.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardAdmissionWait
            // 
            cardAdmissionWait.BackColor = Color.White;
            cardAdmissionWait.Controls.Add(iconAdmissionWait);
            cardAdmissionWait.Controls.Add(lblAdmissionWaitTitle);
            cardAdmissionWait.Controls.Add(lblAdmissionAverage);
            cardAdmissionWait.Controls.Add(lblAdmissionWaitValue);
            cardAdmissionWait.Controls.Add(lblAdmissionMins);
            cardAdmissionWait.Location = new Point(5, 300);
            cardAdmissionWait.Name = "cardAdmissionWait";
            cardAdmissionWait.Size = new Size(538, 110);
            ApplyRounded(cardAdmissionWait, 18);
            cardAdmissionWait.Resize += RoundedControl_Resize;
            cardAdmissionWait.TabIndex = 3;
            // 
            // iconAdmissionWait
            // 
            iconAdmissionWait.BackColor = Color.FromArgb(239, 247, 238);
            iconAdmissionWait.Controls.Add(lblAdmissionWaitIcon);
            iconAdmissionWait.Enabled = true;
            iconAdmissionWait.Location = new Point(25, 20);
            iconAdmissionWait.Name = "iconAdmissionWait";
            iconAdmissionWait.Size = new Size(64, 70);
            iconAdmissionWait.TabIndex = 0;
            // 
            // lblAdmissionWaitIcon
            // 
            lblAdmissionWaitIcon.Dock = DockStyle.Fill;
            lblAdmissionWaitIcon.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold);
            lblAdmissionWaitIcon.ForeColor = Color.FromArgb(10, 70, 45);
            lblAdmissionWaitIcon.Location = new Point(0, 0);
            lblAdmissionWaitIcon.Name = "lblAdmissionWaitIcon";
            lblAdmissionWaitIcon.Size = new Size(64, 70);
            lblAdmissionWaitIcon.TabIndex = 0;
            lblAdmissionWaitIcon.Text = "🎓";
            lblAdmissionWaitIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdmissionWaitTitle
            // 
            lblAdmissionWaitTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAdmissionWaitTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblAdmissionWaitTitle.Location = new Point(95, 20);
            lblAdmissionWaitTitle.Name = "lblAdmissionWaitTitle";
            lblAdmissionWaitTitle.Size = new Size(220, 35);
            lblAdmissionWaitTitle.TabIndex = 1;
            lblAdmissionWaitTitle.Text = "ADMISSION";
            lblAdmissionWaitTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAdmissionAverage
            // 
            lblAdmissionAverage.Font = new Font("Segoe UI", 10F);
            lblAdmissionAverage.ForeColor = Color.FromArgb(45, 90, 70);
            lblAdmissionAverage.Location = new Point(95, 55);
            lblAdmissionAverage.Name = "lblAdmissionAverage";
            lblAdmissionAverage.Size = new Size(220, 25);
            lblAdmissionAverage.TabIndex = 2;
            lblAdmissionAverage.Text = "Average Wait";
            lblAdmissionAverage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAdmissionWaitValue
            // 
            lblAdmissionWaitValue.BackColor = Color.Transparent;
            lblAdmissionWaitValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblAdmissionWaitValue.ForeColor = Color.FromArgb(126, 190, 126);
            lblAdmissionWaitValue.Location = new Point(350, 22);
            lblAdmissionWaitValue.Name = "lblAdmissionWaitValue";
            lblAdmissionWaitValue.Size = new Size(70, 60);
            lblAdmissionWaitValue.TabIndex = 3;
            lblAdmissionWaitValue.Text = "0";
            lblAdmissionWaitValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdmissionMins
            // 
            lblAdmissionMins.Font = new Font("Segoe UI", 10F);
            lblAdmissionMins.ForeColor = Color.FromArgb(45, 90, 70);
            lblAdmissionMins.Location = new Point(435, 40);
            lblAdmissionMins.Name = "lblAdmissionMins";
            lblAdmissionMins.Size = new Size(70, 30);
            lblAdmissionMins.TabIndex = 4;
            lblAdmissionMins.Text = "mins";
            lblAdmissionMins.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHowItWorks
            // 
            pnlHowItWorks.BackColor = Color.FromArgb(243, 250, 242);
            pnlHowItWorks.Controls.Add(lblHowItWorksTitle);
            pnlHowItWorks.Controls.Add(stepLine1);
            pnlHowItWorks.Controls.Add(stepLine2);
            pnlHowItWorks.Controls.Add(stepLine3);
            pnlHowItWorks.Controls.Add(lblStep1Number);
            pnlHowItWorks.Controls.Add(lblStep2Number);
            pnlHowItWorks.Controls.Add(lblStep3Number);
            pnlHowItWorks.Controls.Add(lblStep4Number);
            pnlHowItWorks.Controls.Add(step1Icon);
            pnlHowItWorks.Controls.Add(step2Icon);
            pnlHowItWorks.Controls.Add(step3Icon);
            pnlHowItWorks.Controls.Add(step4Icon);
            pnlHowItWorks.Controls.Add(lblStep1Title);
            pnlHowItWorks.Controls.Add(lblStep2Title);
            pnlHowItWorks.Controls.Add(lblStep3Title);
            pnlHowItWorks.Controls.Add(lblStep4Title);
            pnlHowItWorks.Controls.Add(lblStep1Description);
            pnlHowItWorks.Controls.Add(lblStep2Description);
            pnlHowItWorks.Controls.Add(lblStep3Description);
            pnlHowItWorks.Controls.Add(lblStep4Description);
            pnlHowItWorks.Location = new Point(659, 614);
            pnlHowItWorks.Name = "pnlHowItWorks";
            pnlHowItWorks.Size = new Size(715, 331);
            ApplyRounded(pnlHowItWorks, 28);
            pnlHowItWorks.Resize += RoundedControl_Resize;
            pnlHowItWorks.TabIndex = 8;
            // 
            // lblHowItWorksTitle
            // 
            lblHowItWorksTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHowItWorksTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblHowItWorksTitle.Location = new Point(25, 18);
            lblHowItWorksTitle.Name = "lblHowItWorksTitle";
            lblHowItWorksTitle.Size = new Size(350, 40);
            lblHowItWorksTitle.TabIndex = 0;
            lblHowItWorksTitle.Text = "⚙  HOW IT WORKS";
            lblHowItWorksTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stepLine1
            // 
            stepLine1.BackColor = Color.FromArgb(190, 225, 190);
            stepLine1.Location = new Point(105, 70);
            stepLine1.Name = "stepLine1";
            stepLine1.Size = new Size(130, 3);
            stepLine1.TabIndex = 1;
            // 
            // stepLine2
            // 
            stepLine2.BackColor = Color.FromArgb(190, 225, 190);
            stepLine2.Location = new Point(295, 70);
            stepLine2.Name = "stepLine2";
            stepLine2.Size = new Size(130, 3);
            stepLine2.TabIndex = 2;
            // 
            // stepLine3
            // 
            stepLine3.BackColor = Color.FromArgb(190, 225, 190);
            stepLine3.Location = new Point(485, 70);
            stepLine3.Name = "stepLine3";
            stepLine3.Size = new Size(130, 3);
            stepLine3.TabIndex = 3;
            // 
            // lblStep1Number
            // 
            lblStep1Number.BackColor = Color.FromArgb(30, 155, 70);
            lblStep1Number.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStep1Number.ForeColor = Color.White;
            lblStep1Number.Location = new Point(50, 58);
            lblStep1Number.Name = "lblStep1Number";
            lblStep1Number.Size = new Size(22, 22);
            lblStep1Number.TabIndex = 4;
            lblStep1Number.Text = "1";
            lblStep1Number.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep2Number
            // 
            lblStep2Number.BackColor = Color.FromArgb(30, 155, 70);
            lblStep2Number.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStep2Number.ForeColor = Color.White;
            lblStep2Number.Location = new Point(240, 58);
            lblStep2Number.Name = "lblStep2Number";
            lblStep2Number.Size = new Size(22, 22);
            lblStep2Number.TabIndex = 5;
            lblStep2Number.Text = "2";
            lblStep2Number.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep3Number
            // 
            lblStep3Number.BackColor = Color.FromArgb(30, 155, 70);
            lblStep3Number.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStep3Number.ForeColor = Color.White;
            lblStep3Number.Location = new Point(430, 58);
            lblStep3Number.Name = "lblStep3Number";
            lblStep3Number.Size = new Size(22, 22);
            lblStep3Number.TabIndex = 6;
            lblStep3Number.Text = "3";
            lblStep3Number.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep4Number
            // 
            lblStep4Number.BackColor = Color.FromArgb(30, 155, 70);
            lblStep4Number.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStep4Number.ForeColor = Color.White;
            lblStep4Number.Location = new Point(620, 58);
            lblStep4Number.Name = "lblStep4Number";
            lblStep4Number.Size = new Size(22, 22);
            lblStep4Number.TabIndex = 7;
            lblStep4Number.Text = "4";
            lblStep4Number.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // step1Icon
            // 
            step1Icon.BackColor = Color.FromArgb(220, 239, 220);
            step1Icon.BorderStyle = BorderStyle.None;
            step1Icon.Controls.Add(step1Glyph);
            step1Icon.Location = new Point(40, 100);
            step1Icon.Name = "step1Icon";
            step1Icon.Size = new Size(70, 65);
            step1Icon.TabIndex = 8;
            // 
            // step1Glyph
            // 
            step1Glyph.Dock = DockStyle.Fill;
            step1Glyph.Enabled = false;
            step1Glyph.Font = new Font("Segoe UI Symbol", 23F, FontStyle.Bold);
            step1Glyph.ForeColor = Color.FromArgb(20, 100, 55);
            step1Glyph.Location = new Point(0, 0);
            step1Glyph.Name = "step1Glyph";
            step1Glyph.Size = new Size(68, 63);
            step1Glyph.TabIndex = 0;
            step1Glyph.Text = "#";
            step1Glyph.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // step2Icon
            // 
            step2Icon.BackColor = Color.FromArgb(220, 239, 220);
            step2Icon.BorderStyle = BorderStyle.None;
            step2Icon.Controls.Add(step2Glyph);
            step2Icon.Location = new Point(230, 100);
            step2Icon.Name = "step2Icon";
            step2Icon.Size = new Size(70, 65);
            step2Icon.TabIndex = 9;
            // 
            // step2Glyph
            // 
            step2Glyph.Dock = DockStyle.Fill;
            step2Glyph.Enabled = false;
            step2Glyph.Font = new Font("Segoe UI Symbol", 23F, FontStyle.Bold);
            step2Glyph.ForeColor = Color.FromArgb(20, 100, 55);
            step2Glyph.Location = new Point(0, 0);
            step2Glyph.Name = "step2Glyph";
            step2Glyph.Size = new Size(68, 63);
            step2Glyph.TabIndex = 0;
            step2Glyph.Text = "▰";
            step2Glyph.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // step3Icon
            // 
            step3Icon.BackColor = Color.FromArgb(220, 239, 220);
            step3Icon.BorderStyle = BorderStyle.None;
            step3Icon.Controls.Add(step3Glyph);
            step3Icon.Location = new Point(420, 100);
            step3Icon.Name = "step3Icon";
            step3Icon.Size = new Size(70, 65);
            step3Icon.TabIndex = 10;
            // 
            // step3Glyph
            // 
            step3Glyph.Dock = DockStyle.Fill;
            step3Glyph.Enabled = false;
            step3Glyph.Font = new Font("Segoe UI Symbol", 23F, FontStyle.Bold);
            step3Glyph.ForeColor = Color.FromArgb(20, 100, 55);
            step3Glyph.Location = new Point(0, 0);
            step3Glyph.Name = "step3Glyph";
            step3Glyph.Size = new Size(68, 63);
            step3Glyph.TabIndex = 0;
            step3Glyph.Text = "♟";
            step3Glyph.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // step4Icon
            // 
            step4Icon.BackColor = Color.FromArgb(220, 239, 220);
            step4Icon.BorderStyle = BorderStyle.None;
            step4Icon.Controls.Add(step4Glyph);
            step4Icon.Location = new Point(610, 100);
            step4Icon.Name = "step4Icon";
            step4Icon.Size = new Size(70, 65);
            step4Icon.TabIndex = 11;
            // 
            // step4Glyph
            // 
            step4Glyph.Dock = DockStyle.Fill;
            step4Glyph.Enabled = false;
            step4Glyph.Font = new Font("Segoe UI Symbol", 23F, FontStyle.Bold);
            step4Glyph.ForeColor = Color.FromArgb(20, 100, 55);
            step4Glyph.Location = new Point(0, 0);
            step4Glyph.Name = "step4Glyph";
            step4Glyph.Size = new Size(68, 63);
            step4Glyph.TabIndex = 0;
            step4Glyph.Text = "✓";
            step4Glyph.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep1Title
            // 
            lblStep1Title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStep1Title.ForeColor = Color.FromArgb(10, 70, 45);
            lblStep1Title.Location = new Point(15, 175);
            lblStep1Title.Name = "lblStep1Title";
            lblStep1Title.Size = new Size(120, 30);
            lblStep1Title.TabIndex = 12;
            lblStep1Title.Text = "CHOOSE";
            lblStep1Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep2Title
            // 
            lblStep2Title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStep2Title.ForeColor = Color.FromArgb(10, 70, 45);
            lblStep2Title.Location = new Point(205, 175);
            lblStep2Title.Name = "lblStep2Title";
            lblStep2Title.Size = new Size(120, 30);
            lblStep2Title.TabIndex = 13;
            lblStep2Title.Text = "GET QUEUE";
            lblStep2Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep3Title
            // 
            lblStep3Title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStep3Title.ForeColor = Color.FromArgb(10, 70, 45);
            lblStep3Title.Location = new Point(395, 175);
            lblStep3Title.Name = "lblStep3Title";
            lblStep3Title.Size = new Size(120, 30);
            lblStep3Title.TabIndex = 14;
            lblStep3Title.Text = "WAIT";
            lblStep3Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep4Title
            // 
            lblStep4Title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStep4Title.ForeColor = Color.FromArgb(10, 70, 45);
            lblStep4Title.Location = new Point(585, 175);
            lblStep4Title.Name = "lblStep4Title";
            lblStep4Title.Size = new Size(120, 30);
            lblStep4Title.TabIndex = 15;
            lblStep4Title.Text = "PROCEED";
            lblStep4Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStep1Description
            // 
            lblStep1Description.Font = new Font("Segoe UI", 8F);
            lblStep1Description.ForeColor = Color.FromArgb(55, 90, 70);
            lblStep1Description.Location = new Point(10, 205);
            lblStep1Description.Name = "lblStep1Description";
            lblStep1Description.Size = new Size(130, 65);
            lblStep1Description.TabIndex = 16;
            lblStep1Description.Text = "Select the\r\nservice you need";
            lblStep1Description.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblStep2Description
            // 
            lblStep2Description.Font = new Font("Segoe UI", 8F);
            lblStep2Description.ForeColor = Color.FromArgb(55, 90, 70);
            lblStep2Description.Location = new Point(200, 205);
            lblStep2Description.Name = "lblStep2Description";
            lblStep2Description.Size = new Size(130, 65);
            lblStep2Description.TabIndex = 17;
            lblStep2Description.Text = "Get your queue\r\nnumber";
            lblStep2Description.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblStep3Description
            // 
            lblStep3Description.Font = new Font("Segoe UI", 8F);
            lblStep3Description.ForeColor = Color.FromArgb(55, 90, 70);
            lblStep3Description.Location = new Point(390, 205);
            lblStep3Description.Name = "lblStep3Description";
            lblStep3Description.Size = new Size(130, 65);
            lblStep3Description.TabIndex = 18;
            lblStep3Description.Text = "Wait for your\r\nnumber to be called";
            lblStep3Description.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblStep4Description
            // 
            lblStep4Description.Font = new Font("Segoe UI", 8F);
            lblStep4Description.ForeColor = Color.FromArgb(55, 90, 70);
            lblStep4Description.Location = new Point(580, 205);
            lblStep4Description.Name = "lblStep4Description";
            lblStep4Description.Size = new Size(130, 65);
            lblStep4Description.TabIndex = 19;
            lblStep4Description.Text = "Proceed to the\r\nassigned window";
            lblStep4Description.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlAnnouncements
            // 
            pnlAnnouncements.BackColor = Color.FromArgb(243, 250, 242);
            pnlAnnouncements.Controls.Add(lblAnnouncementsTitle);
            pnlAnnouncements.Controls.Add(pnlAnnouncementArea);
            pnlAnnouncements.Location = new Point(1400, 614);
            pnlAnnouncements.Name = "pnlAnnouncements";
            pnlAnnouncements.Size = new Size(440, 340);
            ApplyRounded(pnlAnnouncements, 28);
            pnlAnnouncements.Resize += RoundedControl_Resize;
            pnlAnnouncements.TabIndex = 9;
            // 
            // lblAnnouncementsTitle
            // 
            lblAnnouncementsTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAnnouncementsTitle.ForeColor = Color.FromArgb(10, 70, 45);
            lblAnnouncementsTitle.Location = new Point(25, 18);
            lblAnnouncementsTitle.Name = "lblAnnouncementsTitle";
            lblAnnouncementsTitle.Size = new Size(380, 40);
            lblAnnouncementsTitle.TabIndex = 0;
            lblAnnouncementsTitle.Text = "🔊  ANNOUNCEMENTS";
            lblAnnouncementsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAnnouncementArea
            // 
            pnlAnnouncementArea.BackColor = Color.FromArgb(210, 239, 205);
            pnlAnnouncementArea.Location = new Point(25, 70);
            pnlAnnouncementArea.Name = "pnlAnnouncementArea";
            pnlAnnouncementArea.Size = new Size(390, 245);
            ApplyRounded(pnlAnnouncementArea, 18);
            pnlAnnouncementArea.Resize += RoundedControl_Resize;
            pnlAnnouncementArea.TabIndex = 1;
            // 
            // btn_registrar
            // 
            btn_registrar.BackColor = Color.White;
            btn_registrar.Controls.Add(registrarIconCircle);
            btn_registrar.Controls.Add(registrarButtonTitle);
            btn_registrar.Controls.Add(registrarButtonDescription);
            btn_registrar.Controls.Add(registrarButtonArrow);
            btn_registrar.Cursor = Cursors.Hand;
            btn_registrar.Location = new Point(35, 500);
            btn_registrar.Name = "btn_registrar";
            btn_registrar.Size = new Size(500, 112);
            ApplyRounded(btn_registrar, 22);
            btn_registrar.Resize += RoundedControl_Resize;
            btn_registrar.TabIndex = 3;
            btn_registrar.TabStop = false;
            btn_registrar.Click += btn_registrar_Click_1;
            // 
            // registrarIconCircle
            // 
            registrarIconCircle.BackColor = Color.FromArgb(239, 247, 238);
            registrarIconCircle.Controls.Add(registrarIconText);
            registrarIconCircle.Location = new Point(18, 18);
            registrarIconCircle.Name = "registrarIconCircle";
            registrarIconCircle.Size = new Size(76, 76);
            ApplyRounded(registrarIconCircle, 16);
            registrarIconCircle.Resize += RoundedControl_Resize;
            registrarIconCircle.TabIndex = 0;
            registrarIconCircle.Click += btn_registrar_Click_1;
            // 
            // registrarIconText
            // 
            registrarIconText.BackColor = Color.Transparent;
            registrarIconText.Dock = DockStyle.Fill;
            registrarIconText.Font = new Font("Segoe UI Symbol", 25F, FontStyle.Bold);
            registrarIconText.ForeColor = Color.FromArgb(10, 85, 52);
            registrarIconText.Location = new Point(0, 0);
            registrarIconText.Name = "registrarIconText";
            registrarIconText.Size = new Size(76, 76);
            registrarIconText.TabIndex = 0;
            registrarIconText.Text = "♟";
            registrarIconText.TextAlign = ContentAlignment.MiddleCenter;
            registrarIconText.Click += btn_registrar_Click_1;
            // 
            // registrarButtonTitle
            // 
            registrarButtonTitle.BackColor = Color.Transparent;
            registrarButtonTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            registrarButtonTitle.ForeColor = Color.FromArgb(10, 70, 45);
            registrarButtonTitle.Location = new Point(118, 23);
            registrarButtonTitle.Name = "registrarButtonTitle";
            registrarButtonTitle.Size = new Size(320, 34);
            registrarButtonTitle.TabIndex = 1;
            registrarButtonTitle.Text = "REGISTRAR";
            registrarButtonTitle.TextAlign = ContentAlignment.MiddleLeft;
            registrarButtonTitle.Click += btn_registrar_Click_1;
            // 
            // registrarButtonDescription
            // 
            registrarButtonDescription.BackColor = Color.Transparent;
            registrarButtonDescription.Font = new Font("Segoe UI", 9F);
            registrarButtonDescription.ForeColor = Color.FromArgb(45, 90, 70);
            registrarButtonDescription.Location = new Point(118, 58);
            registrarButtonDescription.Name = "registrarButtonDescription";
            registrarButtonDescription.Size = new Size(320, 26);
            registrarButtonDescription.TabIndex = 2;
            registrarButtonDescription.Text = "Records • Enrollment • Documents";
            registrarButtonDescription.TextAlign = ContentAlignment.MiddleLeft;
            registrarButtonDescription.Click += btn_registrar_Click_1;
            // 
            // registrarButtonArrow
            // 
            registrarButtonArrow.BackColor = Color.Transparent;
            registrarButtonArrow.Font = new Font("Segoe UI", 26F);
            registrarButtonArrow.ForeColor = Color.FromArgb(10, 70, 45);
            registrarButtonArrow.Location = new Point(450, 32);
            registrarButtonArrow.Name = "registrarButtonArrow";
            registrarButtonArrow.Size = new Size(30, 48);
            registrarButtonArrow.TabIndex = 3;
            registrarButtonArrow.Text = "›";
            registrarButtonArrow.TextAlign = ContentAlignment.MiddleCenter;
            registrarButtonArrow.Click += btn_registrar_Click_1;
            // 
            // btn_cashier
            // 
            btn_cashier.BackColor = Color.White;
            btn_cashier.Controls.Add(cashierIconCircle);
            btn_cashier.Controls.Add(cashierButtonTitle);
            btn_cashier.Controls.Add(cashierButtonDescription);
            btn_cashier.Controls.Add(cashierButtonArrow);
            btn_cashier.Cursor = Cursors.Hand;
            btn_cashier.Location = new Point(35, 632);
            btn_cashier.Name = "btn_cashier";
            btn_cashier.Size = new Size(500, 112);
            ApplyRounded(btn_cashier, 22);
            btn_cashier.Resize += RoundedControl_Resize;
            btn_cashier.TabIndex = 4;
            btn_cashier.TabStop = false;
            btn_cashier.Click += btn_cashier_Click;
            // 
            // cashierIconCircle
            // 
            cashierIconCircle.BackColor = Color.FromArgb(239, 247, 238);
            cashierIconCircle.Controls.Add(cashierIconText);
            cashierIconCircle.Location = new Point(18, 18);
            cashierIconCircle.Name = "cashierIconCircle";
            cashierIconCircle.Size = new Size(76, 76);
            ApplyRounded(cashierIconCircle, 16);
            cashierIconCircle.Resize += RoundedControl_Resize;
            cashierIconCircle.TabIndex = 0;
            cashierIconCircle.Click += btn_cashier_Click;
            // 
            // cashierIconText
            // 
            cashierIconText.BackColor = Color.Transparent;
            cashierIconText.Dock = DockStyle.Fill;
            cashierIconText.Font = new Font("Segoe UI Symbol", 25F, FontStyle.Bold);
            cashierIconText.ForeColor = Color.FromArgb(10, 85, 52);
            cashierIconText.Location = new Point(0, 0);
            cashierIconText.Name = "cashierIconText";
            cashierIconText.Size = new Size(76, 76);
            cashierIconText.TabIndex = 0;
            cashierIconText.Text = "$";
            cashierIconText.TextAlign = ContentAlignment.MiddleCenter;
            cashierIconText.Click += btn_cashier_Click;
            // 
            // cashierButtonTitle
            // 
            cashierButtonTitle.BackColor = Color.Transparent;
            cashierButtonTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            cashierButtonTitle.ForeColor = Color.FromArgb(10, 70, 45);
            cashierButtonTitle.Location = new Point(118, 23);
            cashierButtonTitle.Name = "cashierButtonTitle";
            cashierButtonTitle.Size = new Size(320, 34);
            cashierButtonTitle.TabIndex = 1;
            cashierButtonTitle.Text = "CASHIER";
            cashierButtonTitle.TextAlign = ContentAlignment.MiddleLeft;
            cashierButtonTitle.Click += btn_cashier_Click;
            // 
            // cashierButtonDescription
            // 
            cashierButtonDescription.BackColor = Color.Transparent;
            cashierButtonDescription.Font = new Font("Segoe UI", 9F);
            cashierButtonDescription.ForeColor = Color.FromArgb(45, 90, 70);
            cashierButtonDescription.Location = new Point(118, 58);
            cashierButtonDescription.Name = "cashierButtonDescription";
            cashierButtonDescription.Size = new Size(320, 26);
            cashierButtonDescription.TabIndex = 2;
            cashierButtonDescription.Text = "Payments • Inquiries • Receipts";
            cashierButtonDescription.TextAlign = ContentAlignment.MiddleLeft;
            cashierButtonDescription.Click += btn_cashier_Click;
            // 
            // cashierButtonArrow
            // 
            cashierButtonArrow.BackColor = Color.Transparent;
            cashierButtonArrow.Font = new Font("Segoe UI", 26F);
            cashierButtonArrow.ForeColor = Color.FromArgb(10, 70, 45);
            cashierButtonArrow.Location = new Point(450, 32);
            cashierButtonArrow.Name = "cashierButtonArrow";
            cashierButtonArrow.Size = new Size(30, 48);
            cashierButtonArrow.TabIndex = 3;
            cashierButtonArrow.Text = "›";
            cashierButtonArrow.TextAlign = ContentAlignment.MiddleCenter;
            cashierButtonArrow.Click += btn_cashier_Click;
            // 
            // btn_admission
            // 
            btn_admission.BackColor = Color.White;
            btn_admission.Controls.Add(admissionIconCircle);
            btn_admission.Controls.Add(admissionButtonTitle);
            btn_admission.Controls.Add(admissionButtonDescription);
            btn_admission.Controls.Add(admissionButtonArrow);
            btn_admission.Cursor = Cursors.Hand;
            btn_admission.Location = new Point(35, 764);
            btn_admission.Name = "btn_admission";
            btn_admission.Size = new Size(500, 112);
            ApplyRounded(btn_admission, 22);
            btn_admission.Resize += RoundedControl_Resize;
            btn_admission.TabIndex = 5;
            btn_admission.TabStop = false;
            btn_admission.Click += btn_admission_Click_1;
            // 
            // admissionIconCircle
            // 
            admissionIconCircle.BackColor = Color.FromArgb(239, 247, 238);
            admissionIconCircle.Controls.Add(admissionIconText);
            admissionIconCircle.Location = new Point(18, 18);
            admissionIconCircle.Name = "admissionIconCircle";
            admissionIconCircle.Size = new Size(76, 76);
            ApplyRounded(admissionIconCircle, 16);
            admissionIconCircle.Resize += RoundedControl_Resize;
            admissionIconCircle.TabIndex = 0;
            admissionIconCircle.Click += btn_admission_Click_1;
            // 
            // admissionIconText
            // 
            admissionIconText.BackColor = Color.Transparent;
            admissionIconText.Dock = DockStyle.Fill;
            admissionIconText.Font = new Font("Segoe UI Symbol", 25F, FontStyle.Bold);
            admissionIconText.ForeColor = Color.FromArgb(10, 85, 52);
            admissionIconText.Location = new Point(0, 0);
            admissionIconText.Name = "admissionIconText";
            admissionIconText.Size = new Size(76, 76);
            admissionIconText.TabIndex = 0;
            admissionIconText.Text = "🎓";
            admissionIconText.TextAlign = ContentAlignment.MiddleCenter;
            admissionIconText.Click += btn_admission_Click_1;
            // 
            // admissionButtonTitle
            // 
            admissionButtonTitle.BackColor = Color.Transparent;
            admissionButtonTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            admissionButtonTitle.ForeColor = Color.FromArgb(10, 70, 45);
            admissionButtonTitle.Location = new Point(118, 23);
            admissionButtonTitle.Name = "admissionButtonTitle";
            admissionButtonTitle.Size = new Size(320, 34);
            admissionButtonTitle.TabIndex = 1;
            admissionButtonTitle.Text = "ADMISSION";
            admissionButtonTitle.TextAlign = ContentAlignment.MiddleLeft;
            admissionButtonTitle.Click += btn_admission_Click_1;
            // 
            // admissionButtonDescription
            // 
            admissionButtonDescription.BackColor = Color.Transparent;
            admissionButtonDescription.Font = new Font("Segoe UI", 9F);
            admissionButtonDescription.ForeColor = Color.FromArgb(45, 90, 70);
            admissionButtonDescription.Location = new Point(118, 58);
            admissionButtonDescription.Name = "admissionButtonDescription";
            admissionButtonDescription.Size = new Size(320, 26);
            admissionButtonDescription.TabIndex = 2;
            admissionButtonDescription.Text = "Application • Requirements • Inquiries";
            admissionButtonDescription.TextAlign = ContentAlignment.MiddleLeft;
            admissionButtonDescription.Click += btn_admission_Click_1;
            // 
            // admissionButtonArrow
            // 
            admissionButtonArrow.BackColor = Color.Transparent;
            admissionButtonArrow.Font = new Font("Segoe UI", 26F);
            admissionButtonArrow.ForeColor = Color.FromArgb(10, 70, 45);
            admissionButtonArrow.Location = new Point(450, 32);
            admissionButtonArrow.Name = "admissionButtonArrow";
            admissionButtonArrow.Size = new Size(30, 48);
            admissionButtonArrow.TabIndex = 3;
            admissionButtonArrow.Text = "›";
            admissionButtonArrow.TextAlign = ContentAlignment.MiddleCenter;
            admissionButtonArrow.Click += btn_admission_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.Main__1_;
            ClientSize = new Size(1920, 1080);
            Controls.Add(lblWelcome);
            Controls.Add(lblChooseService);
            Controls.Add(lblMotto);
            Controls.Add(btn_registrar);
            Controls.Add(btn_cashier);
            Controls.Add(btn_admission);
            Controls.Add(pnlNowServing);
            Controls.Add(pnlEstimatedWait);
            Controls.Add(pnlHowItWorks);
            Controls.Add(pnlAnnouncements);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CampusQ";
            Load += Form1_Load;
            pnlNowServing.ResumeLayout(false);
            cardRegistrarNow.ResumeLayout(false);
            iconRegistrarNow.ResumeLayout(false);
            cardCashierNow.ResumeLayout(false);
            iconCashierNow.ResumeLayout(false);
            cardAdmissionNow.ResumeLayout(false);
            iconAdmissionNow.ResumeLayout(false);
            pnlEstimatedWait.ResumeLayout(false);
            cardRegistrarWait.ResumeLayout(false);
            iconRegistrarWait.ResumeLayout(false);
            cardCashierWait.ResumeLayout(false);
            iconCashierWait.ResumeLayout(false);
            cardAdmissionWait.ResumeLayout(false);
            iconAdmissionWait.ResumeLayout(false);
            pnlHowItWorks.ResumeLayout(false);
            step1Icon.ResumeLayout(false);
            step2Icon.ResumeLayout(false);
            step3Icon.ResumeLayout(false);
            step4Icon.ResumeLayout(false);
            pnlAnnouncements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_registrar).EndInit();
            btn_registrar.ResumeLayout(false);
            registrarIconCircle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_cashier).EndInit();
            btn_cashier.ResumeLayout(false);
            cashierIconCircle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_admission).EndInit();
            btn_admission.ResumeLayout(false);
            admissionIconCircle.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label step1Glyph;
        private Label step2Glyph;
        private Label step3Glyph;
        private Label step4Glyph;
    }



}
