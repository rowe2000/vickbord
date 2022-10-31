using System;
using System.Windows.Forms;
using TicLib;

namespace TicApp
{
    public partial class MainForm : Form
    {
        private readonly Tic tic;

        public MainForm()
        {
            InitializeComponent();
            tic = new Tic();
            gotoButton.Enabled = tic.IsConnected;
            homeButton.Enabled = tic.IsConnected;
            jogLeftCheckBox.Enabled = tic.IsConnected;
            jogRigthCheckBox.Enabled = tic.IsConnected;
            energizeButton.Enabled = tic.IsConnected;

            timer1.Tick += (o, a) =>
            {
                tic.Process();
                OnTick();
            };
        }
        
        private void OnConnectClick(object sender, EventArgs e)
        {
            try
            {
                if (tic.IsConnected)
                {
                    tic.Deenergize();
                    tic.Close();
                    connectButton.Text = "Connect";
                    connectionLabel.Text = "No";
                }
                else
                {
                    tic.Open();
                    tic.Reinitialize();
                    tic.Energize();
                    tic.ClearDriverError();

                    tic.SetMaxAccel(100000);
                    tic.SetMaxDecel(100000);
                    tic.SetMaxSpeed(50000000);
                    tic.SetStartingSpeed(2000000);
                    tic.ExitSafeStart();
                    tic.WaitForDeviceReady();
                    connectButton.Text = "Disconnect";
                    connectionLabel.Text = "Yes";
                }

                gotoButton.Enabled = tic.IsConnected;
                homeButton.Enabled = tic.IsConnected;
                jogLeftCheckBox.Enabled = tic.IsConnected;
                jogRigthCheckBox.Enabled = tic.IsConnected;
                energizeButton.Enabled = tic.IsConnected;
            }
            catch (Exception ex)
            {
                tic.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void OnTick()
        {
            if (tic is null)
                return;


            statusLabel.Text = tic.StatusVars?.ToString();
            varsLabel.Text = tic.Vars?.ToString();

            if (!tic.IsMoving)
            {
                gotoButton.Text = "Goto";
                homeButton.Enabled = !tic.IsMoving;
                jogLeftCheckBox.Enabled = !tic.IsMoving;
                jogRigthCheckBox.Enabled = !tic.IsMoving;
            }

            if (!tic.IsHoming)
            {
                homeButton.Text = "Home";
                gotoButton.Enabled = !tic.IsHoming;
                jogLeftCheckBox.Enabled = !tic.IsHoming;
                jogRigthCheckBox.Enabled = !tic.IsHoming;
            }

            if (!tic.IsDecelerating)
            {
                gotoButton.Enabled = true;
                homeButton.Enabled = true;
            }
        }

        private void OnHome_Click(object sender, EventArgs e)
        {
            if (tic.IsHoming == false)
            {
                tic.GoHome(GoHome.Reverse);
                homeButton.Text = "Stop";
            }
            else
            {
                tic.HaltAndHold();
                homeButton.Text = "Home";
            }

            gotoButton.Enabled = !tic.IsHoming;
            jogLeftCheckBox.Enabled = !tic.IsHoming;
            jogRigthCheckBox.Enabled = !tic.IsHoming;
        }


        private void OnGoto_Click(object sender, EventArgs e)
        {
            if (tic.IsMoving == false)
            {
                var speed = (int)speedNumericUpDown.Value;
                var position = (int)positionNumericUpDown.Value;

                tic.SetMaxSpeed(speed);
                tic.SetTargetPosition(position);

                gotoButton.Text = "Stop";
            }
            else
            {
                tic.HaltAndHold();
                gotoButton.Text = "Goto";
            }

            homeButton.Enabled = !tic.IsMoving;
            jogLeftCheckBox.Enabled = !tic.IsMoving;
            jogRigthCheckBox.Enabled = !tic.IsMoving;
        }

        private void OnJogLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (jogLeftCheckBox.CheckState == CheckState.Checked)
            {
                tic.SetMaxSpeed((int)jogSpeedNumericUpDown.Value);
                tic.SetTargetPosition((int)positionNumericUpDown.Minimum);

                gotoButton.Enabled = false;
                homeButton.Enabled = false;
            }
            else
            {
                tic.SetTargetVelocity(0);
            }
        }

        private void OnJogRight_CheckedChanged(object sender, EventArgs e)
        {
            if (jogRigthCheckBox.CheckState == CheckState.Checked)
            {
                tic.SetMaxSpeed((int)jogSpeedNumericUpDown.Value);
                tic.SetTargetPosition((int)positionNumericUpDown.Maximum);
                gotoButton.Enabled = false;
                homeButton.Enabled = false;
            }
            else
            {
                tic.SetTargetVelocity(0);
            }
        }

        private void OnEnergize_ButtonClick(object sender, EventArgs e)
        {
            if (tic.StatusVars.Energized)
            {
                tic.Deenergize();
                energizeButton.Text = "Energize";
            }
            else
            {
                tic.ClearDriverError();
                tic.Energize();
                tic.ExitSafeStart();
                energizeButton.Text = "Deenergize";
            }
        }

        private void OnResetPositionButton_Click(object sender, EventArgs e)
        {
            tic.HaltAndSetPosition(0);
        }
    }
}