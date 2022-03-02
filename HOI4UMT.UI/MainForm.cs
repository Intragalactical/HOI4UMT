using CefSharp;
using CefSharp.WinForms;
using Markdig;
using System.Text;
using HOI4UMT.UI.Common;
using System.Drawing.Imaging;
using HOI4UMT.Library.Plugins;
using LanguageExt;
using System.Reflection;
using HOI4UMT.Library;

namespace HOI4UMT.UI;

internal record PluginWithFolder(IPlugin Plugin, string Folder);

public partial class MainForm : Form {
    private const string HelpFileTemplate = @"./Help/{0}.md";
    private const string BrowserTemplate = @"<!DOCTYPE html><html><head><meta charset=""UTF-8""><style> * {{ font-family: ""Segoe UI"" }}</style></head><body>{0}</body></html>";
    private const string PluginsFolder = @"./Plugins/";

    private IMapperState MapperState { get; }
    private IEnumerable<PluginWithFolder> Plugins { get; }

    private IReadOnlyDictionary<string, string> HelpFileLookUp { get; } = new Dictionary<string, string>() {
        { "Welcome!", "Welcome" }
    };

    private ChromiumWebBrowser Browser { get; } = new("") { Dock = DockStyle.Fill };

    public MainForm() {
        InitializeComponent();

        MapperState = new MapperState();

        // Load plugins
        string[] pluginFolders = Directory.GetDirectories(PluginsFolder);
        Plugins = LoadPlugins(pluginFolders);
    }

    private static IEnumerable<PluginWithFolder> LoadPlugins(string[] pluginFolders) {
        foreach (string pluginFolder in pluginFolders) {
            string? pluginPath = Directory.GetFiles(pluginFolder, "*.dll").FirstOrDefault();
            if (pluginPath != null) {
                Assembly pluginAssembly = LoadPlugin(pluginPath);

                if (GetPlugin(pluginAssembly) is IPlugin plugin)
                    yield return new(plugin, pluginFolder);
            }
        }
    }

    private static Assembly LoadPlugin(string path) {
        PluginLoadContext context = new(path);
        return context.LoadFromAssemblyName(new(Path.GetFileNameWithoutExtension(path)));
    }

    private static IPlugin? GetPlugin(Assembly assembly) {
        foreach (Type type in assembly.GetTypes()) {
            if (typeof(IPlugin).IsAssignableFrom(type)) {
                if (Activator.CreateInstance(type) is IPlugin plugin)
                    return plugin;
            }
        }

        return null;
    }

    private void MainForm_Load(object sender, EventArgs e) {
        MainSplitContainer.Panel1.Controls.Add(Browser);
        IEnumerable<IPlugin> pluginsSortedByPosition = Plugins.OrderBy(pwf => pwf.Plugin.Position).Select(pwf => pwf.Plugin);

        foreach (IPlugin plugin in pluginsSortedByPosition) {
            MainTabControl.TabPages.Add(plugin.Name, plugin.Name);
            TabPage tabPage = MainTabControl.TabPages[plugin.Name];
            UserControl control = plugin.CreateControl(MapperState);
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
        }

        if (pluginsSortedByPosition.Any()) {
            TabPage? welcomeTab = MainTabControl.TabPages.OfType<TabPage>().FirstOrDefault(tabPage => tabPage.Text.Contains("Welcome!"));

            if (welcomeTab != null) {
                MainTabControl.TabPages.Remove(welcomeTab);
            }
        }
    }

    private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
        string selectedTab = MainTabControl.SelectedTab.Text;
        bool helpFileNameFound = HelpFileLookUp.TryGetValue(selectedTab, out string? helpFileName);

        if (!helpFileNameFound) {
            PluginWithFolder? pluginWithFolder = Plugins.FirstOrDefault(pwa => pwa.Plugin.Name == selectedTab);
            if (pluginWithFolder != null) {
                Browser.LoadMarkdown(pluginWithFolder.Folder + pluginWithFolder.Plugin.HelpFilePath, BrowserTemplate);
                return;
            } else {
                _ = MessageBox.Show("Could not fetch correct help file for the selected tab page! Please report this error to the developer! :-)", "Error fetching help file name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Browser.LoadMarkdown(string.Format(HelpFileTemplate, "HelpFileNotFound"), BrowserTemplate);
                return;
            }
        }

        Browser.LoadMarkdown(string.Format(HelpFileTemplate, helpFileName), BrowserTemplate);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
        Application.Exit();
    }
}
