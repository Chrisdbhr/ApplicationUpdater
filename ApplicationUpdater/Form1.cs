using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace ApplicationUpdater {
    public partial class Form1 : Form {
        private bool userHasGit = false;
        private bool runningAsAdm = false;

        // Git
        private const string localGitPath = launcherResourcesPath + "git/";

        private string applicationPublicRepoHttpsUrl;

        // Application
        private string applicationName = "Game";
        private const string gameFilesPath = "game/";

        // Launcher
        private string launcherName = "Launcher";
        private const string launcherSettingsFileName = "settings.txt";
        private const string launcherResourcesPath = "launcherResources/";

        private LauncherAppSettings launcherAppSettings;

        private const string launcherBgImgName = "launcherBackground.png";
        private const string launcherLogoImgName = "launcherLogo.png";




        public static bool CheckForInstalledProgram(string c_name) {
            string displayName;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null) {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName))) {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(c_name)) {
                        return true;
                    }
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null) {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName))) {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(c_name)) {
                        return true;
                    }
                }
                key.Close();
            }
            return false;
        }

        private void OpenGameApplication() {
            try {
                using (Process gameProcess = new Process()) {
                    gameProcess.StartInfo.FileName = gameFilesPath + applicationName + ".exe";
                    gameProcess.EnableRaisingEvents = true;
                    gameProcess.Start();
                    //TODO sign to error events
                }

            }
            catch (Exception ex) {
                Console.WriteLine("An error occurred when trying to launch game: " + ex.Message);
                return;
            }
        }

        static async Task ExecuteBatCommand(string command) {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
            return;
        }

        private async Task UpdateApplicationAsync() {
            btnUpdate.Text = "Updating...";
            btnUpdate.Enabled = false;

			Directory.CreateDirectory(gameFilesPath);

            StringBuilder command = new StringBuilder($"cd {Path.Combine(launcherResourcesPath, localGitPath)}/bin");
            command.Append($"git.exe clone {launcherAppSettings.applicationPublicRepoHttpsUrl} ../../../{gameFilesPath}");
            command.Append("git.exe reset --hard origin/master");

            await ExecuteBatCommand(command.ToString());

            btnUpdate.Text = "Update";
            btnUpdate.Enabled = true;

        }

        private void CheckForAdmPermissions() {
            this.runningAsAdm = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
            this.label_notRunningAsAdm.Visible = !this.runningAsAdm;
        }

        private void ReadLauncherAppSettingsFromFile(){
            using (StreamReader r = new StreamReader(launcherResourcesPath + launcherSettingsFileName)) {
                string json = r.ReadToEnd();
                this.launcherAppSettings = JsonConvert.DeserializeObject<LauncherAppSettings>(json);
                if (!string.IsNullOrEmpty(this.launcherAppSettings.applicationName))
                    this.applicationName = this.launcherAppSettings.applicationName;
                if (!string.IsNullOrEmpty(this.launcherAppSettings.launcherName))
                    this.launcherName = this.launcherAppSettings.launcherName;
                if (!string.IsNullOrEmpty(this.launcherAppSettings.applicationPublicRepoHttpsUrl)) {
                    this.applicationPublicRepoHttpsUrl = this.launcherAppSettings.applicationPublicRepoHttpsUrl;
                }
            }
        }


        public Form1() {
            InitializeComponent();
        }

        // On form loaded
        private async void Form1_Load(object sender, EventArgs e) {

            this.CheckForAdmPermissions();

            this.ReadLauncherAppSettingsFromFile();

            // check git
            this.label_notRunningAsAdm.Text = CheckForInstalledProgram("git.exe") ? "installed" : "not installed";
                                   

            // load background img from resources folder
            try {
                Bitmap bgBitmap = new Bitmap(launcherResourcesPath + launcherBgImgName);
                if(bgBitmap != null) this.BackgroundImage = bgBitmap;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error loading background image '{launcherBgImgName}': " + ex.Message);
            }

            // load logo img from resources folder
            try {
                Bitmap logoBitmap = new Bitmap(launcherResourcesPath + launcherLogoImgName);
                if (logoBitmap != null) launcherLogo_pictureBox.Image = logoBitmap;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error loading logo image '{launcherLogoImgName}': " + ex.Message);
            }

        }

        private void updateButton_Click(object sender, EventArgs e) {
            UpdateApplicationAsync();
        }

        private void label_notRunningAsAdm_Click(object sender, EventArgs e) {

        }

        private void btnPlay_Click(object sender, EventArgs e) {
            this.OpenGameApplication();
        }

        private void PictureBox1_Click(object sender, EventArgs e) {

        }



    }
}
