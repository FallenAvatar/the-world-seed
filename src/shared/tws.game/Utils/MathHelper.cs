﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game.Utils;
public static class MathHelper {
	public static float DegreesToRadians( float degrees ) {
		return MathF.PI / 180f * degrees;
	}
}
