﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.mgr.deposit {
    public class list : xmg {
        protected override int powercode {
            get {
                return 1;
            }
        }
        protected override string GetParmNames {
            get {
                return "st";
            }
        }
    }
}
