﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game.client.Renderer;
public interface IRenderer : IDisposable {
	Task Init();
	Task Render();
}
