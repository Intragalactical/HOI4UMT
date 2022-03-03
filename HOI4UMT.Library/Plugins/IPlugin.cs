namespace HOI4UMT.Library.Plugins;

public interface IPlugin {
    /// <summary>
    /// The name of the Plugin, user-friendly
    /// </summary>
    string Name { get; }
    /// <summary>
    /// The help file path of the Plugin (the .md file)
    /// </summary>
    string HelpFilePath { get; }
    /// <summary>
    /// The position of the TabPage on the TabControl. Highly customizable with decimal points, can be negative.
    /// </summary>
    double Position { get; }

    UserControl CreateControl(IMapperState mapperState, string subfolder);
}
