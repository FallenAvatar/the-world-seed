using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game;
public interface IBaseApp : IDisposable, IAsyncDisposable {
	Task Init( string[] args );
	Task<int> Run();
	Task Quit(bool fromException = false);
	void ExceptionCatchall( Exception? ex );
}
