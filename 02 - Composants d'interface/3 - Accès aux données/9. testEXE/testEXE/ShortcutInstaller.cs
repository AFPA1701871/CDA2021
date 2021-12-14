using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Reflection;
using System.Windows;
using IWshRuntimeLibrary;

namespace testEXE
{
    [RunInstaller(true)]
    public class ShortcutsInstaller : Installer
    {
		private string _location = null;
		private string _name = null;
		private string _description = null;

		private string QuickLaunchFolder
		{
			get
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
					"\\Microsoft\\Internet Explorer\\Quick Launch";
			}
		}

		private string ShortcutTarget
		{
			get
			{
				if (_location == null)
					_location = Assembly.GetExecutingAssembly().Location;
				return _location;
			}
		}

		private string ShortcutName
		{
			get
			{
				if (_name == null)
				{
					Assembly myAssembly = Assembly.GetExecutingAssembly();

					try
					{
						object titleAttribute = myAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
						_name = ((AssemblyTitleAttribute)titleAttribute).Title;
					}
					catch { }

					if ((_name == null) || (_name.Trim() == string.Empty))
						_name = myAssembly.GetName().Name;
				}
				return _name;
			}
		}

		private string ShortcutDescription
		{
			get
			{
				if (_description == null)
				{
					Assembly myAssembly = Assembly.GetExecutingAssembly();

					try
					{
						object descriptionAttribute = myAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0];
						_description = ((AssemblyDescriptionAttribute)descriptionAttribute).Description;
					}
					catch { }

					if ((_description == null) || (_description.Trim() == string.Empty))
						_description = "Launch " + ShortcutName;
				}
				return _description;
			}
		}

		public override void Install(IDictionary savedState)
		{
			base.Install(savedState);

			const string DESKTOP_SHORTCUT_PARAM = "DESKTOP_SHORTCUT";
			const string QUICKLAUNCH_SHORTCUT_PARAM = "QUICKLAUNCH_SHORTCUT";
			const string ALLUSERS_PARAM = "ALLUSERS";
			// The installer will pass the ALLUSERS, DESKTOP_SHORTCUT and QUICKLAUNCH_SHORTCUT   
			// parameters. These have been set to the values of radio buttons and checkboxes from the
			// MSI user interface.
			// ALLUSERS is set according to whether the user chooses to install for all users (="1") 
			// or just for themselves (="").
			// If the user checked the checkbox to install one of the shortcuts, then the corresponding 
			// parameter value is "1".  If the user did not check the checkbox to install one of the 
			// desktop shortcut, then the corresponding parameter value is an empty string.

			// First make sure the parameters have been provided.

			if (!Context.Parameters.ContainsKey(ALLUSERS_PARAM))
                throw new Exception(string.Format("The {0} parameter has not been provided for the {1} class.", ALLUSERS_PARAM, this.GetType()));
            if (!Context.Parameters.ContainsKey(DESKTOP_SHORTCUT_PARAM))
                throw new Exception(string.Format("The {0} parameter has not been provided for the {1} class.", DESKTOP_SHORTCUT_PARAM, this.GetType()));
            if (!Context.Parameters.ContainsKey(QUICKLAUNCH_SHORTCUT_PARAM))
                throw new Exception(string.Format("The {0} parameter has not been provided for the {1} class.", QUICKLAUNCH_SHORTCUT_PARAM, this.GetType()));
            //For the checkboxes that we will add to the Setup project to allow the user to choose to install the shortcuts,
            //the parameter value will be "1" if the checkbox is checked, and an empty string if the checkbox is unchecked.
            bool allusers = Context.Parameters[ALLUSERS_PARAM] != string.Empty;
			bool installDesktopShortcut = Context.Parameters[DESKTOP_SHORTCUT_PARAM] != string.Empty;
			bool installQuickLaunchShortcut = Context.Parameters[QUICKLAUNCH_SHORTCUT_PARAM] != string.Empty;

			if (installDesktopShortcut)
			{
				
				string desktopFolder = null;

				if (allusers)
				{
					try
					{
						
						object allUsersDesktop = "AllUsersDesktop";
						WshShell shell = new WshShell();
						desktopFolder = shell.SpecialFolders.Item(ref allUsersDesktop).ToString();
					}
					catch { }
				}
				if (desktopFolder == null)
					desktopFolder = "C:\\Users\\Bille\\OneDrive\\Bureau";

				CreateShortcut(desktopFolder, ShortcutName, ShortcutTarget, ShortcutDescription);
			}

			if (installQuickLaunchShortcut)
			{
				CreateShortcut(QuickLaunchFolder, ShortcutName, ShortcutTarget, ShortcutDescription);
			}
		}

        private void CreateShortcut(string folder, string name, string target, string description)
        {
            string shortcutFullName = Path.Combine(folder, name + ".lnk");

            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(shortcutFullName);
            link.TargetPath = target;
            link.Description = description;
            link.Save();

        }

    } 
}
