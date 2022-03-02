using HOI4UMT.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOI4UMT.Plugin.RiverMap;
public partial class RiverMap : UserControl {
    private IMapperState MapperState { get; }

    public RiverMap(IMapperState mapperState) {
        InitializeComponent();

        MapperState = mapperState;
    }
}
