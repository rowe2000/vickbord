using System;
using System.Linq;
using System.Text;
using System.Threading;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Timer = System.Timers.Timer;

// Copyright 2019 Jose Ignacio Garcia de Cortazar

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

// Class for the Pololu Tic stepper drivers.


namespace TicLib
{
    public class Tic
    {
        #region CONSTANTS

        private const int TicProductT825 = 1;
        private const int TicProductT834 = 2;
        private const int TicProductT500 = 3;
        private const int TicProductN825 = 4;
        private const int TicProductT249 = 5;
        private const int TicProduct36V4 = 6;
        private const int UsbRequestGetDescriptor = 6;
        private const int UsbDescriptorTypeString = 3;
        private const int TicVendorId = 8187;
        private const int TicFirmwareModificationStringIndex = 4;

        private const int TicResponseDeenergize = 0;
        private const int TicResponseHaltAndHold = 1;
        private const int TicResponseDecelToHold = 2;
        private const int TicResponseGoToPosition = 3;
        private const int TicPinNumScl = 0;
        private const int TicPinNumSda = 1;
        private const int TicPinNumTx = 2;
        private const int TicPinNumRx = 3;
        private const int TicPinNumRc = 4;
        private const int TicPlanningModeOff = 0;
        private const int TicPlanningModeTargetPosition = 1;
        private const int TicPlanningModeTargetVelocity = 2;
        private const int TicResetPowerUp = 0;
        private const int TicResetBrownout = 1;
        private const int TicResetResetLine = 2;
        private const int TicResetWatchdog = 4;
        private const int TicResetSoftware = 8;
        private const int TicResetStackOverflow = 16;
        private const int TicResetStackUnderflow = 32;
        private const int TicPinStateHighImpedance = 0;
        private const int TicPinStatePulledUp = 1;
        private const int TicPinStateOutputLow = 2;
        private const int TicPinStateOutputHigh = 3;
        private const int TicMinAllowedBaudRate = 200;
        private const int TicMaxAllowedBaudRate = 115385;
        private const int TicDefaultCommandTimeout = 1000;
        private const int TicMaxAllowedCommandTimeout = 60000;
        private const int TicMaxAllowedCurrent = 3968;
        private const int TicMaxAllowedCurrentT825 = 3968;
        private const int TicMaxAllowedCurrentT834 = 3456;
        private const int TicMaxAllowedCurrentT500 = 3093;
        private const int TicMaxAllowedCurrentT249 = 4480;
        private const int TicMaxAllowedCurrentCodeT500 = 32;
        private const int TicCurrentLimitUnitsMa = 32;
        private const int TicCurrentLimitUnitsMaT249 = 40;
        private const int TicMinAllowedAccel = 100;
        private const long TicMaxAllowedAccel = 2147483647L;
        private const int TicMaxAllowedSpeed = 500000000;
        private const long TicMaxAllowedEncoderPrescaler = 2147483647L;
        private const long TicMaxAllowedEncoderPostscaler = 2147483647L;
        private const int TicSpeedUnitsPerHz = 10000;
        private const int TicAccelUnitsPerHz2 = 100;
        private const int TicControlModeSerial = 0;
        private const int TicControlModeStepDir = 1;
        private const int TicControlModeRcPosition = 2;
        private const int TicControlModeRcSpeed = 3;
        private const int TicControlModeAnalogPosition = 4;
        private const int TicControlModeAnalogSpeed = 5;
        private const int TicControlModeEncoderPosition = 6;
        private const int TicControlModeEncoderSpeed = 7;
        private const int TicScalingDegreeLinear = 0;
        private const int TicScalingDegreeQuadratic = 1;
        private const int TicScalingDegreeCubic = 2;
        private const int TicStepModeFull = 0;
        private const int TicStepModeHalf = 1;
        private const int TicStepModeMicrostep1 = 0;
        private const int TicStepModeMicrostep2 = 1;
        private const int TicStepModeMicrostep4 = 2;
        private const int TicStepModeMicrostep8 = 3;
        private const int TicStepModeMicrostep16 = 4;
        private const int TicStepModeMicrostep32 = 5;
        private const int TicStepModeMicrostep2100P = 6;
        private const int TicDecayModeMixed = 0;
        private const int TicDecayModeSlow = 1;
        private const int TicDecayModeFast = 2;
        private const int TicDecayModeMode3 = 3;
        private const int TicDecayModeMode4 = 4;
        private const int TicDecayModeT825Mixed = 0;
        private const int TicDecayModeT825Slow = 1;
        private const int TicDecayModeT825Fast = 2;
        private const int TicDecayModeT834Mixed50 = 0;
        private const int TicDecayModeT834Slow = 1;
        private const int TicDecayModeT834Fast = 2;
        private const int TicDecayModeT834Mixed25 = 3;
        private const int TicDecayModeT834Mixed75 = 4;
        private const int TicDecayModeT500Auto = 0;
        private const int TicDecayModeT249Mixed = 0;
        private const int TicAgcModeOff = 0;
        private const int TicAgcModeOn = 1;
        private const int TicAgcModeActiveOff = 2;
        private const int TicAgcBottomCurrentLimit45 = 0;
        private const int TicAgcBottomCurrentLimit50 = 1;
        private const int TicAgcBottomCurrentLimit55 = 2;
        private const int TicAgcBottomCurrentLimit60 = 3;
        private const int TicAgcBottomCurrentLimit65 = 4;
        private const int TicAgcBottomCurrentLimit70 = 5;
        private const int TicAgcBottomCurrentLimit75 = 6;
        private const int TicAgcBottomCurrentLimit80 = 7;
        private const int TicAgcCurrentBoostSteps5 = 0;
        private const int TicAgcCurrentBoostSteps7 = 1;
        private const int TicAgcCurrentBoostSteps9 = 2;
        private const int TicAgcCurrentBoostSteps11 = 3;
        private const int TicAgcFrequencyLimitOff = 0;
        private const int TicAgcFrequencyLimit225 = 1;
        private const int TicAgcFrequencyLimit450 = 2;
        private const int TicAgcFrequencyLimit675 = 3;
        private const int TicAgcOptionMode = 0;
        private const int TicAgcOptionBottomCurrentLimit = 1;
        private const int TicAgcOptionCurrentBoostSteps = 2;
        private const int TicAgcOptionFrequencyLimit = 3;
        private const int TicMotorDriverErrorNone = 0;
        private const int TicMotorDriverErrorOverCurrent = 1;
        private const int TicMotorDriverErrorOverTemperature = 2;
        private const int TicPinPullup = 7;
        private const int TicPinAnalog = 6;
        private const int TicPinFuncPosn = 0;
        private const int TicPinFuncMask = 15;
        private const int TicPinFuncDefault = 0;
        private const int TicPinFuncUserIo = 1;
        private const int TicPinFuncUserInput = 2;
        private const int TicPinFuncPotPower = 3;
        private const int TicPinFuncSerial = 4;
        private const int TicPinFuncRc = 5;
        private const int TicPinFuncEncoder = 6;
        private const int TicPinFuncLimitSwitchForward = 8;
        private const int TicPinFuncLimitSwitchReverse = 9;
        private const int TicPinFuncKillSwitch = 7;
        private const int TicCmdSetTargetPosition = 224;
        private const int TicCmdSetTargetVelocity = 227;
        private const int TicCmdHaltAndSetPosition = 236;
        private const int TicCmdHaltAndHold = 137;
        private const int TicCmdGoHome = 0x97;
        private const int TicCmdResetCommandTimeout = 140;
        private const int TicCmdDeenergize = 134;
        private const int TicCmdEnergize = 133;
        private const int TicCmdExitSafeStart = 131;
        private const int TicCmdEnterSafeStart = 143;
        private const int TicCmdReset = 176;
        private const int TicCmdClearDriverError = 138;
        private const int TicCmdSetMaxSpeed = 230;
        private const int TicCmdSetStartingSpeed = 229;
        private const int TicCmdSetMaxAccel = 234;
        private const int TicCmdSetMaxDecel = 233;
        private const int TicCmdSetStepMode = 148;
        private const int TicCmdSetCurrentLimit = 145;
        private const int TicCmdSetDecayMode = 146;
        private const int TicCmdSetAgcOption = 0x98;
        private const int TicCmdGetVariable = 161;
        private const int TicCmdGetVariableAndClearErrorsOccurred = 162;
        private const int TicCmdGetSetting = 168;
        private const int TicCmdSetSetting = 19;
        private const int TicCmdReinitialize = 16;
        private const int TicCmdStartBootloader = 255;
        private const int TicCmdGetDebugData = 32;
        private const int TicVarOperationState = 0;
        private const int TicVarMiscFlags1 = 1;
        private const int TicVarErrorStatus = 2;
        private const int TicVarErrorsOccurred = 4;
        private const int TicVarPlanningMode = 9;
        private const int TicVarTargetPosition = 10;
        private const int TicVarTargetVelocity = 14;
        private const int TicVarStartingSpeed = 18;
        private const int TicVarMaxSpeed = 22;
        private const int TicVarMaxDecel = 26;
        private const int TicVarMaxAccel = 30;
        private const int TicVarCurrentPosition = 34;
        private const int TicVarCurrentVelocity = 38;
        private const int TicVarActingTargetPosition = 42;
        private const int TicVarTimeSinceLastStep = 46;
        private const int TicVarDeviceReset = 50;
        private const int TicVarVinVoltage = 51;
        private const int TicVarUpTime = 53;
        private const int TicVarEncoderPosition = 57;
        private const int TicVarRcPulseWidth = 61;
        private const int TicVarAnalogReadingScl = 63;
        private const int TicVarAnalogReadingSda = 65;
        private const int TicVarAnalogReadingTx = 67;
        private const int TicVarAnalogReadingRx = 69;
        private const int TicVarDigitalReadings = 71;
        private const int TicVarPinStates = 72;
        private const int TicVarStepMode = 73;
        private const int TicVarCurrentLimit = 74;
        private const int TicVarDecayMode = 75;
        private const int TicVarInputState = 76;
        private const int TicVarInputAfterAveraging = 77;
        private const int TicVarInputAfterHysteresis = 79;
        private const int TicVarInputAfterScaling = 81;
        private const int TicVarLastMotorDriverError = 0x55;
        private const int TicVarAgcMode = 0x56;
        private const int TicVarAgcBottomCurrentLimit = 0x57;
        private const int TicVarAgcCurrentBoostSteps = 0x58;
        private const int TicVarAgcFrequencyLimit = 0x59;
        private const int TicVariablesSize = 0x5A;
        private const int TicSettingNotInitialized = 0;
        private const int TicSettingControlMode = 1;
        private const int TicSettingOptionsByte1 = 2;
        private const int TicSettingDisableSafeStart = 3;
        private const int TicSettingIgnoreErrLineHigh = 4;
        private const int TicSettingSerialBaudRateGenerator = 5;
        private const int TicSettingSerialDeviceNumberLow = 7;
        private const int TicSettingAutoClearDriverError = 8;
        private const int TicSettingCommandTimeout = 9;
        private const int TicSettingSerialOptionsByte = 11;
        private const int TicSettingLowVinTimeout = 12;
        private const int TicSettingLowVinShutoffVoltage = 14;
        private const int TicSettingLowVinStartupVoltage = 16;
        private const int TicSettingHighVinShutoffVoltage = 18;
        private const int TicSettingVinCalibration = 20;
        private const int TicSettingRcMaxPulsePeriod = 22;
        private const int TicSettingRcBadSignalTimeout = 24;
        private const int TicSettingRcConsecutiveGoodPulses = 26;
        private const int TicSettingInvertMotorDirection = 27;
        private const int TicSettingInputErrorMin = 28;
        private const int TicSettingInputErrorMax = 30;
        private const int TicSettingInputScalingDegree = 32;
        private const int TicSettingInputInvert = 33;
        private const int TicSettingInputMin = 34;
        private const int TicSettingInputNeutralMin = 36;
        private const int TicSettingInputNeutralMax = 38;
        private const int TicSettingInputMax = 40;
        private const int TicSettingOutputMin = 42;
        private const int TicSettingInputAveragingEnabled = 46;
        private const int TicSettingInputHysteresis = 47;
        private const int TicSettingCurrentLimitDuringError = 49;
        private const int TicSettingOutputMax = 50;
        private const int TicSettingSwitchPolarityMap = 54;
        private const int TicSettingEncoderPostscaler = 55;
        private const int TicSettingSclConfig = 59;
        private const int TicSettingSdaConfig = 60;
        private const int TicSettingTxConfig = 61;
        private const int TicSettingRxConfig = 62;
        private const int TicSettingRcConfig = 63;
        private const int TicSettingCurrentLimit = 64;
        private const int TicSettingStepMode = 65;
        private const int TicSettingDecayMode = 66;
        private const int TicSettingStartingSpeed = 67;
        private const int TicSettingMaxSpeed = 71;
        private const int TicSettingMaxDecel = 75;
        private const int TicSettingMaxAccel = 79;
        private const int TicSettingSoftErrorResponse = 83;
        private const int TicSettingSoftErrorPosition = 84;
        private const int TicSettingEncoderPrescaler = 88;
        private const int TicSettingEncoderUnlimited = 92;
        private const int TicSettingKillSwitchMap = 93;
        private const int TicSettingSerialResponseDelay = 94;
        private const int TicSettingLimitSwitchForwardMap = 0x5F;
        private const int TicSettingLimitSwitchReverseMap = 0x60;
        private const int TicSettingHomingSpeedTowards = 0x61;
        private const int TicSettingHomingSpeedAway = 0x65;
        private const int TicSettingSerialDeviceNumberHigh = 0x69;
        private const int TicSettingSerialAltDeviceNumber = 0x6A;
        private const int TicSettingAgcMode = 0x6C;
        private const int TicSettingAgcBottomCurrentLimit = 0x6D;
        private const int TicSettingAgcCurrentBoostSteps = 0x6E;
        private const int TicSettingAgcFrequencyLimit = 0x6F;
        private const int TicSettingsSize = 0x70;
        private const int TicSerialOptionsByteCrcForCommands = 0;
        private const int TicSerialOptionsByteCrcForResponses = 1;
        private const int TicSerialOptionsByte7BitResponses = 2;
        private const int TicSerialOptionsByte14BitDeviceNumber = 3;
        private const int TicOptionsByte1NeverSleep = 0;
        private const int TicOptionsByte1AutoHoming = 1;
        private const int TicOptionsByte1AutoHomingForward = 2;
        private const int TicBaudRateGeneratorFactor = 12000000;
        private const int TicMaxUsbResponseSize = 128;
        private const int TicInputNull = 65535;
        private const int TicControlPinCount = 5;


        #endregion

        public bool IsMoving { get; private set; }
        public bool IsHoming { get; private set; }
        public bool IsDecelerating { get; private set; }
        public bool IsConnected { get; private set; }

        public void InitDefaults()
        {
            Version = 0;
            Serial = 0;
        }

        public bool Open(ProductId prodId, string serial = "")
        {           
            InitDefaults();
            try
            {
                if (IsConnected)
                    return true;

                var myUsbFinder = new UsbDeviceFinder(TicVendorId, (int) prodId, serial);

                // Find and open the usb device.
                myUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);

                // If the device is open and ready
                if (myUsbDevice == null || (serial != "" && myUsbDevice.Info.SerialString != serial))
                    throw new Exception("Device Not Found.");

                // If this is a "whole" usb device (libusb-win32, linux libusb)
                // it will have an IUsbDevice interface. If not (WinUSB) the 
                // variable will be null indicating this is an interface of a 
                // device.
                if (myUsbDevice is IUsbDevice wholeUsbDevice)
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);
                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);
                }   

                ProductId = prodId;

                Vars = new Variables();

                StatusVars = new StatusVariables();

                timer.Interval = 100;
                timer.Elapsed += (o, a) => Process();
                timer.Start();

                IsConnected = true;
            }
            catch (Exception ex)
            {
                myUsbDevice = null;
                Console.WriteLine($@"Can't to device, {ex.Message}");
                //throw new Exception("Device Not Found.", ex);
            }

            return IsConnected;
        }

        public void Close()
        {
            InitDefaults();
            
            IsConnected = false;
            
            if (myUsbDevice is null) 
                return;
 
            if (myUsbDevice.IsOpen)
            {
                // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                // it exposes an IUsbDevice interface. If not (WinUSB) the 
                // 'wholeUsbDevice' variable will be null indicating this is 
                // an interface of a device; it does not require or support 
                // configuration and interface selection.
                if (myUsbDevice is IUsbDevice wholeUsbDevice)
                {
                    // Release interface #0.
                    wholeUsbDevice.ReleaseInterface(0);
                }

                myUsbDevice.Close();
            }

            myUsbDevice = null;

            // Free usb resources
            UsbDevice.Exit();
        }

        public void Process()
        {
            if (!IsConnected)
                return;
            
            ResetCommandTimeout();
            GetVariables();
            GetStatusVariables();
            
            if (IsMoving && InPosition())
                IsMoving = false;

            if (IsHoming && InHome())
                IsHoming = false;
            
            if (IsDecelerating && Vars.CurrentVelocity == 0)
                IsDecelerating = false;
        }

        #region TRANSFERS

        private bool Transfer(int requestType = 0x40, int request = 0, int value = 0, int index = 0)
        {
            if (myUsbDevice == null)
            {
                throw new Exception("Device not connected");
            }

            try
            {
                var setup = new UsbSetupPacket((byte) requestType, (byte) request, value, index, 0);
                return myUsbDevice.ControlTransfer(ref setup, null, 0, out _);
            }
            catch
            {
                return false;
            }
        }


        private bool Transfer(out byte[] data, int requestType = 0xC0, int request = 0, int value = 0, int index = 0,
            int dataOrLength = 0)
        {
            if (myUsbDevice == null)
            {
                throw new Exception("Device not connected");
            }

            try
            {
                data = new byte[dataOrLength];
                var setup = new UsbSetupPacket((byte) requestType, (byte) request, value, index, dataOrLength);
                var res = myUsbDevice.ControlTransfer(ref setup, data, dataOrLength, out var transferred);
                return res && transferred == dataOrLength;
            }
            catch
            {
                data = null;
                return false;
            }
        }


        private bool Transfer32bit(int request, int data)
        {
            var value = data & 65535;
            var index = data >> 16 & 65535;
            return Transfer(requestType: 0x40, request: request, value: value, index: index);
        }

        public bool SetSettingByte(int address, int byteValue)
        {
            return Transfer(request: TicCmdSetSetting, value: address, index: byteValue);
        }

        #endregion

        public bool HaltAndHold()
        {
            IsMoving = false;
            IsHoming = false;
            return Transfer(request: TicCmdHaltAndHold);
        }

        public bool GoHome(GoHome direction)
        {
            IsHoming = true;
            return Transfer(request: TicCmdGoHome, value: (int) direction);
        }

        public bool ResetCommandTimeout()
        {
            return Transfer(request: TicCmdResetCommandTimeout);
        }

        public bool Deenergize()
        {
            return Transfer(request: TicCmdDeenergize);
        }

        public bool Energize()
        {
            return Transfer(request: TicCmdEnergize);
        }

        public bool ExitSafeStart()
        {
            return Transfer(request: TicCmdExitSafeStart);
        }

        public bool EnterSafeStart()
        {
            return Transfer(request: TicCmdEnterSafeStart);
        }

        public bool Reset()
        {
            return Transfer(request: TicCmdReset);
        }

        public bool ClearDriverError()
        {
            return Transfer(request: TicCmdClearDriverError);
        }

        public bool Reinitialize()
        {
            return Transfer(request: TicCmdReinitialize);
        }

        public bool StartBootloader()
        {
            return Transfer(request: TicCmdStartBootloader);
        }

        public bool SetTargetPositionAndWait(int position)
        {
            bool result = Transfer32bit(request: TicCmdSetTargetPosition, data: position);
         
            var timeout = new Timeout(30);
            while (Vars.TargetPosition != position || !timeout.IsDone)
            {
                Thread.Sleep(20);
            }
         
            return result && Vars.TargetPosition != position;
        }

        public bool SetTargetPosition(int position)
        {
            return Transfer32bit(request: TicCmdSetTargetPosition, data: position);
        }

        public bool SetTargetVelocity(int velocity)
        {
            return Transfer32bit(request: TicCmdSetTargetVelocity, data: velocity);
        }

        public bool HaltAndSetPosition(int position)
        {
            return Transfer32bit(request: TicCmdHaltAndSetPosition, data: position);
        }

        public bool SetMaxSpeed(int maxSpeed)
        {
            return Transfer32bit(request: TicCmdSetMaxSpeed, data: maxSpeed);
        }

        public bool SetStartingSpeed(int startingSpeed)
        {
            return Transfer32bit(request: TicCmdSetStartingSpeed, data: startingSpeed);
        }

        public bool SetMaxAccel(int maxAccel)
        {
            return Transfer32bit(request: TicCmdSetMaxAccel, data: maxAccel);
        }

        public bool SetMaxDecel(int maxDecel)
        {
            return Transfer32bit(request: TicCmdSetMaxDecel, data: maxDecel);
        }

        public bool SetStepMode(int stepMode)
        {
            return Transfer(request: TicCmdSetStepMode, value: stepMode);
        }

        public bool SetDecayMode(int decayMode)
        {
            return Transfer(request: TicCmdSetDecayMode, value: decayMode);
        }

        public bool InPosition()
        {
            return StatusVars.OperationState == OperationState.Normal && Vars.CurrentPosition == Vars.TargetPosition;
        }

        public bool InHome()
        {
            return StatusVars.OperationState == OperationState.Normal && Vars.CurrentPosition == 0;
        }

        public void WaitForDeviceReady()
        {
            GetVariables();
            while (StatusVars.OperationState != OperationState.Normal)
            {
                GetVariables();
                Thread.Sleep(PollPeriod);
                ResetCommandTimeout();
            }
        }

        public void WaitForMoveComplete()
        {
            GetVariables();
            while (StatusVars.OperationState == OperationState.Normal && Vars.CurrentPosition != Vars.TargetPosition)
            {
                if (Vars.InputState == InputState.Halt || Vars.InputState == InputState.Invalid)
                    break;
                GetVariables();
                Thread.Sleep(PollPeriod);
            }
        }


        public void WaitForKillSwitch()
        {
            GetVariables();
            while (StatusVars.OperationState == OperationState.Normal)
            {
                if (StatusVars.OperationState == OperationState.SoftError &&
                    (StatusVars.ErrorStatus >> (int) Errors.KillSwitch & 1) == 1)
                {
                    break;
                }

                GetVariables();
                Thread.Sleep(PollPeriod);
            }
        }


        public bool GetStatusVariables(bool clearErrors = false)
        {
            var cmd = clearErrors ? TicCmdGetVariableAndClearErrorsOccurred : TicCmdGetVariable;
            var res = Transfer(out var buffer, requestType: 0xC0, request: cmd, dataOrLength: TicVariablesSize);

            ParseStatusVariables(buffer);

            return res;
        }

        public string GetErrorStatus()
        {
            var err = new StringBuilder();
            for (var i = 0; i < 32; i++)
            {
                if (((1 << i) & StatusVars.ErrorStatus) == 0)
                    continue;

                err.Append($"{(Errors) i} ");
            }

            return err.ToString();
        }


        private bool ParseStatusVariables(byte[] buffer)
        {
            StatusVars.OperationState = (OperationState) buffer[TicVarOperationState];
            StatusVars.Energized = (buffer[TicVarMiscFlags1] >> (int) MiscFlags1.Energized & 1) == 1;
            StatusVars.PositionUncertain = (buffer[TicVarMiscFlags1] >> (int) MiscFlags1.PositionUncertain & 1) == 1;
            StatusVars.ErrorStatus = BitConverter.ToUInt16(buffer, TicVarErrorStatus);
            StatusVars.StringErrorStatus = GetErrorStatus();
            StatusVars.ErrorOccurred = BitConverter.ToUInt32(buffer, TicVarErrorsOccurred);
            return false;
        }

        public bool GetVariables(bool clearErrors = false)
        {
            var cmd = clearErrors ? (byte) TicCmdGetVariableAndClearErrorsOccurred : (byte) TicCmdGetVariable;

            var res = Transfer(out var buffer, requestType: 0xC0, request: cmd, dataOrLength: TicVariablesSize);
            ParseStatusVariables(buffer);

            Vars.PlanningMode = buffer[TicVarPlanningMode];
            Vars.TargetPosition = BitConverter.ToInt32(buffer, TicVarTargetPosition);
            Vars.TargetVelocity = BitConverter.ToInt32(buffer, TicVarTargetVelocity);
            Vars.StartingSpeed = BitConverter.ToUInt32(buffer, TicVarStartingSpeed);
            Vars.MaxSpeed = BitConverter.ToUInt32(buffer, TicVarMaxSpeed);
            Vars.MaxDecel = BitConverter.ToUInt32(buffer, TicVarMaxDecel);
            Vars.MaxAccel = BitConverter.ToUInt32(buffer, TicVarMaxAccel);
            Vars.CurrentPosition = BitConverter.ToInt32(buffer, TicVarCurrentPosition);
            Vars.CurrentVelocity = BitConverter.ToInt32(buffer, TicVarCurrentVelocity);
            Vars.ActingTargetPosition = BitConverter.ToInt32(buffer, TicVarActingTargetPosition);
            Vars.TimeSinceLastStep = BitConverter.ToUInt32(buffer, TicVarTimeSinceLastStep);
            Vars.DeviceReset = buffer[TicVarDeviceReset];
            Vars.VinVoltage = BitConverter.ToUInt16(buffer, TicVarVinVoltage);
            Vars.UpTime = BitConverter.ToUInt32(buffer, TicVarUpTime);
            Vars.EncoderPosition = BitConverter.ToInt32(buffer, TicVarEncoderPosition);
            Vars.RcPulseWidth = BitConverter.ToUInt16(buffer, TicVarRcPulseWidth);
            Vars.AnalogReadinngScl = BitConverter.ToUInt16(buffer, TicVarAnalogReadingScl);
            Vars.AnalogReadinngSda = BitConverter.ToUInt16(buffer, TicVarAnalogReadingSda);
            Vars.AnalogReadinngTx = BitConverter.ToUInt16(buffer, TicVarAnalogReadingTx);
            Vars.AnalogReadinngRx = BitConverter.ToUInt16(buffer, TicVarAnalogReadingRx);
            Vars.DigitalReadings = buffer[TicVarDigitalReadings];
            Vars.PinStates = buffer[TicVarPinStates];
            Vars.StepMode = buffer[TicVarStepMode];
            Vars.CurrentLimit = buffer[TicVarCurrentLimit];
            Vars.DecayMode = buffer[TicVarDecayMode];
            Vars.InputState = (InputState) buffer[TicVarInputState];
            Vars.InputAfterAveraging = BitConverter.ToUInt16(buffer, TicVarInputAfterAveraging);
            Vars.InputAfterHysteresis = BitConverter.ToUInt16(buffer, TicVarInputAfterHysteresis);
            Vars.InputAfterScaling = BitConverter.ToInt32(buffer, TicVarInputAfterScaling);
            return res;
        }

        private static string JoinPropsToString(object obj)
        {
            return string.Join("\n\r", obj
                .GetType()
                .GetProperties()
                .Select(prop => $"{prop.Name} = {prop.GetValue(obj, null)}"));
        }

        public bool StartInDefaultMode(ProductId productId)
        {
            Open(productId);

            if (!IsConnected)
                return false;

            Reinitialize();
            Energize();
            ClearDriverError();

            SetMaxAccel(100000);
            SetMaxDecel(100000);
            SetMaxSpeed(1000000);
            SetStartingSpeed(1000000);
            ExitSafeStart();
            WaitForDeviceReady();

            SetTargetPositionAndWait(100);
            SetTargetPositionAndWait(0);

            return true;
        }


        #region NOT_IMPLEMENTED

        /*  
        bool set_current_limit_code(int value) {
            directly send value - check code for correct values
            return transfer(request: TIC_CMD_SET_CURRENT_LIMIT, value: value);
        }
        
        bool get_firmware_mod_array() {
            var buffer = transfer(request_type: usb.util.CTRL_IN | usb.util.CTRL_TYPE_STANDARD | usb.util.CTRL_RECIPIENT_DEVICE, request: USB_REQUEST_GET_DESCRIPTOR, value: USB_DESCRIPTOR_TYPE_STRING << 8 | TIC_FIRMWARE_MODIFICATION_STRING_INDEX, data_or_length: 256, msg: "getting modified firmware version.");
            //Ignore the modification string if it is just a dash.
            if (buffer.Count == 4 && buffer[2] == 45) {
                buffer = null;
            }
            return buffer;
        }
   
        void current_defaults_for_product() {
            if (product_id == TIC_PRODUCT_ID_T500) {
                product = TIC_PRODUCT_T500;
                current_max = TIC_MAX_ALLOWED_CURRENT_T500;
                current_table = TIC03A_RECOMMENDED_CODES;
                current_table_count = TIC03A_CURRENT_TABLE.Count;
            } else if (product_id == TIC_PRODUCT_ID_T834) {
                // Some of the codes at the end of the table are too high; they violate
                // TIC_MAX_ALLOWED_CURRENT_T834.  So just return a count lower than the
                // actual number of items in the table.
                product = TIC_PRODUCT_T834;
                current_max = TIC_MAX_ALLOWED_CURRENT_T834;
                current_table = TIC01A_RECOMMENDED_CODES;
                current_table_count = 60;
            } else if (product_id == TIC_PRODUCT_ID_T825) {
                product = TIC_PRODUCT_T825;
                current_max = TIC_MAX_ALLOWED_CURRENT_T825;
                current_table = TIC01A_RECOMMENDED_CODES;
                current_table_count = TIC01A_RECOMMENDED_CODES.Count;
            } else {
                product = 0;
                current_max = 0;
                current_table = null;
                current_table_count = null;
            }
        }

        int current_limit_code_to_ma(int code) {
            if (product == TIC_PRODUCT_T500) {
                if (code > TIC_MAX_ALLOWED_CURRENT_CODE_T500) {
                    code = TIC_MAX_ALLOWED_CURRENT_CODE_T500;
                }
                return TIC03A_CURRENT_TABLE[code];
            } else {
                var max = current_max / TIC_CURRENT_LIMIT_UNITS_MA;
                if (code > max) {
                    code = max;
                } else if (code > 64) {
                    code = code * 4;
                } else if (code > 32) {
                    code = code * 2;
                }
                return code * TIC_CURRENT_LIMIT_UNITS_MA;
            }
        }

        int current_limit_ma_to_code(object ma) {
            //   // Assumption: The table is an ascending order, so we want to return the last
            //   // one that is less than or equal to the desired current.
            //   // Assumption: 0 is a valid code and a good default to use.
            var code = 0;
            foreach (var i in Enumerable.Range(0, current_table_count - 1 - 0)) {
                //recomended_current_code = self.current_table_recomended_count
                var table_ma = current_limit_code_to_ma(i);
                if (table_ma <= ma) {
                    code = i;
                } else {
                    break;
                }
            }
            return code;
        }

        void code_test() {
            product_id = TIC_PRODUCT_ID_T500;
            current_defaults_for_product();
            var code = current_limit_ma_to_code(1000);
        }

        double compute_ilim(int dac_level) {
            double r_dacout;
            var v_iset = 0.9;
            var v_dac_top = 4.096;
            var r_top = 107000.0;
            var r_bot = 33000.0;
            var r_dac_top = (32 - dac_level) * 5000;
            var r_dac_bot = dac_level * 5000;
            var v_dacout = v_dac_top * r_dac_bot / (r_dac_bot + r_dac_top);
            if (dac_level == 0) {
                r_dacout = 0;
            } else {
                r_dacout = 1 / (1 / r_dac_top + 1 / r_dac_bot);
            }
            var iset_current_sourced = (v_iset - v_dacout) / (r_top + r_dacout) + v_iset / r_bot;
            if (iset_current_sourced < 0) {
                iset_current_sourced = 0;
            }
            iset_current_sourced = iset_current_sourced * 86666;
            return iset_current_sourced;
        }

        void log_ilim() {
            //puts "  0,"
            //31.downto(0) do |dac_level|
            //    puts "  %d," % [(compute_ilim(dac_level) * 1000).round]
            foreach (var dac_level in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - 31) / -1))).Select(x => 31 + x * -1)) {
                compute_ilim(dac_level);
            }
        }

        */

        #endregion

        public class Variables
        {
            public byte PlanningMode { get; set; }
            public int TargetPosition { get; set; }
            public int TargetVelocity { get; set; }
            public uint StartingSpeed { get; set; }
            public uint MaxSpeed { get; set; }
            public uint MaxDecel { get; set; }
            public uint MaxAccel { get; set; }
            public int CurrentPosition { get; set; }
            public int CurrentVelocity { get; set; }
            public int ActingTargetPosition { get; set; }
            public uint TimeSinceLastStep { get; set; }
            public byte DeviceReset { get; set; }
            public int VinVoltage { get; set; }
            public uint UpTime { get; set; }
            public int EncoderPosition { get; set; }
            public uint RcPulseWidth { get; set; }
            public uint AnalogReadinngScl { get; set; }
            public uint AnalogReadinngSda { get; set; }
            public uint AnalogReadinngTx { get; set; }
            public uint AnalogReadinngRx { get; set; }
            public byte DigitalReadings { get; set; }
            public byte PinStates { get; set; }
            public int StepMode { get; set; }
            public int CurrentLimit { get; set; }
            public int DecayMode { get; set; }
            public InputState InputState { get; set; }
            public uint InputAfterAveraging { get; set; }
            public uint InputAfterHysteresis { get; set; }
            public int InputAfterScaling { get; set; }

            public override string ToString()
            {
                return JoinPropsToString(this);
            }
        }


        public class StatusVariables
        {
            public OperationState OperationState { get; set; }
            public uint ErrorStatus { get; set; }
            public string StringErrorStatus { get; set; }
            public bool PositionUncertain { get; set; }
            public bool Energized { get; set; }
            public uint ErrorOccurred { get; set; }
            
            public override string ToString()
            {
                return JoinPropsToString(this);
            }

        }

        private UsbDevice myUsbDevice;
        private Timer timer = new Timer();
        public int Version { get; set; }
        public int Serial { get; set; }

        private const int PollPeriod = 10;
        public Variables Vars { get; set; }
        public StatusVariables StatusVars { get; set; }
        public ProductId ProductId { get; private set; }
    }

    public struct Timeout
    {
        private readonly int time;
        private readonly DateTime start;

        public Timeout(int time)
        {
            this.time = time;
            this.start = DateTime.Now;
        }

        public bool IsDone => (DateTime.Now - start).TotalSeconds > time;
    }
}